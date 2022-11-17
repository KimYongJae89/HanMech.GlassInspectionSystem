using Device.Camera;
using Device.Edge;
using Device.PLC;
using enumType;
using HMechLogLib;
using HMechUtility;
using Insp;
using MechAI.Model;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using RuleAlgorithm;
using RuleAlgorithm.Broken;
using RuleAlgorithm.Contour;
using RuleAlgorithm.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GlassInspectionSystem.Class
{
    public class SubImageList
    {
        private object _imgLock = new object();

        private List<Bitmap> _images = null;
        public List<Bitmap> Images
        {
            get { return _images; }
            set { _images = value; }
        }
    }

    public class SubSequence
    {
        private string _glassID = "";
        public string GlassID
        {
            get { return _glassID; }
            set
            {
                _glassID = value;
                _inspResult.GlassID = _glassID;
            }
        }

        private DateTime _glassInTime;
        public DateTime GlassInTime
        {
            get { return _glassInTime; }
            set { _glassInTime = value; }
        }

        private eSeqStep _seqStep = eSeqStep.SEQ_STOP;
        public eSeqStep SeqStep
        {
            get { return _seqStep; }
            set { _seqStep = value; }
        }

        private string _saveImagePath; // 절대 경로
        public string SaveImagePath
        {
            get { return _saveImagePath; }
            set { _saveImagePath = value; }
        }

        private string _dbImagePath; // 상대 경로
        public string DBImagePath
        {
            get { return _dbImagePath; }
            set { _dbImagePath = value; }
        }

        private int _camCount = 0;

        private InspResult _inspResult = new InspResult();

        private SubImageList[] _subImageList = null;
        private Queue<SubImg> _subImageInfoList = null;

        private List<EdgeElement>[] _finallyEdgeList = null;
        private Queue<EdgeElement> _leftRightEdgeListQueue = null; // Grab 시 Left, Right Edge 검사

        private object _cropLock = new object();

        private Bitmap[] _mergeImageList = null;
        private Bitmap _thumbnailImage = null;
        private Bitmap[] _drawDefectImageList = null;
        private Bitmap[] _pnlDisplayImageList = null;
        private Bitmap _prevImage = null;

        private double _pnlDisplayRatio = 0;

        private Thread _seqThread = null;
        private Thread _saveThread = null;

        private bool _isStop = false;
        private bool _isAIFrontInspCompleted = false;
        private bool _isAITopBottomInspCompleted = false;
        private bool _isAILeftRightInspCompleted = false;
        private bool _isRuleTopBottomEdgeInspCompleted = false;
        private bool _isRuleLeftRightEdgeInspCompleted = false;
        private bool _isImageProcessingCompleted = false;

        private bool _isImageLoadMode = false;
        LoadImageHelper[] _loadHelper = null;

        private Stopwatch _inspStopWatch = new Stopwatch();
        private Stopwatch _plcTimeOutStopWatch = new Stopwatch();

        public Stopwatch TactTimeStopWatch = new Stopwatch();


        public SubSequence(int camCount, bool isImageLoadMode = false)
        {
            _camCount = camCount;
            _subImageList = new SubImageList[camCount];

            _finallyEdgeList = new List<EdgeElement>[camCount];
            _mergeImageList = new Bitmap[camCount];
            _drawDefectImageList = new Bitmap[camCount];

            for (int i = 0; i < camCount; i++)
            {
                _subImageList[i] = new SubImageList();
                _subImageList[i].Images = new List<Bitmap>();
                _finallyEdgeList[i] = new List<EdgeElement>();

                Machine.Instance().CameraManager.SetSubImageList(i, _subImageList[i].Images, _prevImage);
                Machine.Instance().CameraManager.SetFinallyEdgeList(i, _finallyEdgeList[i]);
            }

            _subImageInfoList = new Queue<SubImg>();
            ICamera.SubImageInfoList = _subImageInfoList;

            _leftRightEdgeListQueue = new Queue<EdgeElement>();
            ICamera.LeftRightEdgeInfoList = _leftRightEdgeListQueue;
            _isImageLoadMode = isImageLoadMode;
        }

        public void LoadSubImage(string[] fileNames)
        {
            if (_loadHelper == null)
            {
                _loadHelper = new LoadImageHelper[_camCount];
                for (int i = 0; i < _camCount; i++)
                {
                    _loadHelper[i] = new LoadImageHelper();
                }
            }
            List<EdgeElement> edgeElementList = new List<EdgeElement>();
            StartLeftRightEdInspection();
            foreach (string fileName in fileNames)
            {
                Mat mat = new Mat(fileName);
                if (mat.Channels() != 1)
                {
                    Cv2.CvtColor(mat, mat, OpenCvSharp.ColorConversionCodes.BGR2GRAY);
                }
                Bitmap bmp = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat);

                string temp = "";
                int dotIndex = fileName.LastIndexOf(".");

                temp = fileName.Substring(0, dotIndex);

                int dashIndex = temp.LastIndexOf("_");
                int substringIndex = dashIndex + 1;

                int subNo = Convert.ToInt32(temp.Substring(substringIndex, temp.Length - substringIndex));

                temp = temp.Substring(0, dashIndex);

                dashIndex = temp.LastIndexOf("_");
                substringIndex = dashIndex + 1;

                int camNo = Convert.ToInt32(temp.Substring(substringIndex, temp.Length - substringIndex));
              
                _subImageList[camNo].Images.Add((Bitmap)bmp.Clone());

                _loadHelper[camNo].LoadSearchEdge(mat, camNo, subNo, _camCount, _leftRightEdgeListQueue);

                _subImageInfoList.Enqueue(new SubImg(camNo, subNo, bmp.Width, bmp.Height));


                mat.Dispose();
                bmp.Dispose();
            }
            for (int camNo = 0; camNo < _camCount; camNo++)
            {
                _finallyEdgeList[camNo].AddRange(_loadHelper[camNo].GetFinallyEdge(_camCount));

            }
        }

        private void SetImagePath(string glassID)
        {
            DateTime dateTime = DateTime.Now;
            string imageFolder = Settings.Instance().Operation.ImageFolderPath;

            SaveImagePath = Path.Combine(imageFolder, dateTime.Month.ToString(), dateTime.Day.ToString(), glassID);
            DBImagePath = Path.Combine(dateTime.Month.ToString(), dateTime.Day.ToString(), glassID);
        }

        public void Start(bool isImageLoading)
        {
            _isStop = false;
            _seqThread = new Thread(ThreadFunc);
            _seqThread.Start();
            if (isImageLoading == false)
                StartLeftRightEdInspection();
        }

        private void ThreadFunc()
        {
            _seqStep = eSeqStep.SEQ_START;
            while (!_isStop)
            {
                if (Status.Instance().ProgramMode == eProgramMode.Inspection)
                {
                    SeqSteps();
                }
                else
                {
                    // Click Stop Button
                    Machine.Instance().LightOn(false);
                    FormMain.Instance().Log(eLogType.SEQ, "Stop SubSequence. Light Off.", Status.Instance().NowTime, true);

                    Machine.Instance().CameraManager.StopGrab();   // Grab Stop
                    FormMain.Instance().Log(eLogType.SEQ, "Stop SubSequence. Grab End.", Status.Instance().NowTime, true);

                    _isStop = true;
                }
                Thread.Sleep(10);
            }
        }

        private void SeqSteps()
        {
            try
            {
                switch (_seqStep)
                {
                    case eSeqStep.SEQ_START:
                        _seqStep = eSeqStep.SEQ_INSPECTION_FRONT;
                        break;

                    case eSeqStep.SEQ_INSPECTION_FRONT:

                        if (Settings.Instance().Operation.UseAi == true)
                        {
                            if (Settings.Instance().Operation.AiType == eAIInspectionType.Front)
                            {
                                InspectionFrontAI(); //  전면검사
                            }
                            else
                            {
                                _isAIFrontInspCompleted = true;
                            }
                        }
                        else
                        {
                            _isAIFrontInspCompleted = true;
                        }

                        _seqStep = eSeqStep.SEQ_INSPECTION_FRONT_COMPLETE;
                        break;

                    case eSeqStep.SEQ_INSPECTION_FRONT_COMPLETE:

                        if (_isAIFrontInspCompleted == false)
                            break;

                        if (Settings.Instance().Operation.AiType == eAIInspectionType.Front
                            && Settings.Instance().Operation.UseAi)
                        {
                            FormMain.Instance().Log(eLogType.SEQ, "End AI Front Inspection.", Status.Instance().NowTime, true);
                        }

                        _seqStep = eSeqStep.SEQ_INSPECTION_EDGE;
                        break;

                    case eSeqStep.SEQ_INSPECTION_EDGE:

                        if (Machine.Instance().CameraManager.IsGrabbing())
                            break;
                        if (Machine.Instance().CameraManager.IsCallBackCompleted() == false)
                            break;

                        SetCornerRect();

                        if (Settings.Instance().Operation.UseAi || Settings.Instance().Operation.IsRuleBaseInspection())
                        {
                            InspectionTopBottomEdge(); // Edge Inspection
                        }
                        else
                        {
                            _isAITopBottomInspCompleted = true;
                            _isAILeftRightInspCompleted = true;
                            _isRuleTopBottomEdgeInspCompleted = true;
                            _isRuleLeftRightEdgeInspCompleted = true;
                        }

                        _seqStep = eSeqStep.SEQ_INSPECTION_EDGE_COMPLETE;
                        break;

                    case eSeqStep.SEQ_INSPECTION_EDGE_COMPLETE:

                        if (IsEdgeInspCompleted() == false)
                            break;

                        TactTimeStopWatch.Stop();
                        _inspResult.TactTime = (double)TactTimeStopWatch.ElapsedMilliseconds / 1000.0;

                        _seqStep = eSeqStep.SEQ_FILTER_DEFECT;
                        break;

                    case eSeqStep.SEQ_FILTER_DEFECT:
                        _inspResult.FilterDefect(_finallyEdgeList);

                        _seqStep = eSeqStep.SEQ_SEND_RESULT;
                        break;

                    case eSeqStep.SEQ_SEND_RESULT:
                        Machine.Instance().SendResultToPLC(_inspResult.InspResultType);
                        FormMain.Instance().Log(eLogType.SEQ, "Send Result To PLC.", Status.Instance().NowTime);

                        _plcTimeOutStopWatch.Restart();

                        _inspResult.SetImagePath(_glassInTime);

                        //if (this._isImageLoadMode == false)
                        {
                            DBManager.Instance().AddResult(_glassInTime, _inspResult);
                            FormMain.Instance().Log(eLogType.SEQ, "Add Result.", Status.Instance().NowTime);

                            DBManager.Instance().AddDefectInformation(_glassInTime, _inspResult, _finallyEdgeList);
                            FormMain.Instance().Log(eLogType.SEQ, "Add Defect Information.", Status.Instance().NowTime);
                        }

                        _seqStep = eSeqStep.SEQ_CHECK_SEND_RESULT;
                        break;

                    case eSeqStep.SEQ_CHECK_SEND_RESULT:

                        if (Machine.Instance().CheckPLCResult())
                            _seqStep = eSeqStep.SEQ_MERGE_IMAGE;
                        else
                        {
                            if (Settings.Instance().Operation.PlcType != ePLCType.None)
                            {
                                if (_plcTimeOutStopWatch.ElapsedMilliseconds >= 3000)
                                {
                                    FormMain.Instance().Log(eLogType.SEQ, "Check PLC Result Time Out.", Status.Instance().NowTime, true);
                                    _seqStep = eSeqStep.SEQ_MERGE_IMAGE;
                                }
                            }
                        }

                        break;

                    case eSeqStep.SEQ_MERGE_IMAGE:

                        StartImageProcess();

                        _seqStep = eSeqStep.SEQ_UI_RESULT_UPDATE;
                        break;

                    case eSeqStep.SEQ_UI_RESULT_UPDATE:

                        if (_isImageProcessingCompleted == false)
                            break;

                        FormMain.Instance().DisplayListControl.DisplayImageUpdate(_pnlDisplayImageList, _pnlDisplayRatio);
                        FormMain.Instance().GlassMapControl.ThumbnailImageUpdate(_thumbnailImage);
                        FormMain.Instance().InspectionResultControl.UpdateResult(_inspResult);
                        FormMain.Instance().InspectionResultListControl.UpdateResult(_inspResult);
                        FormMain.Instance().DefectInformationControl.UpdateDefect(_inspResult.FinallyDefectList, _inspResult.SaveImagePath);
                        FormMain.Instance().DailyInformationControl.UpdateDailyCount();

                        _seqStep = eSeqStep.SEQ_SAVE_IMAGE;
                        break;

                    case eSeqStep.SEQ_SAVE_IMAGE:

                        FormMain.Instance().DefectInformationControl.ActiveDataGridView(false);
                        _saveThread = new Thread(SaveImage);
                        _saveThread.Start();

                        _seqStep = eSeqStep.SEQ_DELETE_DATA;
                        break;
                    case eSeqStep.SEQ_DELETE_DATA:

                        Machine.Instance().StartDeleteData(_inspResult.GlassID);

                        _seqStep = eSeqStep.SEQ_END;
                        break;
                    case eSeqStep.SEQ_END:
                        _isStop = true;
                        break;

                    case eSeqStep.SEQ_ERROR:

                        Machine.Instance().LightOn(false);   // Light Off
                        Logger.Write(eLogType.ERROR, "Error!, Stop SubSequence, Light Off", Status.Instance().NowTime);
                        FormMain.Instance().LogDisplayControl.AddLog("Error!, Stop SubSequence, Light Off.");

                        Machine.Instance().CameraManager.StopGrab(); // Camera Grab Stop
                        Logger.Write(eLogType.ERROR, "Error!, Stop SubSequence, Camera Grab Stop", Status.Instance().NowTime);
                        FormMain.Instance().LogDisplayControl.AddLog("Error!, Stop SubSequence, Camera Grab Stop.");

                        Logger.Write(eLogType.ERROR, "Error!, Stop SubSequence, Restart SubSequence", Status.Instance().NowTime);       // Error Log
                        FormMain.Instance().LogDisplayControl.AddLog("IError!, Stop SubSequence, Restart SubSequence.");

                        //_seqStep = eSeqStep.SEQ_START;
                        _isStop = true;

                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(eLogType.ERROR, ex);
                FormMain.Instance().LogDisplayControl.AddLog("Error! Sequence.");

                _seqStep = eSeqStep.SEQ_ERROR;
                _isStop = true;
            }
        }

        private void InspectionFrontAI()
        {
            try
            {
                FormMain.Instance().Log(eLogType.SEQ, "Start Front AI Inspection.", Status.Instance().NowTime, true);
                FormMain.Instance().Log(eLogType.INSPECTION, "Start Front AI Inspection.", Status.Instance().NowTime, false);
                if (Inspection.Instance().MechAI.IsInitialized() == false)
                {
                    FormMain.Instance().Log(eLogType.INSPECTION, "AI is not Initialize.", Status.Instance().NowTime, false);
                    return;
                }

                while (_isAIFrontInspCompleted == false)
                {
                    if (Status.Instance().ProgramMode != eProgramMode.Inspection)
                    {
                        _isAIFrontInspCompleted = true;
                        return;
                    }

                    if (Machine.Instance().CameraManager.IsGrabbing() == false)
                    {
                        //임시
                        if (_subImageInfoList.Count == 0)
                        {
                            _isAIFrontInspCompleted = true;
                            FormMain.Instance().Log(eLogType.SEQ, "Front Inspection Completed", Status.Instance().NowTime);
                            return;
                        }
                    }

                    SubImg subImage;
                    lock (ICamera.ObjLock)
                    {
                        //임시
                        if (_subImageInfoList.Count == 0)
                            continue;

                        subImage = (SubImg)_subImageInfoList.Dequeue();
                    }

                    Bitmap bmp = _subImageList[subImage.CamNo].Images[subImage.SubNo];
                    //byte[] bmpArray = ImageHelper.ConvertGrey8BitImageToArray(bmp);

                    byte[] bmpArray = ImageHelper.Convert_Image(bmp);
                    //Mat mat = BitmapConverter.ToMat(bmp);
                    _inspStopWatch.Restart();

                    List<MechItem> defectList = Inspection.Instance().MechAI.Process(bmpArray);

                    _inspStopWatch.Stop();

                    //mat.Dispose();
                    eResultConstant aiResult = eResultConstant.OK;

                    if (defectList.Count > 0)
                    {
                        aiResult = eResultConstant.NG;
                    }

                    string log = string.Format("Front AI Inspection." +
                        " CamNo : {0}" +
                        " SubNo : {1}" +
                        " TactTime : {2} ms" +
                        " Result : {3}"
                        , subImage.CamNo, subImage.SubNo, _inspStopWatch.ElapsedMilliseconds.ToString(), aiResult.ToString());

                    //Console.WriteLine(log);
                    FormMain.Instance().Log(eLogType.INSPECTION, log, Status.Instance().NowTime);

                    if (defectList.Count > 0)
                    {
                        _inspResult.AddAIFrontDefectList(bmp, defectList, subImage, eInspectionType.AI_Front);
                    }

                    foreach (MechItem item in defectList)
                    {
                        string defectLog = string.Format("Type : {0}, Confidence : {1}, X : {2}, Y : {3}, Width : {4}, Height : {5} ",
                                            item.Type.ToString(), item.Confidence.ToString(), item.X.ToString(), item.Y.ToString(), item.Width.ToString(), item.Height.ToString());
                        FormMain.Instance().Log(eLogType.INSPECTION, defectLog, Status.Instance().NowTime, false);
                    }

                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(eLogType.ERROR, ex);
                _isAIFrontInspCompleted = true;
            }
        }

        private void InspectionTopBottomEdge()
        {
            try
            {
                FormMain.Instance().Log(eLogType.SEQ, "Start Edge(Top,Bottom) Inspection.", Status.Instance().NowTime, true);
                FormMain.Instance().Log(eLogType.INSPECTION, "Start Edge(Top,Bottom) Inspection.", Status.Instance().NowTime, false);
                bool isEdgeAIEnable = false;
                if (Settings.Instance().Operation.UseAi && Settings.Instance().Operation.AiType == eAIInspectionType.Edge)
                    isEdgeAIEnable = true;

                if (isEdgeAIEnable || Settings.Instance().Operation.IsRuleBaseInspection())
                {
                    CropTopBottomImageInspection(); // 검사를 위한 이미지 Crop(Top,Bottom 만, Left, Right는 이미지 Grab 시)
                }

                _isRuleTopBottomEdgeInspCompleted = true;
                _isAITopBottomInspCompleted = true;
                FormMain.Instance().Log(eLogType.SEQ, "End TopBottom Edge Inspection.", Status.Instance().NowTime, true);
            }
            catch (Exception ex)
            {
                Logger.WriteException(eLogType.ERROR, ex);
                _isAITopBottomInspCompleted = true;
                _isRuleTopBottomEdgeInspCompleted = true;
            }
        }

        public void StartLeftRightEdInspection()
        {
            Thread th = new Thread(CropLeftRightInspection);
            th.Start();
        }

        private void CropLeftRightInspection()
        {
            try
            {
                bool isInspection = Settings.Instance().Operation.AiType == eAIInspectionType.Edge || Settings.Instance().Operation.IsRuleBaseInspection();

                while (true)
                {
                    if (Status.Instance().ProgramMode != eProgramMode.Inspection)
                        break;

                    if (isInspection == false)
                        break;
                    if (_leftRightEdgeListQueue.Count > 0)
                    {
                        EdgeElement element = null;
                        lock (ICamera.ObjLockEdgeInsp)
                        {
                            element = _leftRightEdgeListQueue.Dequeue();
                        }

                        if (element.Type == eEdgeType.Left || element.Type == eEdgeType.Right)
                        {
                            EdgeAIImageInspection(element);
                            EdgeImageRuleInspectionNonFork(element);
                        }
                    }
                    else
                    {
                        if (_isRuleTopBottomEdgeInspCompleted && _isAITopBottomInspCompleted)
                        {
                            if (Machine.Instance().CameraManager.IsGrabbing() == false)
                                break;
                        }
                    }
                    Thread.Sleep(0);
                }

                _isAILeftRightInspCompleted = true;
                _isRuleLeftRightEdgeInspCompleted = true;
                FormMain.Instance().Log(eLogType.SEQ, "End LeftRight Edge Inspection.", Status.Instance().NowTime, true);
            }
            catch (Exception ex)
            {
                Logger.WriteException(eLogType.ERROR, ex);
                _isAILeftRightInspCompleted = true;
                _isRuleLeftRightEdgeInspCompleted = true;
            }
        }

        private Bitmap RotateImage(Bitmap bmp, float angle)
        {
            Mat mat = BitmapConverter.ToMat(bmp);
            Mat matrix = Cv2.GetRotationMatrix2D(new Point2f(bmp.Width / 2, bmp.Height / 2), -angle, 1);
            Cv2.WarpAffine(mat, mat, matrix, new OpenCvSharp.Size(mat.Width, mat.Height), InterpolationFlags.Linear);
            return BitmapConverter.ToBitmap(mat);
        }

        private void EdgeAIImageInspection(EdgeElement element)
        {
            if (Settings.Instance().Operation.UseAi == true && Settings.Instance().Operation.AiType == eAIInspectionType.Edge)
            {
                EdgeElement calcElement = element.Copy();
                CropInfo info = EdgeCropImage(ref calcElement);

                if (info != null)
                {
                    _inspResult.CropAIImageList.Add(info);

                    AIInspection(ref info);

                }
            }
        }

        private void ForkImageRuleInspection(EdgeElement element)
        {
            if (element.Type == eEdgeType.Bottom || element.Type == eEdgeType.Top)
            {
                List<ForkImageRoi> forkRoiList = GetBottomForkRoiInImage(element);

                foreach (ForkImageRoi forkArea in forkRoiList)
                {
                    EdgeElement calcElement = element.Copy();

                    if(Settings.Instance().Operation.UseForkBrokenAlgorithm == true)
                    {
                        BrokenParams param = Settings.Instance().AlgorithmSettings.GetBrokenParams(element.Type, forkArea.IsForkImage);
                        EdgeHelper.SetForkBrokenRoi(ref calcElement, param.InSidePixelFromEdge, param.OutSidePixelFromEdge, forkArea.Roi.X, forkArea.Roi.X + forkArea.Roi.Width);
                        CropInfo info = EdgeCropImage(ref calcElement);
                        
                        if (info != null)
                        {
                            BrokenInspection(ref info, forkArea.IsForkImage);

                            if(forkArea.IsForkImage)
                            {
                                _inspResult.CropBrokenImageListFork.Add(info);
                            }
                            else
                            {
                                _inspResult.CropBrokenImageListNonFork.Add(info);
                            }
                        }
                    }

                    if (Settings.Instance().Operation.UseForkContourAlgorithm == true)
                    {
                        ContourParams param = Settings.Instance().AlgorithmSettings.GetContourParams(element.Type, forkArea.IsForkImage);
                        EdgeHelper.SetForkContourRoi(ref calcElement, param.Offset, param.InspectionArea, forkArea.Roi.X, forkArea.Roi.X + forkArea.Roi.Width);
                        CropInfo info = EdgeCropImage(ref calcElement);

                        if (info != null)
                        {
                            ContourInspection(ref info, forkArea.IsForkImage);

                            if (forkArea.IsForkImage)
                            {
                                _inspResult.CropContourImageListFork.Add(info);
                            }
                            else
                            {
                                _inspResult.CropContourImageListNonFork.Add(info);
                            }
                        }
                    }
                }
            }
        }

        private void EdgeImageRuleInspectionNonFork(EdgeElement element)
        {
            if (Settings.Instance().Operation.UseEdgeBrokenAlgorithm == true)
            {
                EdgeElement calcElement = element.Copy();
                BrokenParams param = Settings.Instance().AlgorithmSettings.Edge.BrokenParams.GetParams(element.Type);
                EdgeHelper.SetEdgeBrokenRoi(ref calcElement, param.InSidePixelFromEdge, param.OutSidePixelFromEdge);
                CropInfo info = EdgeCropImage(ref calcElement);

                if (info != null)
                {
                    BrokenInspection(ref info, false);
                    _inspResult.CropBrokenImageListNonFork.Add(info);
                }
            }
            if (Settings.Instance().Operation.UseEdgeContourAlgorithm == true)
            {
                EdgeElement calcElement = element.Copy();
                ContourParams param = Settings.Instance().AlgorithmSettings.Edge.ContourParams.GetParams(element.Type);
                EdgeHelper.SetEdgeContourRoi(ref calcElement, param.Offset, param.InspectionArea);

                CropInfo info = EdgeCropImage(ref calcElement);

                if (info != null)
                {
                    ContourInspection(ref info, false);
                    _inspResult.CropContourImageListNonFork.Add(info);
                }
            }
        }

        public List<ForkImageRoi> GetBottomForkRoiInImage(EdgeElement element)
        {
            int lastSubNo = _subImageList[element.CamNo].Images.Count - 1;
            int ignoreLeftXFromFork = Settings.Instance().Operation.CamProp[element.CamNo].IgnoreLeftXFromFork;
            int ignoreRightXFromFork = Settings.Instance().Operation.CamProp[element.CamNo].IgnoreRightXFromFork;
            double threshold1 = Settings.Instance().Operation.CamProp[element.CamNo].Threshold1;
            double threshold2 = Settings.Instance().Operation.CamProp[element.CamNo].Threshold2;

            List<ForkImageRoi> sectionIndexList = new List<ForkImageRoi>();

            int interval = 20;

            lock (_cropLock)
            {
                Bitmap lastSubImage = _subImageList[element.CamNo].Images[lastSubNo];
                if (element.CamNo == 0)
                {
                    Rectangle rect = new Rectangle(EdgeDetect.IgnoreLeftXOffsetForEdgeDetect, 0, lastSubImage.Width - EdgeDetect.IgnoreLeftXOffsetForEdgeDetect, lastSubImage.Height);

                    Bitmap cropImage = lastSubImage.Clone(rect, lastSubImage.PixelFormat);

                    Bitmap cannyBmp = HanMechImageHelper.ProcessCanny(cropImage, threshold1, threshold2);

                    int leftIndex = EdgeDetect.FindLeftForkIndex(cannyBmp);
                    if (leftIndex == -1)
                    {
                        string message = String.Format("Fork is not LeftIndex Detect. CamNo : {0}", element.CamNo.ToString());
                        Logger.Write(eLogType.INSPECTION, message, Status.Instance().NowTime);
                        return sectionIndexList;
                    }

                    int rightIndex = EdgeDetect.FindRightForkIndex(cannyBmp);
                    if (rightIndex == -1)
                    {
                        string message = String.Format("Fork is not RightIndex Detect. CamNo : {0}", element.CamNo.ToString());
                        Logger.Write(eLogType.INSPECTION, message, Status.Instance().NowTime);
                        return sectionIndexList;
                    }

                    leftIndex += EdgeDetect.IgnoreLeftXOffsetForEdgeDetect;
                    rightIndex += EdgeDetect.IgnoreLeftXOffsetForEdgeDetect;

                    Rectangle leftRect = new Rectangle(EdgeDetect.IgnoreLeftXOffsetForEdgeDetect, 0, leftIndex - interval - EdgeDetect.IgnoreLeftXOffsetForEdgeDetect, lastSubImage.Height);
                    Rectangle rgihtRect = new Rectangle(rightIndex + interval, 0, lastSubImage.Width - (rightIndex + interval), lastSubImage.Height);

                    int centerRectX = leftIndex + interval + ignoreLeftXFromFork;
                    int centerRectWidth = (rightIndex - interval - ignoreRightXFromFork) - centerRectX;
                    Rectangle centerRect = new Rectangle(centerRectX, 0, centerRectWidth, lastSubImage.Height);

                    ForkImageRoi leftRoi = new ForkImageRoi(false, leftRect);
                    ForkImageRoi rightRoi = new ForkImageRoi(false, rgihtRect);
                    ForkImageRoi centerRoi = new ForkImageRoi(true, centerRect);

                    sectionIndexList.Add(leftRoi);
                    sectionIndexList.Add(rightRoi);
                    sectionIndexList.Add(centerRoi);

                    cannyBmp.Dispose();
                    cropImage.Dispose();
                }
                else if (element.CamNo == Settings.Instance().Operation.CamCount - 1)
                {
                    Rectangle rect = new Rectangle(0, 0, lastSubImage.Width - EdgeDetect.IgnoreRightXOffsetForEdgeDetect, lastSubImage.Height);
                    Bitmap cropImage = lastSubImage.Clone(rect, lastSubImage.PixelFormat);

                    Bitmap cannyBmp = HanMechImageHelper.ProcessCanny(cropImage, threshold1, threshold2);

                    int leftIndex = EdgeDetect.FindLeftForkIndex(cannyBmp);
                    if (leftIndex == -1)
                    {
                        string message = String.Format("Fork is not LeftIndex Detect. CamNo : {0}", element.CamNo.ToString());
                        Logger.Write(eLogType.INSPECTION, message, Status.Instance().NowTime);
                        return sectionIndexList;
                    }

                    int rightIndex = EdgeDetect.FindRightForkIndex(cannyBmp);
                    if (rightIndex == -1)
                    {
                        string message = String.Format("Fork is not RightIndex Detect. CamNo : {0}", element.CamNo.ToString());
                        Logger.Write(eLogType.INSPECTION, message, Status.Instance().NowTime);
                        return sectionIndexList;
                    }

                    EdgeElement findLastRightEdgeElement = CornerHelper.GetLastRightEdgeElement(this._finallyEdgeList[this._camCount - 1], this._camCount - 1);

                    Rectangle leftRect = new Rectangle(0, 0, leftIndex - interval, lastSubImage.Height);
                    Rectangle rgihtRect = new Rectangle(rightIndex + interval, 0, lastSubImage.Width - (rightIndex + interval) - EdgeDetect.IgnoreRightXOffsetForEdgeDetect, lastSubImage.Height);

                    int centerRectX = leftIndex + interval + ignoreLeftXFromFork;
                    int centerRectWidth = (rightIndex - interval - ignoreRightXFromFork) - centerRectX;
                    Rectangle centerRect = new Rectangle(centerRectX, 0, centerRectWidth, lastSubImage.Height);

                    ForkImageRoi leftRoi = new ForkImageRoi(false, leftRect);
                    ForkImageRoi rightRoi = new ForkImageRoi(false, rgihtRect);
                    ForkImageRoi centerRoi = new ForkImageRoi(true, centerRect);

                    sectionIndexList.Add(leftRoi);
                    sectionIndexList.Add(rightRoi);
                    sectionIndexList.Add(centerRoi);

                    cannyBmp.Dispose();
                    cropImage.Dispose();
                }
                else
                {
                    Rectangle rect = new Rectangle(0, 0, lastSubImage.Width, lastSubImage.Height);
                    Bitmap cropImage = lastSubImage.Clone(rect, lastSubImage.PixelFormat);

                    Bitmap cannyBmp = HanMechImageHelper.ProcessCanny(cropImage, threshold1, threshold2);

                    int leftIndex = EdgeDetect.FindLeftForkIndex(cannyBmp);
                    if (leftIndex == -1)
                    {
                        string message = String.Format("Fork is not LeftIndex Detect. CamNo : {0}", element.CamNo.ToString());
                        Logger.Write(eLogType.INSPECTION, message, Status.Instance().NowTime);
                        return sectionIndexList;
                    }
                    int rightIndex = EdgeDetect.FindRightForkIndex(cannyBmp);
                    if (rightIndex == -1)
                    {
                        string message = String.Format("Fork is not RightIndex Detect. CamNo : {0}", element.CamNo.ToString());
                        Logger.Write(eLogType.INSPECTION, message, Status.Instance().NowTime);
                        return sectionIndexList;
                    }

                    Rectangle leftRect = new Rectangle(0, 0, leftIndex - interval, lastSubImage.Height);

                    Rectangle rgihtRect = new Rectangle(rightIndex + interval, 0, lastSubImage.Width - (rightIndex + interval), lastSubImage.Height);

                    int centerRectX = leftIndex + interval + ignoreLeftXFromFork;
                    int centerRectWidth = (rightIndex - interval - ignoreRightXFromFork) - centerRectX;
                    Rectangle centerRect = new Rectangle(centerRectX, 0, centerRectWidth, lastSubImage.Height);

                    ForkImageRoi leftRoi = new ForkImageRoi(false, leftRect);
                    ForkImageRoi rightRoi = new ForkImageRoi(false, rgihtRect);
                    ForkImageRoi centerRoi = new ForkImageRoi(true, centerRect);

                    sectionIndexList.Add(leftRoi);
                    sectionIndexList.Add(rightRoi);
                    sectionIndexList.Add(centerRoi);

                    cannyBmp.Dispose();
                    cropImage.Dispose();
                }
            }
            return sectionIndexList;
        }

        private void AIInspection(ref CropInfo info)
        {
            if (Inspection.Instance().MechAI.IsInitialized() == false)
            {
                FormMain.Instance().Log(eLogType.INSPECTION, "AI is not Initialize.", Status.Instance().NowTime, false);
                return;
            }

            byte[] bmpArray = ImageHelper.Convert_Image(info.Image);
            //Mat mat = BitmapConverter.ToMat(info.Image);

            _inspStopWatch.Restart();

            List<MechItem> defectList = Inspection.Instance().MechAI.Process(bmpArray);

            _inspStopWatch.Stop();

            //mat.Dispose();
            eResultConstant aiResult = eResultConstant.OK;

            if (defectList.Count > 0)
            {
                _inspResult.AddAIEdgeDefectList(info.Image, defectList, info.Element, eInspectionType.AI_Edge);
                aiResult = eResultConstant.NG;
            }

            string log = string.Format("AI Edge Inspection." +
                                       " CamNo : {0}" +
                                       " SubNo : {1}" +
                                       " TactTime : {2} ms" +
                                       " Result : {3}"
                                       , info.Element.CamNo, info.Element.SubNo, _inspStopWatch.ElapsedMilliseconds.ToString(), aiResult.ToString());

            FormMain.Instance().Log(eLogType.INSPECTION, log, Status.Instance().NowTime, true);

            foreach (MechItem item in defectList)
            {
                string defectLog = string.Format("Type : {0}, Confidence : {1}, X : {2}, Y : {3}, Width : {4}, Height : {5} ",
                                    item.Type.ToString(), item.Confidence.ToString(), item.X.ToString(), item.Y.ToString(), item.Width.ToString(), item.Height.ToString());
                FormMain.Instance().Log(eLogType.INSPECTION, defectLog, Status.Instance().NowTime, false);
            }
        }

        private void BrokenInspection(ref CropInfo info, bool isForkDetect)
        {
            BrokenParams param = Settings.Instance().AlgorithmSettings.GetBrokenParams(info.Element.Type, isForkDetect);
            
            Inspection.Instance().Algorithms.Broken.SetParams(param);
            _inspStopWatch.Restart();

            List<Rectangle> defectList = Inspection.Instance().Algorithms.Broken.Excute(info.Element, info.Image);

            _inspStopWatch.Stop();

            eResultConstant brokenResult = eResultConstant.OK;

            if (defectList.Count > 0)
            {
                if(isForkDetect)
                {
                    _inspResult.AddRuleEdgeDefectList(info.Image, defectList, info.Element, eInspectionType.ForkBroken, "ForkBroken");
                }
                else
                {
                    _inspResult.AddRuleEdgeDefectList(info.Image, defectList, info.Element, eInspectionType.EdgeBroken, "EdgeBroken");
                }

                brokenResult = eResultConstant.NG;
            }

            string log = "";
            if(isForkDetect)
            {
                log += "Broken Fork Inspection.";
            }
            else
            {
                log += "Broken Edge Inspection.";
            }
            string defectInfo = string.Format(
                                      " CamNo : {0}" +
                                      " SubNo : {1}" +
                                      " Direction : {2}" +
                                      " TactTime : {3} ms" +
                                      " Result : {4}"
                                      , info.Element.CamNo, info.Element.SubNo, info.Element.Type.ToString(), _inspStopWatch.ElapsedMilliseconds.ToString(), brokenResult.ToString());

            log += defectInfo;

            FormMain.Instance().Log(eLogType.INSPECTION, log, Status.Instance().NowTime, true);
        }

        private void ContourInspection(ref CropInfo info, bool isForkDetect)
        {
            ContourParams param = Settings.Instance().AlgorithmSettings.GetContourParams(info.Element.Type, isForkDetect);

            Inspection.Instance().Algorithms.Contour.SetParams(param);

            _inspStopWatch.Restart();

            List<Rectangle> defectList = Inspection.Instance().Algorithms.Contour.Excute(info.Image, info.Element.Type);

            _inspStopWatch.Stop();

            eResultConstant contourResult = eResultConstant.OK;

            if (defectList.Count > 0)
            {
                if(isForkDetect)
                {
                    _inspResult.AddRuleEdgeDefectList(info.Image, defectList, info.Element, eInspectionType.ForkContour, "ForkContour");
                }
                else
                {
                    _inspResult.AddRuleEdgeDefectList(info.Image, defectList, info.Element, eInspectionType.EdgeContour, "EdgeCrack");
                }
                contourResult = eResultConstant.NG;
            }

            string log = "";
            if (isForkDetect)
            {
                log += "Contour Fork Inspection.";
            }
            else
            {
                log += "Contour Edge Inspection.";
            }
            string defectInfo  = string.Format(
                                      " CamNo : {0}" +
                                      " SubNo : {1}" +
                                      " Direction : {2}" +
                                      " TactTime : {3} ms" +
                                      " Result : {4}"
                                      , info.Element.CamNo, info.Element.SubNo,info.Element.Type.ToString(), _inspStopWatch.ElapsedMilliseconds.ToString(), contourResult.ToString());

            log += defectInfo;

            FormMain.Instance().Log(eLogType.INSPECTION, log, Status.Instance().NowTime, true);
        }

        private void CropTopBottomImageInspection()
        {
            for (int camNo = 0; camNo < _finallyEdgeList.Count(); camNo++)
            {
                List<EdgeElement> finallyEdgeList = _finallyEdgeList[camNo];

                foreach (EdgeElement element in finallyEdgeList)
                {
                    if (Status.Instance().ProgramMode != eProgramMode.Inspection)
                        return;
                
                    if (element.Type == eEdgeType.Top)
                    {
                        EdgeAIImageInspection(element);
                        EdgeImageRuleInspectionNonFork(element);
                    }
                    else if(element.Type == eEdgeType.Bottom)
                    {
                        EdgeAIImageInspection(element);

                        if (Settings.Instance().Operation.CamProp[camNo].IsExistFork)
                        {
                            //Fork 존재
                            ForkImageRuleInspection(element);
                        }
                        else
                        {

                            EdgeImageRuleInspectionNonFork(element);
                        }
                    }
                }
            }
        }

        private CropInfo EdgeCropImage(ref EdgeElement element)
        {
            Bitmap cropImage = CropImageSettings(ref element);
            if (cropImage == null)
                return null;
           
            CropInfo info = new CropInfo();
            info.Element = element.Copy();
            info.Image = cropImage;
            return info;
        }

        private Bitmap CropImageSettings(ref EdgeElement element)
        {
            lock (_cropLock)
            {
                try
                {
                    Bitmap curImage = _subImageList[element.CamNo].Images[element.SubNo];
   
                    switch (element.Type)
                    {
                        case eEdgeType.Top:

                            if (element.CropRect.Y < 0) // 엣지가 위쪽에 붙어 있는 경우
                            {
                                if (element.SubNo <= 0) // SubImage 0번에 엣지가 위쪽에 있는 경우// OK
                                {
                                    int overValue = Math.Abs(element.CropRect.Y);
                                    Rectangle curRect = new Rectangle(element.CropRect.X, 0, element.CropRect.Width, element.CropRect.Height - overValue);

                                    element.CropRealPoint.Y = curRect.Y;

                                    return GetCropBitmap(curImage, curRect);
                                }
                                else// OK
                                {
                                    Bitmap prevSubImage = _subImageList[element.CamNo].Images[element.SubNo - 1];
                                    int prevOverValue = Math.Abs(element.CropRect.Y); // 이거 바꿔야함 다른 프로젝트

                                    Rectangle prevRect = new Rectangle(element.CropRect.X, prevSubImage.Height - prevOverValue, element.CropRect.Width, prevOverValue);
                                    Rectangle curRect = new Rectangle(element.CropRect.X, 0, element.CropRect.Width, element.CropRect.Height - prevOverValue);

                                    element.CropRealPoint = new System.Drawing.Point(prevRect.X, (prevSubImage.Height * (element.SubNo - 1)) + prevRect.Y);

                                    Bitmap prevBmp = GetCropBitmap(prevSubImage, prevRect);
                                    if (prevBmp == null)
                                        return null;

                                    Bitmap curBmp = GetCropBitmap(curImage, curRect);
                                    if (curBmp == null)
                                    {
                                        if (prevBmp != null)
                                            prevBmp.Dispose();

                                        return null;
                                    }

                                    Bitmap mergeBmp = new Bitmap(element.CropRect.Width, prevRect.Height + curRect.Height);
                                    using (Graphics g = Graphics.FromImage(mergeBmp))
                                    {
                                        g.DrawImage(prevBmp, new PointF(0, 0));
                                        g.DrawImage(curBmp, new PointF(0, prevBmp.Height));
                                    }
                                    if (prevBmp != null)
                                        prevBmp.Dispose();
                                    if (curBmp != null)
                                        curBmp.Dispose();

                                    prevBmp = null;
                                    curBmp = null;

                                    return mergeBmp;
                                }
                            }
                            else if (element.CropRect.Y + element.CropRect.Height > curImage.Height) // 엣지가 아래쪽에 붙어 있는 경우
                            {
                                if(element.SubNo + 1 > _subImageList[element.CamNo].Images.Count)
                                {
                                    Rectangle curRect = new Rectangle(element.CropRect.X, element.CropRect.Y, element.CropRect.Width, curImage.Height - element.CropRect.Y);
                                    Bitmap nowImage = _subImageList[element.CamNo].Images[element.SubNo];
                                    if (curRect.Y + curRect.Height >= nowImage.Height)
                                    {
                                        curRect.Height = nowImage.Height - curRect.Y;
                                    }
                                    return GetCropBitmap(curImage, curRect);
                                }
                                else // OK
                                {
                                    Bitmap nextImage = _subImageList[element.CamNo].Images[element.SubNo + 1];
                                    if(element.CropRect.Y > nextImage.Height)
                                    {
                                        int newY = element.CropRect.Y - nextImage.Height;
                                        Rectangle nextRect = new Rectangle(element.CropRect.X, newY, element.CropRect.Width, element.CropRect.Height);
                                        return GetCropBitmap(nextImage, nextRect);
                                    }
                                    else
                                    {
                                        int nextOverValue = Math.Abs(element.CropRect.Y + element.CropRect.Height - curImage.Height);

                                        Rectangle curRect = new Rectangle(element.CropRect.X, element.CropRect.Y, element.CropRect.Width, Math.Abs(element.CropRect.Height - nextOverValue));
                                        Rectangle nextRect = new Rectangle(element.CropRect.X, 0, element.CropRect.Width, nextOverValue);

                                        element.CropRealPoint = new System.Drawing.Point(curRect.X, (nextImage.Height * element.SubNo) + curRect.Y);

                                        Bitmap curBmp = GetCropBitmap(curImage, curRect);

                                        if (curBmp == null)
                                            return null;

                                        Bitmap nextBmp = GetCropBitmap(nextImage, nextRect);

                                        if (nextBmp == null)
                                        {
                                            if (curBmp != null)
                                                curBmp.Dispose();
                                            return null;
                                        }

                                        Bitmap mergeBmp = new Bitmap(element.CropRect.Width, curBmp.Height + nextBmp.Height);
                                        using (Graphics g = Graphics.FromImage(mergeBmp))
                                        {
                                            g.DrawImage(curBmp, new PointF(0, 0));
                                            g.DrawImage(nextBmp, new PointF(0, curBmp.Height));
                                        }

                                        if (curBmp != null)
                                            curBmp.Dispose();
                                        if (nextBmp != null)
                                            nextBmp.Dispose();
                                        curBmp = null;
                                        nextBmp = null;

                                        return mergeBmp;
                                    }

                                   
                                }
                            }
                            break;

                        case eEdgeType.Bottom:
                            if (element.CropRect.Y <= 0) // 엣지가 위쪽에 붙어 있는 경우
                            {
                                if (element.SubNo == 0) 
                                {
                                    int overValue = Math.Abs(element.CropRect.Y + element.CropRect.Height - curImage.Height);
                                    Rectangle curRect = new Rectangle(element.CropRect.X, 0, element.CropRect.Width, element.CropRect.Height - overValue);
                                    element.CropRealPoint.Y = curRect.Y;

                                    return GetCropBitmap(curImage, curRect);
                                }
                                else // OK
                                {
                                    if(element.CropRect.Y + element.CropRect.Height >0)
                                    {

                                        Bitmap prevSubImage = _subImageList[element.CamNo].Images[element.SubNo - 1];
                                        int prevCropHeight = Math.Abs(element.CropRect.Y);

                                        Rectangle prevRect = new Rectangle(element.CropRect.X, prevSubImage.Height - prevCropHeight, element.CropRect.Width, prevCropHeight);
                                        Rectangle curRect = new Rectangle(element.CropRect.X, 0, element.CropRect.Width, element.CropRect.Height - prevCropHeight);
                                        element.CropRealPoint = new System.Drawing.Point(prevRect.X, (prevSubImage.Height * (element.SubNo - 1)) + prevRect.Y);

                                        Bitmap prevBmp = GetCropBitmap(prevSubImage, prevRect);

                                        if (prevBmp == null)
                                            return null;

                                        Bitmap curBmp = GetCropBitmap(curImage, curRect);

                                        if (curBmp == null)
                                        {
                                            if (prevBmp != null)
                                                prevBmp.Dispose();

                                            return null;
                                        }

                                        Bitmap mergeBmp = new Bitmap(element.CropRect.Width, prevRect.Height + curRect.Height);
                                        using (Graphics g = Graphics.FromImage(mergeBmp))
                                        {
                                            g.DrawImage(prevBmp, new PointF(0, 0));
                                            g.DrawImage(curBmp, new PointF(0, prevBmp.Height));
                                        }

                                        prevBmp.Dispose();
                                        curBmp.Dispose();
                                        prevBmp = null;
                                        curBmp = null;

                                        return mergeBmp;
                                    }
                                    else
                                    {
                                        int prevCropHeight = Math.Abs(element.CropRect.Y);
                                        Bitmap prevSubImage = _subImageList[element.CamNo].Images[element.SubNo - 1];
                                        Rectangle prevRect = new Rectangle(element.CropRect.X, prevSubImage.Height - prevCropHeight, element.CropRect.Width, element.CropRect.Height);
                                        element.CropRealPoint = new System.Drawing.Point(prevRect.X, (prevSubImage.Height * (element.SubNo - 1)) + prevRect.Y);

                                        Bitmap prevBmp = GetCropBitmap(prevSubImage, prevRect);

                                        return prevBmp;
                                    }
                                }
                            }
                            else if (element.CropRect.Y + element.CropRect.Height > curImage.Height) // 엣지가 아래쪽에 붙어 있는 경우
                            {
                                if (element.SubNo + 1 >= _subImageList[element.CamNo].Images.Count) // OK
                                {
                                    Rectangle curRect = new Rectangle(element.CropRect.X, element.CropRect.Y, element.CropRect.Width, curImage.Height - element.CropRect.Y);
                                    element.CropRealPoint.Y = (element.OrgImageHeight * element.SubNo) + curRect.Y;

                                    return GetCropBitmap(curImage, curRect);
                                }
                                else // OK
                                {
                                    Bitmap nextImage = _subImageList[element.CamNo].Images[element.SubNo + 1];
                                    int nextCropHeight = Math.Abs(element.CropRect.Y + element.CropRect.Height - curImage.Height);

                                    Rectangle curRect = new Rectangle(element.CropRect.X, element.CropRect.Y, element.CropRect.Width, element.CropRect.Height - nextCropHeight);
                                    Rectangle nextRect = new Rectangle(element.CropRect.X, 0, element.CropRect.Width, nextCropHeight);

                                    element.CropRealPoint = new System.Drawing.Point(curRect.X, (nextImage.Height * element.SubNo) + curRect.Y);

                                    Bitmap curBmp = GetCropBitmap(curImage, curRect);

                                    if (curBmp == null)
                                        return null;

                                    Bitmap nextBmp = GetCropBitmap(nextImage, nextRect);

                                    if (nextBmp == null)
                                    {
                                        if (curBmp != null)
                                            curBmp.Dispose();
                                        return null;
                                    }

                                    Bitmap mergeBmp = new Bitmap(element.CropRect.Width, curBmp.Height + nextBmp.Height);
                                    using (Graphics g = Graphics.FromImage(mergeBmp))
                                    {
                                        g.DrawImage(curBmp, new PointF(0, 0));
                                        g.DrawImage(nextBmp, new PointF(0, curBmp.Height));
                                    }

                                    curBmp.Dispose();
                                    nextBmp.Dispose();
                                    curBmp = null;
                                    nextBmp = null;
                                    return mergeBmp;
                                }

                            }
                            break;

                        case eEdgeType.Left:
                            break;
                        case eEdgeType.Right:
                        case eEdgeType.None:
                        default:
                            break;
                    }

                    if (element.CropRect.X < 0)
                    {
                        int value = Math.Abs(element.CropRect.X);
                        element.CropRect.X = 0;
                        element.CropRect.Width -= value;
                        element.CropRealPoint.X = 0;
                    }
                    if(element.CropRect.Y < 0)
                    {
                        int value = Math.Abs(element.CropRect.Y);
                        element.CropRect.Y = 0;
                        element.CropRect.Height -= value;
                        element.CropRealPoint.Y += value;
                    }
                    if (element.CropRect.X + element.CropRect.Width > curImage.Width)
                    {
                        element.CropRect.Width = curImage.Width - element.CropRect.X;
                    }
                    if(element.CropRect.Y + element.CropRect.Height > curImage.Height)
                    {
                        element.CropRect.Height = curImage.Height - element.CropRect.Y;
                    }

                    return GetCropBitmap(curImage, element.CropRect);
                }
                catch (Exception err)
                {
                    Console.WriteLine(element.Type.ToString() + " " + element.CamNo.ToString() + " " + element.SubNo.ToString());
                    Logger.WriteException(eLogType.ERROR, err);
                    return null;
                }
            }
        }

        private Bitmap GetCropBitmap(Bitmap sourceImage, Rectangle rect)
        {
            if (rect.X < 0)
            {
                int value = Math.Abs(rect.X);
                rect.X = 0;
                rect.Width -= value;
            }
            if(rect.Y < 0)
            {
                int value = Math.Abs(rect.Y);
                rect.Y = 0;
                rect.Height -= value;
            }
            if (rect.X + rect.Width > sourceImage.Width)
            {
                rect.Width = sourceImage.Width - rect.X;
            }
            if (rect.Y + rect.Height > sourceImage.Height)
            {
                rect.Height = sourceImage.Height - rect.Y;
            }

            if (IsEnableRect(rect) == false)
                return null;

            if (IsCotainRectInImage(sourceImage, rect))
            {
                return (Bitmap)sourceImage.Clone(rect, sourceImage.PixelFormat);
            }
            else
            {
                return null;
            }
        }

        private bool IsCotainRectInImage(Bitmap sourceImage, Rectangle overwrapRect)
        {
            if (sourceImage == null)
                return false;
            if (overwrapRect.Width == 0 || overwrapRect.Height == 0)
                return false;
            Rectangle rect = new Rectangle(0, 0, sourceImage.Width, sourceImage.Height);
            return rect.Contains(overwrapRect);
        }

        private bool IsEnableRect(Rectangle rect)
        {
            if (rect.Width == 0 || rect.Height == 0)
                return false;

            return true;
        }

        private void SetCornerRect()
        {
            for (int i = 0; i < _camCount; i++)
            {
                if (i == 0) // Left
                {
                    //LeftTop
                    System.Drawing.Point leftTop = new System.Drawing.Point();

                    EdgeElement firstLeftElement = CornerHelper.GetFirstLeftEdgeElement(this._finallyEdgeList[0], 0);
                    if (firstLeftElement != null)
                        leftTop.X = firstLeftElement.Index;

                    EdgeElement topElement = CornerHelper.GetTopEdgeElement(this._finallyEdgeList[0], 0);
                    if (topElement != null)
                        leftTop.Y = (topElement.SubNo * topElement.OrgImageHeight) + topElement.Index;

                    _inspResult.Corner.LeftTopRealPoint = new System.Drawing.Point(leftTop.X, leftTop.Y);
                    _inspResult.Corner.LeftTopCornerRect = CornerHelper.GetCornerRectangle(leftTop, Settings.Instance().Operation.LeftTopCornerRectSize);

                    Logger.Write(eLogType.INSPECTION, "[LTCorner : " + _inspResult.Corner.LeftTopRealPoint.ToString() + " ]", Status.Instance().NowTime);

                    //LeftBottom
                    System.Drawing.Point leftBottom = new System.Drawing.Point();

                    EdgeElement lastLeftElement = CornerHelper.GetLastLeftEdgeElement(this._finallyEdgeList[0], 0);
                    if (lastLeftElement != null)
                        leftBottom.X = lastLeftElement.Index;

                    EdgeElement bottomElement = CornerHelper.GetBottomEdgeElement(this._finallyEdgeList[0], 0);
                    if (bottomElement != null)
                        leftBottom.Y = (bottomElement.SubNo * bottomElement.OrgImageHeight) + bottomElement.Index;

                    _inspResult.Corner.LeftBottomRealPoint = new System.Drawing.Point(leftBottom.X, leftBottom.Y);
                    _inspResult.Corner.LeftBottomCornerRect = CornerHelper.GetCornerRectangle(leftBottom, Settings.Instance().Operation.LeftBottomCornerRectSize);

                    Logger.Write(eLogType.INSPECTION, "[LBCorner : " + _inspResult.Corner.LeftBottomRealPoint.ToString() + " ]", Status.Instance().NowTime);
                }
                else if (i == _camCount - 1) // Right
                {
                    //RightTop
                    System.Drawing.Point rightTop = new System.Drawing.Point();

                    EdgeElement firstRightElement = CornerHelper.GetFirstRightEdgeElement(this._finallyEdgeList[this._camCount - 1], this._camCount - 1);
                    if (firstRightElement != null)
                        rightTop.X = firstRightElement.Index;

                    EdgeElement topElement = CornerHelper.GetTopEdgeElement(this._finallyEdgeList[this._camCount - 1], this._camCount - 1);
                    if (topElement != null)
                        rightTop.Y = (topElement.SubNo * topElement.OrgImageHeight) + topElement.Index;

                    _inspResult.Corner.RightTopRealPoint = new System.Drawing.Point(rightTop.X, rightTop.Y);
                    _inspResult.Corner.RightTopCornerRect = CornerHelper.GetCornerRectangle(rightTop, Settings.Instance().Operation.RightTopCornerRectSize);

                    Logger.Write(eLogType.INSPECTION, "[RTCorner : " + _inspResult.Corner.RightTopRealPoint.ToString() + " ]", Status.Instance().NowTime);

                    //RightBottom
                    System.Drawing.Point rightBottom = new System.Drawing.Point();
                    EdgeElement lastRightElement = CornerHelper.GetLastRightEdgeElement(this._finallyEdgeList[this._camCount - 1], this._camCount - 1);

                    if (lastRightElement != null)
                        rightBottom.X = lastRightElement.Index;

                    EdgeElement bottomElement = CornerHelper.GetBottomEdgeElement(this._finallyEdgeList[this._camCount - 1], this._camCount - 1);
                    if (bottomElement != null)
                        rightBottom.Y = (bottomElement.SubNo * bottomElement.OrgImageHeight) + bottomElement.Index;

                    _inspResult.Corner.RightBottomRealPoint = new System.Drawing.Point(rightBottom.X, rightBottom.Y);
                    _inspResult.Corner.RightBottomCornerRect = CornerHelper.GetCornerRectangle(rightBottom, Settings.Instance().Operation.RightBottomCornerRectSize);

                    Logger.Write(eLogType.INSPECTION, "[RBCorner : " + _inspResult.Corner.RightBottomRealPoint.ToString() + " ]", Status.Instance().NowTime);
                }
            }

            //TEST_210128_S
            if (Settings.Instance().Operation.OriginDirection == eOriginDirection.LeftTop)
            {
                Status.Instance().cornerPoint = _inspResult.Corner.LeftTopRealPoint;
            }
            else if (Settings.Instance().Operation.OriginDirection == eOriginDirection.LeftBottom)
            {
                Status.Instance().cornerPoint = _inspResult.Corner.LeftBottomRealPoint;
            }
            else if (Settings.Instance().Operation.OriginDirection == eOriginDirection.RightTop)
            {
                Status.Instance().cornerPoint = _inspResult.Corner.RightTopRealPoint;
            }
            else if (Settings.Instance().Operation.OriginDirection == eOriginDirection.RightBottom)
            {
                Status.Instance().cornerPoint = _inspResult.Corner.RightBottomRealPoint;
            }
            Status.Instance().CornerDirection = Settings.Instance().Operation.OriginDirection;
            //TEST_210128_E
        }

        private void StartImageProcess()
        {
            Thread th = new Thread(ImageProcess);
            th.Start();
        }

        private void ImageProcess()
        {
            _isImageProcessingCompleted = false;

            MergeImage();

            if (Settings.Instance().Operation.DrawCorner)
                DrawCorner();

            bool isDefect = false;
            Bitmap[] orgDisplayImageList = GetOrgDisplayImageList(ref isDefect);

            MakeDisplayImage(orgDisplayImageList, isDefect);

            _isImageProcessingCompleted = true;
        }

        private Bitmap[] GetOrgDisplayImageList(ref bool isDefect)
        {
            Bitmap[] orgDisplayList = null;
            if (_inspResult.FinallyDefectList.Count > 0)
            {
                _drawDefectImageList = GetDrawDefectImage();
                if (_drawDefectImageList != null)
                {
                    orgDisplayList = _drawDefectImageList;
                    isDefect = true;
                }
                else
                {
                    orgDisplayList = _mergeImageList;
                    isDefect = false;
                }
            }
            else
            {
                orgDisplayList = _mergeImageList;
                isDefect = false;
            }
            return orgDisplayList;
        }

        public void DrawDefect()
        {
            foreach (Defect defect in _inspResult.FinallyDefectList)
            {
                if (_mergeImageList[defect.CamNo] != null)
                {
                    Rectangle defectRoi = new Rectangle((int)defect.BoundingPosX, (int)defect.BoundingPosY, (int)defect.BoundingWidth, (int)defect.BoundingHeight);
                    ImageHelper.DrawRectangle(ref _mergeImageList[defect.CamNo], defectRoi, 3);
                }
            }
        }

        public Bitmap[] GetDrawDefectImage()
        {
            if(_inspResult.FinallyDefectList.Count >0)
            {
                Bitmap[] bmpArray = new Bitmap[_camCount];
                for (int camNo = 0; camNo < _camCount; camNo++)
                {
                    bmpArray[camNo] = new Bitmap(_mergeImageList[camNo].Width, _mergeImageList[camNo].Height, PixelFormat.Format24bppRgb);
                    Font font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    Pen pen = new Pen(Color.Red);
                    using (Graphics g = Graphics.FromImage(bmpArray[camNo]))
                    {
                        g.DrawImage(_mergeImageList[camNo], new PointF(0, 0));
                        foreach (Defect defect in _inspResult.FinallyDefectList)
                        {
                            if(defect.CamNo == camNo)
                            {
                                Rectangle defectRoi = new Rectangle((int)defect.BoundingPosX, (int)defect.BoundingPosY, (int)defect.BoundingWidth, (int)defect.BoundingHeight);
                                string message = string.Format("Type : {0}, X : {1}, Y : {2}, Width : {3}, Height : {4}, Confidence : {5:0.000}, InspType : {6}",
                                                            defect.AlarmType, defectRoi.X, defectRoi.Y, defectRoi.Width, defectRoi.Height, defect.Confidence, defect.InspectionType);

                                int stringHeight = (int)g.MeasureString(message, font).Height;

                                g.DrawRectangle(pen, defectRoi);
                                g.DrawString(message, font, Brushes.Red, new PointF(defectRoi.X, defectRoi.Y - stringHeight));
                            }
                        }
                    }
                }
                return bmpArray;
            }
            return null;
        }

        public void UpdateDisplay(Bitmap[] orgImageArray)
        {
            Bitmap[] displayImageArray = new Bitmap[orgImageArray.Count()];
            double ratio = 0;

            for (int i = 0; i < orgImageArray.Count(); i++)
            {
                int newWidth = FormMain.Instance().DisplayListControl.GetDisplayBoxWidth(i);
                ratio = (double)orgImageArray[i].Width / (double)newWidth;
                int newHeight = (int)((double)orgImageArray[i].Height / ratio);

                displayImageArray[i] = new Bitmap(orgImageArray[i], new System.Drawing.Size(newWidth, newHeight));
            }

            FormMain.Instance().DisplayListControl.DisplayImageUpdate(displayImageArray, ratio);
        }

        private void DrawCorner()
        {
            for (int camNo = 0; camNo < _camCount; camNo++)
            {
                if (_mergeImageList[camNo] == null)
                    continue;
                if (camNo == 0)
                {
                    ImageHelper.DrawRectangle(ref _mergeImageList[camNo], _inspResult.Corner.LeftTopCornerRect, 3);
                    ImageHelper.DrawRectangle(ref _mergeImageList[camNo], _inspResult.Corner.LeftBottomCornerRect, 3);
                }
                if (camNo == _camCount - 1)
                {
                    ImageHelper.DrawRectangle(ref _mergeImageList[camNo], _inspResult.Corner.RightTopCornerRect, 3);
                    ImageHelper.DrawRectangle(ref _mergeImageList[camNo], _inspResult.Corner.RightBottomCornerRect, 3);
                }
            }
        }

        private void MergeImage()
        {
            try
            {
                int imageCount = GetMinImageCount(); // 카메라 별 SubImageList 중 가장 작은 리스트 가져오기

                for (int camNo = 0; camNo < _camCount; camNo++)
                {
                    Machine.Instance().CameraManager.SetMergeImageCount(imageCount);

                    if (_isImageLoadMode)
                    {
                        if (_mergeImageList[camNo] != null)
                        {
                            _mergeImageList[camNo].Dispose();
                            _mergeImageList[camNo] = null;
                        }

                        _mergeImageList[camNo] = _loadHelper[camNo].GetMergeImage(_subImageList[camNo].Images, imageCount);
                    }
                    else
                    {
                        _mergeImageList[camNo] = Machine.Instance().CameraManager.GetMergeImage(camNo);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
            
        }

        private int GetMinImageCount()
        {
            int minSubImageCount = 9999;
            for (int camNo = 0; camNo < _camCount; camNo++)
            {
                int imageCount = _subImageList[camNo].Images.Count;
                if (minSubImageCount >= imageCount)
                    minSubImageCount = imageCount;
            }
            return minSubImageCount;
        }

        private void MakeDisplayImage(Bitmap[] OrgBmpArray, bool isDefect)
        {
            List<Bitmap> thumbnailList = new List<Bitmap>();
            int thumbnailRatio = Settings.Instance().Operation.ThumbnailRatio;

            _pnlDisplayImageList = new Bitmap[OrgBmpArray.Count()];

            int standardTopEdgeIndex = CornerHelper.GetMaxTopEdgeIndex(_finallyEdgeList);
            //int standardTopEdgeIndex = CornerHelper.GetMinTopEdgeIndex(_finallyEdgeList);
            //int standardTopEdgeIndex = 500;
            for (int i = 0; i < OrgBmpArray.Count(); i++)
            {
                Bitmap mergeOrgImage = OrgBmpArray[i];
               
                if (mergeOrgImage == null)
                    continue;
                //이미지 Move
                int topIndex = 0;
                if (standardTopEdgeIndex == int.MinValue)
                {
                    topIndex = 0;
                }
                else
                {
                    EdgeElement topElement = CornerHelper.GetTopEdgeElement(_finallyEdgeList[i], i);
                    if(topElement == null)
                    {
                        topIndex = 0;
                    }
                    else
                    {
                        topIndex = (topElement.SubNo * topElement.OrgImageHeight) + topElement.Index;
                        //topIndex = 0;
                    }
                }
               // mergeOrgImage.Save(@"D:\org.bmp");

                Bitmap moveDisplayImage = ImageHelper.MoveImage(mergeOrgImage, topIndex, standardTopEdgeIndex);
               // moveDisplayImage.Save(@"D:\display.bmp");
                int newWidth = FormMain.Instance().DisplayListControl.GetDisplayBoxWidth(i);
                _pnlDisplayRatio = (double)moveDisplayImage.Width / (double)newWidth;
                int newHeight = (int)((double)moveDisplayImage.Height / _pnlDisplayRatio);

                _pnlDisplayImageList[i] = new Bitmap(moveDisplayImage, new System.Drawing.Size(newWidth, newHeight));

                thumbnailList.Add((Bitmap)moveDisplayImage.GetThumbnailImage(moveDisplayImage.Width / thumbnailRatio,
                                                        moveDisplayImage.Height / thumbnailRatio, null, IntPtr.Zero));

                moveDisplayImage.Dispose();

            }

            if (thumbnailList.Count != 0)
            {
                _thumbnailImage = MakeThumbnailImage(thumbnailList);
            }
        }

        private Bitmap MakeThumbnailImage(List<Bitmap> imageList)
        {
            try
            {
                Bitmap thumbnailImage = new Bitmap(imageList[0].Width * imageList.Count, imageList[0].Height, imageList[0].PixelFormat);

                int width = imageList[0].Width;

                using (Graphics g = Graphics.FromImage(thumbnailImage))
                {
                    for (int i = 0; i < imageList.Count; i++)
                    {
                        g.DrawImage(imageList[i], width * i, 0);
                    }
                }

                return thumbnailImage;
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                return null;
            }
        }

        private void SaveImage()
        {
            try
            {
                string path = _inspResult.SaveImagePath;
                string glassID = _inspResult.GlassID;
                if (path == "")
                    return;
                Utility.CreateDir(path);

                if (this._thumbnailImage != null)
                {
                    if(this._thumbnailImage.Height >=65535)
                    {
                        string thumbnailFilePath = Path.Combine(path, "Thumbnail.bmp");
                        this._thumbnailImage.Save(thumbnailFilePath, ImageFormat.Bmp);
                    }
                    else
                    {
                        string thumbnailFilePath = Path.Combine(path, "Thumbnail.jpeg");
                        this._thumbnailImage.Save(thumbnailFilePath, ImageFormat.Jpeg);
                    }
                }

                for (int camNo = 0; camNo < _camCount; camNo++)
                {
                    //MergeImage
                    string mergeFilePath = Path.Combine(path, String.Format(@"Cam_{0}", camNo));
                    if(_mergeImageList[camNo] != null)
                    {
                        if(_mergeImageList[camNo].Height >= 65535)
                        {
                            mergeFilePath += ".png";
                            Bitmap maxImage = _mergeImageList[camNo].Clone(new Rectangle(0, 0, _mergeImageList[camNo].Width, 65535), _mergeImageList[camNo].PixelFormat);

                            maxImage.Save(mergeFilePath, ImageFormat.Png);

                            maxImage.Dispose();
                        }
                        else
                        {
                            if (Settings.Instance().Operation.SaveMergeImageType == eImageType.Bmp)
                            {
                                mergeFilePath += ".bmp";
                                _mergeImageList[camNo].Save(mergeFilePath, ImageFormat.Bmp);
                            }
                            else if (Settings.Instance().Operation.SaveMergeImageType == eImageType.Jpeg)
                            {
                                mergeFilePath += ".jpeg";
                                _mergeImageList[camNo].Save(mergeFilePath, ImageFormat.Jpeg);
                            }
                        }
                    }

                    //SubImage
                    if (Settings.Instance().Operation.SaveSubImage)
                    {
                        if (_subImageList[camNo].Images.Count <= 0)
                            continue;

                        string subImageDir = Path.Combine(path, "SubImages");
                        Utility.CreateDir(subImageDir);

                        List<Bitmap> subImageList = _subImageList[camNo].Images;

                        for (int subNo = 0; subNo < subImageList.Count; subNo++)
                        {
                            string SubFilePath = Path.Combine(subImageDir, _inspResult.GlassID + "_" + camNo.ToString() + "_" + subNo.ToString());

                            if (Settings.Instance().Operation.SaveSubImageType == eImageType.Bmp)
                            {
                                SubFilePath += ".bmp";
                                subImageList[subNo].Save(SubFilePath, ImageFormat.Bmp);
                            }
                            else if (Settings.Instance().Operation.SaveSubImageType == eImageType.Jpeg)
                            {
                                SubFilePath += ".jpeg";
                                subImageList[subNo].Save(SubFilePath, ImageFormat.Jpeg);
                            }
                            else { }
                        }
                    }
                }

                //Draw Defect Image
                if(_drawDefectImageList != null)
                {
                    for (int camNo = 0; camNo < _drawDefectImageList.Count(); camNo++)
                    {
                        if(_drawDefectImageList[camNo] != null)
                        {
                            string saveFolderDir = Path.Combine(path, "..","NG", glassID);
                            Utility.CreateDir(saveFolderDir);

                            if(_drawDefectImageList[camNo].Height >= 65535)
                            {
                                string filePath = Path.Combine(saveFolderDir, string.Format("Cam_{0}.bmp", camNo));
                                _drawDefectImageList[camNo].Save(filePath, ImageFormat.Bmp);
                            }
                            else
                            {
                                string filePath = Path.Combine(saveFolderDir, string.Format("Cam_{0}.jpeg", camNo));
                                _drawDefectImageList[camNo].Save(filePath, ImageFormat.Jpeg);
                            }
                            _drawDefectImageList[camNo].Dispose();
                        }
                    }
                }
                //Crop
                if (Settings.Instance().Operation.SaveCropImage)
                {
                    SaveCropAIImage(path);
                    SaveCropBrokenImage(path);
                    SaveCropContourImage(path);
                }

                // Save Defect From InspectionObjectList
                foreach (InspectionObject info in _inspResult.InspObjectList)
                {
                    if (info.IsExistDefect)
                    {
                        if (info.Image == null)
                            continue;

                        if (info.InspType == eInspectionType.AI_Front) // AI 전면
                        {
                            string AIFrontDefectDir = Path.Combine(path, "AIDefect",info.InspType.ToString());

                            Utility.CreateDir(AIFrontDefectDir);

                            string defectFilePath = Path.Combine(AIFrontDefectDir, String.Format(@"{0}_Cam_{1}_Sub_{2}.bmp", _inspResult.GlassID, info.CamNo, info.SubNo));
                            info.Image.Save(defectFilePath, ImageFormat.Bmp);
                        }
                        else if (info.InspType == eInspectionType.AI_Edge) // AI Edge
                        {
                            string AIEdgeDefectDir = Path.Combine(path, "AIDefect", info.InspType.ToString());

                            AIEdgeDefectDir = GetDirectionPath(AIEdgeDefectDir, info.InspDirection);
                            Utility.CreateDir(AIEdgeDefectDir);

                            string cropFilePath = Path.Combine(AIEdgeDefectDir, String.Format(@"{0}_Cam_{1}_Sub_{2}_{3}.bmp", _inspResult.GlassID, info.CamNo, info.SubNo, info.InspDirection));
                            info.Image.Save(cropFilePath, ImageFormat.Bmp);
                        }
                        else if (info.InspType == eInspectionType.EdgeBroken || info.InspType == eInspectionType.EdgeContour
                            || info.InspType == eInspectionType.ForkBroken || info.InspType == eInspectionType.ForkContour) // Rule
                        {
                            string ruleDefectDir = Path.Combine(path, "RuleDefect", info.InspType.ToString());

                            ruleDefectDir = GetDirectionPath(ruleDefectDir, info.InspDirection);
                            Utility.CreateDir(ruleDefectDir);

                            string cropFilePath = Path.Combine(ruleDefectDir, String.Format(@"{0}_Cam_{1}_Sub_{2}_{3}_{4}.bmp", _inspResult.GlassID, info.CamNo, info.SubNo, info.InspDirection, info.InspType));
                            info.Image.Save(cropFilePath, ImageFormat.Bmp);
                        }
                        else { }
                    }
                }
                Console.WriteLine("Save Done");
                FormMain.Instance().Log(eLogType.SEQ, "Image Save Done."+ "(" + glassID + ")", Status.Instance().NowTime);
                FormMain.Instance().DefectInformationControl.ActiveDataGridView(true);
            }
            catch (Exception err)
            {
                FormMain.Instance().DefectInformationControl.ActiveDataGridView(true);
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private string GetDirectionPath(string path, eEdgeType type)
        {
            if (type == eEdgeType.Left)
            {
                return Path.Combine(path, "Left");
            }
            else if (type == eEdgeType.Right)
            {
                return Path.Combine(path, "Right");
            }
            else if (type == eEdgeType.Top)
            {
                return Path.Combine(path, "Top");
            }
            else if (type == eEdgeType.Bottom)
            {
                return Path.Combine(path, "Bottom");
            }
            else
            {
                return path;
            }
        }

        private bool IsEdgeInspCompleted()
        {
            bool ret = _isAITopBottomInspCompleted && _isAILeftRightInspCompleted 
                                && _isRuleTopBottomEdgeInspCompleted && _isRuleLeftRightEdgeInspCompleted;
            return ret;
        }

        private void SaveCropAIImage(string path)
        {
            foreach (CropInfo info in _inspResult.CropAIImageList)
            {
                if (info.Image == null)
                    continue;

                string cropImageDir = Path.Combine(path, "CropImages", "AI");
                Utility.CreateDir(cropImageDir);

                cropImageDir = GetDirectionPath(cropImageDir, info.Element.Type);

                Utility.CreateDir(cropImageDir);

                string cropFilePath = Path.Combine(cropImageDir, String.Format(@"{0}_Cam_{1}_Sub_{2}_{3}", _inspResult.GlassID, info.Element.CamNo, info.Element.SubNo, info.Element.Type));
                if (Settings.Instance().Operation.SaveCropImageType == eImageType.Bmp)
                {
                    cropFilePath += ".bmp";
                    info.Image.Save(cropFilePath, ImageFormat.Bmp);
                }
                else if (Settings.Instance().Operation.SaveCropImageType == eImageType.Jpeg)
                {
                    cropFilePath += ".jpeg";
                    info.Image.Save(cropFilePath, ImageFormat.Jpeg);
                }
                else { }
            }
        }

        private void SaveCropBrokenImage(string path)
        {
            foreach (CropInfo info in _inspResult.CropBrokenImageListNonFork)
            {
                if (info.Image == null)
                    continue;

                string cropImageDir = Path.Combine(path, "CropImages", "BrokenNonFork");
                Utility.CreateDir(cropImageDir);
                
                cropImageDir = GetDirectionPath(cropImageDir, info.Element.Type);

                Utility.CreateDir(cropImageDir);

                string cropFilePath = Path.Combine(cropImageDir, String.Format(@"{0}_Cam_{1}_Sub_{2}_{3}_{4}",
                    _inspResult.GlassID, info.Element.CamNo, info.Element.SubNo, info.Element.Type, info.Element.CropRealPoint.ToString()));
                if (Settings.Instance().Operation.SaveCropImageType == eImageType.Bmp)
                {
                    cropFilePath += ".bmp";
                    info.Image.Save(cropFilePath, ImageFormat.Bmp);
                }
                else if (Settings.Instance().Operation.SaveCropImageType == eImageType.Jpeg)
                {
                    cropFilePath += ".jpeg";
                    info.Image.Save(cropFilePath, ImageFormat.Jpeg);
                }
                else { }
            }

            foreach (CropInfo info in _inspResult.CropBrokenImageListFork)
            {
                if (info.Image == null)
                    continue;

                string cropImageDir = Path.Combine(path, "CropImages", "BrokenFork");
                Utility.CreateDir(cropImageDir);

                cropImageDir = GetDirectionPath(cropImageDir, info.Element.Type);

                Utility.CreateDir(cropImageDir);

                string cropFilePath = Path.Combine(cropImageDir, String.Format(@"{0}_Cam_{1}_Sub_{2}_{3}_{4}",
                    _inspResult.GlassID, info.Element.CamNo, info.Element.SubNo, info.Element.Type, info.Element.CropRealPoint.ToString()));
                if (Settings.Instance().Operation.SaveCropImageType == eImageType.Bmp)
                {
                    cropFilePath += ".bmp";
                    info.Image.Save(cropFilePath, ImageFormat.Bmp);
                }
                else if (Settings.Instance().Operation.SaveCropImageType == eImageType.Jpeg)
                {
                    cropFilePath += ".jpeg";
                    info.Image.Save(cropFilePath, ImageFormat.Jpeg);
                }
                else { }
            }
        }

        private void SaveCropContourImage(string path)
        {
            foreach (CropInfo info in _inspResult.CropContourImageListNonFork)
            {
                if (info.Image == null)
                    continue;

                string cropImageDir = Path.Combine(path, "CropImages", "ContourNonFork");
                Utility.CreateDir(cropImageDir);

                cropImageDir = GetDirectionPath(cropImageDir, info.Element.Type);

                Utility.CreateDir(cropImageDir);

                string cropFilePath = Path.Combine(cropImageDir, String.Format(@"{0}_Cam_{1}_Sub_{2}_{3}_{4}",
                    _inspResult.GlassID, info.Element.CamNo, info.Element.SubNo, info.Element.Type, info.Element.CropRealPoint.ToString()));
                if (Settings.Instance().Operation.SaveCropImageType == eImageType.Bmp)
                {
                    cropFilePath += ".bmp";
                    info.Image.Save(cropFilePath, ImageFormat.Bmp);
                }
                else if (Settings.Instance().Operation.SaveCropImageType == eImageType.Jpeg)
                {
                    cropFilePath += ".jpeg";
                    info.Image.Save(cropFilePath, ImageFormat.Jpeg);
                }
                else { }
            }

            foreach (CropInfo info in _inspResult.CropContourImageListFork)
            {
                if (info.Image == null)
                    continue;

                string cropImageDir = Path.Combine(path, "CropImages", "ContourFork");
                Utility.CreateDir(cropImageDir);

                cropImageDir = GetDirectionPath(cropImageDir, info.Element.Type);

                Utility.CreateDir(cropImageDir);

                string cropFilePath = Path.Combine(cropImageDir, String.Format(@"{0}_Cam_{1}_Sub_{2}_{3}_{4}", 
                    _inspResult.GlassID, info.Element.CamNo, info.Element.SubNo, info.Element.Type, info.Element.CropRealPoint.ToString()));
                if (Settings.Instance().Operation.SaveCropImageType == eImageType.Bmp)
                {
                    cropFilePath += ".bmp";
                    info.Image.Save(cropFilePath, ImageFormat.Bmp);
                }
                else if (Settings.Instance().Operation.SaveCropImageType == eImageType.Jpeg)
                {
                    cropFilePath += ".jpeg";
                    info.Image.Save(cropFilePath, ImageFormat.Jpeg);
                }
                else { }
            }
        }
    }
}