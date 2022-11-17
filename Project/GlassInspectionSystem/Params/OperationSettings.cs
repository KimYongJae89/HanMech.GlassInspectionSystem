using Device.Camera;
using GlassInspectionSystem.Class;
using Device.PLC;
using HMechUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using enumType;
using Device.DIO;

namespace GlassInspectionSystem.Params
{
    public class OperationSettings
    {
        public List<CameraProperty> CamProp = new List<CameraProperty>();

        private int _camCount = 4;

        public int CamCount
        {
            get { return _camCount; }
            set { _camCount = value; }
        }

        private eCameraType _cameraType = eCameraType.None;

        public eCameraType CameraType
        {
            get { return _cameraType; }
            set { _cameraType = value; }
        }

        private ePLCType _plcType = ePLCType.None;

        public ePLCType PlcType
        {
            get { return _plcType; }
            set { _plcType = value; }
        }

        private eInspectionTriggerType _inspectionTriggerType = eInspectionTriggerType.None;

        public eInspectionTriggerType InspectionTriggerType
        {
            get { return _inspectionTriggerType; }
            set { _inspectionTriggerType = value; }
        }

        private int _startGrabDelay = 1000;

        public int StartGrabDelay
        {
            get { return _startGrabDelay; }
            set { _startGrabDelay = value; }
        }


        private int _endGrabDelay = 1000;

        public int EndGrabDelay
        {
            get { return _endGrabDelay; }
            set { _endGrabDelay = value; }
        }

        private eDIOBoardType _dioBoardType = eDIOBoardType.TMC;

        public eDIOBoardType DioBoardType
        {
            get { return _dioBoardType; }
            set { _dioBoardType = value; }
        }

        private int _dioCardNo = 0;
        public int DioCardNo
        {
            get { return _dioCardNo; }
            set { _dioCardNo = value; }
        }

        private string _plcIPAddress = "0.0.0.0";

        public string PlcIPAddress
        {
            get { return _plcIPAddress; }
            set { _plcIPAddress = value; }
        }

        private int _plcPortNumber = 5050;

        public int PlcPortNumber
        {
            get { return _plcPortNumber; }
            set { _plcPortNumber = value; }
        }

        private eLineRateType _lineRateType = eLineRateType.None;

        public eLineRateType LineRateType
        {
            get { return _lineRateType; }
            set { _lineRateType = value; }
        }

        private double _constantVel = 250;

        public double ConstantVel    // 정속 구간 속도
        {
            get { return _constantVel; }
            set { _constantVel = value; }
        }

        private double _slowVel = 30;

        public double SlowVel      // 감속 구간 속도
        {
            get { return _slowVel; }
            set { _slowVel = value; }
        }

        private eLightType _lightType = eLightType.None;

        public eLightType LightType
        {
            get { return _lightType; }
            set { _lightType = value; }
        }

        private eSerialLightType _serialLightType = eSerialLightType.None;
        public eSerialLightType SerialLightType
        {
            get { return _serialLightType; }
            set { _serialLightType = value; }
        }

        private string _comPort = "";

        public string ComPort
        {
            get { return _comPort; }
            set { _comPort = value; }
        }

        private int _baudRate = 9600;

        public int BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        private int _lightValue = 100;

        public int LightValue
        {
            get { return _lightValue; }
            set { _lightValue = value; }
        }

        private bool _useAi = false;

        public bool UseAi
        {
            get { return _useAi; }
            set { _useAi = value; }
        }

        private eAIInspectionType _aiType = eAIInspectionType.None;

        public eAIInspectionType AiType
        {
            get { return _aiType; }
            set { _aiType = value; }
        }

        private bool _useEdgeBrokenAlgorithm = false;

        public bool UseEdgeBrokenAlgorithm
        {
            get { return _useEdgeBrokenAlgorithm; }
            set { _useEdgeBrokenAlgorithm = value; }
        }

        private bool _useEdgeContourAlgorithm = false;

        public bool UseEdgeContourAlgorithm
        {
            get { return _useEdgeContourAlgorithm; }
            set { _useEdgeContourAlgorithm = value; }
        }

        private bool _useForkBrokenAlgorithm = false;

        public bool UseForkBrokenAlgorithm
        {
            get { return _useForkBrokenAlgorithm; }
            set { _useForkBrokenAlgorithm = value; }
        }

        private bool _useForkContourAlgorithm = false;

        public bool UseForkContourAlgorithm
        {
            get { return _useForkContourAlgorithm; }
            set { _useForkContourAlgorithm = value; }
        }

        private int _leftTopCornerRectSize = 200;

        public int LeftTopCornerRectSize
        {
            get { return _leftTopCornerRectSize; }
            set { _leftTopCornerRectSize = value; }
        }

        private int _rightTopCornerRectSize = 200;

        public int RightTopCornerRectSize
        {
            get { return _rightTopCornerRectSize; }
            set { _rightTopCornerRectSize = value; }
        }

        private int _leftBottomCornerRectSize = 200;

        public int LeftBottomCornerRectSize
        {
            get { return _leftBottomCornerRectSize; }
            set { _leftBottomCornerRectSize = value; }
        }

        private int _rightBottomCornerRectSize = 200;

        public int RightBottomCornerRectSize
        {
            get { return _rightBottomCornerRectSize; }
            set { _rightBottomCornerRectSize = value; }
        }
        private int _glassWidth = 1000;

        public int GlassWidth
        {
            get { return _glassWidth; }
            set { _glassWidth = value; }
        }

        private int _glassHeight = 1000;

        public int GlassHeight
        {
            get { return _glassHeight; }
            set
            {
                _glassHeight = value;
                if (Machine.Instance().CameraManager != null)
                    Machine.Instance().CameraManager.SetFovGlassHeight(_fov, _glassHeight);
            }
        }

        private double _fov = 200;

        public double Fov
        {
            get { return _fov; }
            set
            {
                _fov = value;
                if (Machine.Instance().CameraManager != null)
                    Machine.Instance().CameraManager.SetFovGlassHeight(_fov, _glassHeight);
            }
        }

        private eOriginDirection _originDirection = eOriginDirection.LeftTop;

        public eOriginDirection OriginDirection
        {
            get { return _originDirection; }
            set { _originDirection = value; }
        }

        private bool _twoEdge = false;
        public bool TwoEdge
        {
            get { return _twoEdge; }
            set { _twoEdge = value; }
        }

        private double _cameraInterval = 0;
        public double CameraInterval
        {
            get { return _cameraInterval; }
            set { _cameraInterval = value; }
        }


        private bool _useGrabEdgeDetect = false;

        public bool UseGrabEdgeDetect
        {
            get { return _useGrabEdgeDetect; }
            set
            {
                _useGrabEdgeDetect = value;
                if (Machine.Instance().CameraManager != null)
                {
                    Machine.Instance().CameraManager.SetUseGrabEdgeDetect(_useGrabEdgeDetect);
                }
            }
        }

        private bool _saveSubImage = false;

        public bool SaveSubImage
        {
            get { return _saveSubImage; }
            set { _saveSubImage = value; }
        }

        private bool _saveCropImage = false;

        public bool SaveCropImage
        {
            get { return _saveCropImage; }
            set { _saveCropImage = value; }
        }

        private bool _saveMergeImage = true;

        public bool SaveMergeImage
        {
            get { return _saveMergeImage; }
            set { _saveMergeImage = value; }
        }

        private eImageType _saveSubImageType = eImageType.Bmp;

        public eImageType SaveSubImageType
        {
            get { return _saveSubImageType; }
            set { _saveSubImageType = value; }
        }

        private eImageType _saveCropImageType = eImageType.Bmp;

        public eImageType SaveCropImageType
        {
            get { return _saveCropImageType; }
            set { _saveCropImageType = value; }
        }

        private eImageType _saveMergeImageType = eImageType.Bmp;

        public eImageType SaveMergeImageType
        {
            get { return _saveMergeImageType; }
            set { _saveMergeImageType = value; }
        }

        private eDiskType _saveDisk1Type = eDiskType.C;

        public eDiskType SaveDisk1Type
        {
            get { return _saveDisk1Type; }
            set { _saveDisk1Type = value; }
        }

        private eDiskType _saveDisk2Type = eDiskType.D;

        public eDiskType SaveDisk2Type
        {
            get { return _saveDisk2Type; }
            set { _saveDisk2Type = value; }
        }

        private bool _useTestMode = false;

        public bool UseTestMode
        {
            get { return _useTestMode; }
            set
            {
                _useTestMode = value;
                Machine.Instance().Sequence.SetSeqStep(eSeqStep.SEQ_INIT);
            }
        }

        private bool _drawCorner = true;

        public bool DrawCorner
        {
            get { return _drawCorner; }
            set { _drawCorner = value; }
        }

        private bool _useByPass = false;

        public bool UseByPass
        {
            get { return _useByPass; }
            set { _useByPass = value; }
        }

        private bool _usePLCTime = false;

        public bool UsePLCTime
        {
            get { return _usePLCTime; }
            set { _usePLCTime = value; }
        }

        private int _logSavePeriod = 30;

        public int LogSavePeriod
        {
            get { return _logSavePeriod; }
            set { _logSavePeriod = value; }
        }

        private int _imageSavePeriod = 30;

        public int ImageSavePeriod
        {
            get { return _imageSavePeriod; }
            set { _imageSavePeriod = value; }
        }

        private int _thumbnailRatio = 8;

        public int ThumbnailRatio
        {
            get { return _thumbnailRatio; }
            set { _thumbnailRatio = value; }
        }

        private string _imageFolderPath = "";

        public string ImageFolderPath
        {
            get { return _imageFolderPath; }
            set { _imageFolderPath = value; }
        }

        //private string _aiConfigName = "";
        //public string AIConfigName
        //{
        //    get { return _aiConfigName; }
        //    set { _aiConfigName = value; }
        //}

        //private string _aiNamesName = "";
        //public string AINamesName
        //{
        //    get { return _aiNamesName; }
        //    set { _aiNamesName = value; }
        //}

        private string _aiWeightName = "";
        public string AIWeightName
        {
            get { return _aiWeightName; }
            set { _aiWeightName = value; }
        }

        public bool IsRuleBaseInspection()
        {
            return UseEdgeBrokenAlgorithm | UseEdgeContourAlgorithm | UseForkBrokenAlgorithm | UseForkContourAlgorithm;
        }

        public void Save(bool isBackup = false)
        {
            string strPath = System.IO.Directory.GetCurrentDirectory() + "\\config"; // 현재 폴더 위치에서 config 폴더 위치를 추가합니다.
            Utility.CreateDir(strPath); // config 폴더가 있는 지 검사, 없으면 만듭니다.
            strPath += "\\Setup.cfg"; // 파일 위치를 추가합니다.

            if (isBackup)
            {
                string backupPath = strPath + ".bak"; // 백업 주소를 만듭니다.

                if (File.Exists(backupPath)) // 백업 파일이 존재할 경우
                {
                    File.Delete(backupPath); // 제거합니다.
                }
                File.Move(strPath, backupPath); // 현재 세이브 파일을 백업합니다.
            }

            XmlDocument xmlDocument = new XmlDocument();

            XmlHelper.SaveDeclaration(xmlDocument);

            XmlElement configElement = xmlDocument.CreateElement("", "Config", "");
            xmlDocument.AppendChild(configElement);

            SaveParams(configElement);

            xmlDocument.Save(strPath);
        }

        public bool Load()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\config"; // 현재 폴더 위치에서 config 폴더 위치를 추가합니다.
            Utility.CreateDir(path); // config 폴더가 있는 지 검사, 없으면 만듭니다.
            string fileName = path + "\\Setup.cfg"; // 파일 위치를 추가합니다.

            if (!File.Exists(fileName))
            {
                for (int i = 0; i < Settings.Instance().Operation.CamCount; i++)
                {
                    Settings.Instance().Operation.CamProp.Add(new CameraProperty());
                }

                //Save();
                return false;
            }
            else
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                XmlElement configElement = xmlDocument.DocumentElement;

                LoadParams(configElement);
                
                return true;
            }
        }

        private void SaveParams(XmlElement configElement)
        {
            XmlElement operationElement = configElement.OwnerDocument.CreateElement("", "Operation", "");
            configElement.AppendChild(operationElement);

            XmlHelper.SetValue(operationElement, "CamCount", CamCount.ToString());

            SaveCamProp(operationElement);

            XmlHelper.SetValue(operationElement, "CameraType", CameraType.ToString());

            XmlHelper.SetValue(operationElement, "PlcType", PlcType.ToString());
            XmlHelper.SetValue(operationElement, "InspectionTriggerType", InspectionTriggerType.ToString());
            XmlHelper.SetValue(operationElement, "StartGrabDelay", StartGrabDelay.ToString());
            XmlHelper.SetValue(operationElement, "EndGrabDelay", EndGrabDelay.ToString());

            XmlHelper.SetValue(operationElement, "DIOBoardType", DioBoardType.ToString());
            XmlHelper.SetValue(operationElement, "DIOCardNo", DioCardNo.ToString());

            XmlHelper.SetValue(operationElement, "LineRateType", LineRateType.ToString());
            XmlHelper.SetValue(operationElement, "ConstantVel", ConstantVel.ToString());
            XmlHelper.SetValue(operationElement, "SlowVel", SlowVel.ToString());

            XmlHelper.SetValue(operationElement, "PlcIPAddress", PlcIPAddress.ToString());
            XmlHelper.SetValue(operationElement, "PlcPortNumber", PlcPortNumber.ToString());

            XmlHelper.SetValue(operationElement, "LightType", LightType.ToString());
            XmlHelper.SetValue(operationElement, "SerialLightType", SerialLightType.ToString());
            XmlHelper.SetValue(operationElement, "LightValue", LightValue.ToString());
            XmlHelper.SetValue(operationElement, "ComPort", ComPort);
            XmlHelper.SetValue(operationElement, "BaudRate", BaudRate.ToString());

            XmlHelper.SetValue(operationElement, "UseAi", UseAi.ToString());
            XmlHelper.SetValue(operationElement, "AiType", AiType.ToString());

            XmlHelper.SetValue(operationElement, "UseEdgeBrokenAlgorithm", UseEdgeBrokenAlgorithm.ToString());
            XmlHelper.SetValue(operationElement, "UseEdgeContourAlgorithm", UseEdgeContourAlgorithm.ToString());

            XmlHelper.SetValue(operationElement, "UseForkBrokenAlgorithm", UseForkBrokenAlgorithm.ToString());
            XmlHelper.SetValue(operationElement, "UseForkContourAlgorithm", UseForkContourAlgorithm.ToString());

            XmlHelper.SetValue(operationElement, "LeftTopCornerRectSize", LeftTopCornerRectSize.ToString());
            XmlHelper.SetValue(operationElement, "LeftBottomCornerRectSize", LeftBottomCornerRectSize.ToString());
            XmlHelper.SetValue(operationElement, "RightTopCornerRectSize", RightTopCornerRectSize.ToString());
            XmlHelper.SetValue(operationElement, "RightBottomCornerRectSize", RightBottomCornerRectSize.ToString());

            XmlHelper.SetValue(operationElement, "GlassWidth", GlassWidth.ToString());
            XmlHelper.SetValue(operationElement, "GlassHeight", GlassHeight.ToString());
            XmlHelper.SetValue(operationElement, "Fov", Fov.ToString());
            XmlHelper.SetValue(operationElement, "OriginDirection", OriginDirection.ToString());
            XmlHelper.SetValue(operationElement, "TwoEdge", TwoEdge.ToString());
            XmlHelper.SetValue(operationElement, "CameraInterval", CameraInterval.ToString());

            XmlHelper.SetValue(operationElement, "UseGrabEdgeDetect", UseGrabEdgeDetect.ToString());
            XmlHelper.SetValue(operationElement, "SaveSubImage", SaveSubImage.ToString());
            XmlHelper.SetValue(operationElement, "SaveCropImage", SaveCropImage.ToString());
            XmlHelper.SetValue(operationElement, "SaveMergeImage", SaveMergeImage.ToString());

            XmlHelper.SetValue(operationElement, "SaveSubImageType", SaveSubImageType.ToString());
            XmlHelper.SetValue(operationElement, "SaveCropImageType", SaveCropImageType.ToString());
            XmlHelper.SetValue(operationElement, "SaveMergeImageType", SaveMergeImageType.ToString());

            XmlHelper.SetValue(operationElement, "UseTestMode", UseTestMode.ToString());
            XmlHelper.SetValue(operationElement, "DrawCorner", DrawCorner.ToString());
            XmlHelper.SetValue(operationElement, "UseByPass", UseByPass.ToString());
            XmlHelper.SetValue(operationElement, "UsePLCTime", UsePLCTime.ToString());
            XmlHelper.SetValue(operationElement, "LogSavePeriod", LogSavePeriod.ToString());

            XmlHelper.SetValue(operationElement, "ThumbnailRatio", ThumbnailRatio.ToString());
            XmlHelper.SetValue(operationElement, "ImageFolderPath", ImageFolderPath);

            //XmlHelper.SetValue(operationElement, "AIConfigName", AIConfigName);
            //XmlHelper.SetValue(operationElement, "AINamesName", AINamesName);
            //XmlHelper.SetValue(operationElement, "AIWeightName", AIWeightName);
        }

        private void LoadParams(XmlElement configElement)
        {
            XmlElement operationElement = configElement["Operation"];
            if (operationElement == null)
                return;
            CamCount = Convert.ToInt32(XmlHelper.GetValue(operationElement, "CamCount", CamCount.ToString()));

            for (int i = 0; i < CamCount; i++)
            {
                Settings.Instance().Operation.CamProp.Add(new CameraProperty());
            }
            LoadCamProp(operationElement);

            CameraType = (eCameraType)Enum.Parse(typeof(eCameraType), XmlHelper.GetValue(operationElement, "CameraType", CameraType.ToString()));

            PlcType = (ePLCType)Enum.Parse(typeof(ePLCType), XmlHelper.GetValue(operationElement, "PlcType", PlcType.ToString()));
            InspectionTriggerType = (eInspectionTriggerType)Enum.Parse(typeof(eInspectionTriggerType), XmlHelper.GetValue(operationElement, "InspectionTriggerType", InspectionTriggerType.ToString()));
            StartGrabDelay = Convert.ToInt32(XmlHelper.GetValue(operationElement, "StartGrabDelay", StartGrabDelay.ToString()));
            EndGrabDelay = Convert.ToInt32(XmlHelper.GetValue(operationElement, "EndGrabDelay", EndGrabDelay.ToString()));

            DioBoardType = (eDIOBoardType)Enum.Parse(typeof(eDIOBoardType), XmlHelper.GetValue(operationElement, "DIOBoardType", DioBoardType.ToString()));
            DioCardNo = Convert.ToInt32(XmlHelper.GetValue(operationElement, "DIOCardNo", DioCardNo.ToString()));

            LineRateType = (eLineRateType)Enum.Parse(typeof(eLineRateType), XmlHelper.GetValue(operationElement, "LineRateType", LineRateType.ToString()));
            ConstantVel = Convert.ToInt32(XmlHelper.GetValue(operationElement, "ConstantVel", ConstantVel.ToString()));
            SlowVel = Convert.ToInt32(XmlHelper.GetValue(operationElement, "SlowVel", SlowVel.ToString()));

            PlcIPAddress = XmlHelper.GetValue(operationElement, "PlcIPAddress", PlcIPAddress);
            PlcPortNumber = Convert.ToInt32(XmlHelper.GetValue(operationElement, "PlcPortNumber", PlcPortNumber.ToString()));

            LightType = (eLightType)Enum.Parse(typeof(eLightType), XmlHelper.GetValue(operationElement, "LightType", LightType.ToString()));
            SerialLightType = (eSerialLightType)Enum.Parse(typeof(eSerialLightType), XmlHelper.GetValue(operationElement, "SerialLightType", SerialLightType.ToString()));
            LightValue = Convert.ToInt32(XmlHelper.GetValue(operationElement, "LightValue", LightValue.ToString()));

            ComPort = XmlHelper.GetValue(operationElement, "ComPort", ComPort);
            BaudRate = Convert.ToInt32(XmlHelper.GetValue(operationElement, "BaudRate", BaudRate.ToString()));

            UseAi = Convert.ToBoolean(XmlHelper.GetValue(operationElement, "UseAi", UseAi.ToString()));
            AiType = (eAIInspectionType)Enum.Parse(typeof(eAIInspectionType), XmlHelper.GetValue(operationElement, "AiType", AiType.ToString()));

            UseEdgeBrokenAlgorithm = Convert.ToBoolean(XmlHelper.GetValue(operationElement, "UseEdgeBrokenAlgorithm", UseEdgeBrokenAlgorithm.ToString()));
            UseEdgeContourAlgorithm = Convert.ToBoolean(XmlHelper.GetValue(operationElement, "UseEdgeContourAlgorithm", UseEdgeContourAlgorithm.ToString()));

            UseForkBrokenAlgorithm = Convert.ToBoolean(XmlHelper.GetValue(operationElement, "UseForkBrokenAlgorithm", UseForkBrokenAlgorithm.ToString()));
            UseForkContourAlgorithm = Convert.ToBoolean(XmlHelper.GetValue(operationElement, "UseForkContourAlgorithm", UseForkContourAlgorithm.ToString()));


            LeftTopCornerRectSize = Convert.ToInt32(XmlHelper.GetValue(operationElement, "LeftTopCornerRectSize", LeftTopCornerRectSize.ToString()));
            LeftBottomCornerRectSize = Convert.ToInt32(XmlHelper.GetValue(operationElement, "LeftBottomCornerRectSize", LeftBottomCornerRectSize.ToString()));
            RightTopCornerRectSize = Convert.ToInt32(XmlHelper.GetValue(operationElement, "RightTopCornerRectSize", RightTopCornerRectSize.ToString()));
            RightBottomCornerRectSize = Convert.ToInt32(XmlHelper.GetValue(operationElement, "RightBottomCornerRectSize", RightBottomCornerRectSize.ToString()));

            GlassWidth = Convert.ToInt32(XmlHelper.GetValue(operationElement, "GlassWidth", GlassWidth.ToString()));
            GlassHeight = Convert.ToInt32(XmlHelper.GetValue(operationElement, "GlassHeight", GlassHeight.ToString()));
            Fov = Convert.ToInt32(XmlHelper.GetValue(operationElement, "Fov", Fov.ToString()));
            OriginDirection = (eOriginDirection)Enum.Parse(typeof(eOriginDirection), XmlHelper.GetValue(operationElement, "OriginDirection", OriginDirection.ToString()));
            TwoEdge = Convert.ToBoolean(XmlHelper.GetValue(operationElement, "TwoEdge", UseGrabEdgeDetect.ToString()));
            CameraInterval = Convert.ToInt32(XmlHelper.GetValue(operationElement, "CameraInterval", CameraInterval.ToString()));

            UseGrabEdgeDetect = Convert.ToBoolean(XmlHelper.GetValue(operationElement, "UseGrabEdgeDetect", UseGrabEdgeDetect.ToString()));
            SaveSubImage = Convert.ToBoolean(XmlHelper.GetValue(operationElement, "SaveSubImage", SaveSubImage.ToString()));
            SaveCropImage = Convert.ToBoolean(XmlHelper.GetValue(operationElement, "SaveCropImage", SaveCropImage.ToString()));
            SaveMergeImage = Convert.ToBoolean(XmlHelper.GetValue(operationElement, "SaveMergeImage", SaveMergeImage.ToString()));

            SaveSubImageType = (eImageType)Enum.Parse(typeof(eImageType), XmlHelper.GetValue(operationElement, "SaveSubImageType", SaveSubImageType.ToString()));
            SaveCropImageType = (eImageType)Enum.Parse(typeof(eImageType), XmlHelper.GetValue(operationElement, "SaveCropImageType", SaveCropImageType.ToString()));
            SaveMergeImageType = (eImageType)Enum.Parse(typeof(eImageType), XmlHelper.GetValue(operationElement, "SaveMergeImageType", SaveMergeImageType.ToString()));

            UseTestMode = Convert.ToBoolean(XmlHelper.GetValue(operationElement, "UseTestMode", UseTestMode.ToString()));
            DrawCorner = Convert.ToBoolean(XmlHelper.GetValue(operationElement, "DrawCorner", DrawCorner.ToString()));
            UseByPass = Convert.ToBoolean(XmlHelper.GetValue(operationElement, "UseByPass", UseByPass.ToString()));
            UsePLCTime = Convert.ToBoolean(XmlHelper.GetValue(operationElement, "UsePLCTime", UsePLCTime.ToString()));

            LogSavePeriod = Convert.ToInt32(XmlHelper.GetValue(operationElement, "LogSavePeriod", LogSavePeriod.ToString()));
            ThumbnailRatio = Convert.ToInt32(XmlHelper.GetValue(operationElement, "ThumbnailRatio", LogSavePeriod.ToString()));
            ImageFolderPath = XmlHelper.GetValue(operationElement, "ImageFolderPath", ImageFolderPath);

            //AIConfigName = XmlHelper.GetValue(operationElement, "AIConfigName", AIConfigName);
            //AINamesName = XmlHelper.GetValue(operationElement, "AINamesName", AINamesName);
            //AIWeightName = XmlHelper.GetValue(operationElement, "AIWeightName", AIWeightName);
        }

        private void SaveCamProp(XmlElement configElement)
        {
            string name = "CamProperty_";
            int count = 0;
            foreach (CameraProperty cameraProp in Settings.Instance().Operation.CamProp)
            {
                string elementName = name + count.ToString();
                XmlElement camPropElement = configElement.OwnerDocument.CreateElement("", elementName, "");
                configElement.AppendChild(camPropElement);
                XmlHelper.SetValue(camPropElement, "CamName", cameraProp.CamName);
                XmlHelper.SetValue(camPropElement, "CamAddress", cameraProp.CamAddress);
                XmlHelper.SetValue(camPropElement, "SerialNumber", cameraProp.SerialNumber);
                XmlHelper.SetValue(camPropElement, "Exposure", cameraProp.Exposure.ToString());
                XmlHelper.SetValue(camPropElement, "Offset", cameraProp.Offset.ToString());
                XmlHelper.SetValue(camPropElement, "Width", cameraProp.Width.ToString());
                XmlHelper.SetValue(camPropElement, "Height", cameraProp.Height.ToString());

                XmlHelper.SetValue(camPropElement, "IsExistFork", cameraProp.IsExistFork.ToString());
                XmlHelper.SetValue(camPropElement, "Threshold1", cameraProp.Threshold1.ToString());
                XmlHelper.SetValue(camPropElement, "Threshold2", cameraProp.Threshold2.ToString());

                XmlHelper.SetValue(camPropElement, "IgnoreLeftXFromFork", cameraProp.IgnoreLeftXFromFork.ToString());
                XmlHelper.SetValue(camPropElement, "IgnoreRightXFromFork", cameraProp.IgnoreRightXFromFork.ToString());

                count++;
            }
        }

        private void LoadCamProp(XmlElement configElement)
        {
            string name = "CamProperty_";
            int count = 0;
            foreach (CameraProperty cameraProp in Settings.Instance().Operation.CamProp)
            {
                string elementName = name + count.ToString();
                XmlElement camPropElement = configElement[elementName];
                if (camPropElement == null)
                    return;

                cameraProp.CamName = XmlHelper.GetValue(camPropElement, "CamName", cameraProp.CamName);
                cameraProp.CamAddress = XmlHelper.GetValue(camPropElement, "CamAddress", cameraProp.CamAddress);
                cameraProp.SerialNumber = XmlHelper.GetValue(camPropElement, "SerialNumber", cameraProp.SerialNumber);
                cameraProp.Exposure = Convert.ToDouble(XmlHelper.GetValue(camPropElement, "Exposure", cameraProp.Exposure.ToString()));
                cameraProp.Offset = Convert.ToInt32(XmlHelper.GetValue(camPropElement, "Offset", cameraProp.Offset.ToString()));
                cameraProp.Width = Convert.ToInt32(XmlHelper.GetValue(camPropElement, "Width", cameraProp.Width.ToString()));
                cameraProp.Height = Convert.ToInt32(XmlHelper.GetValue(camPropElement, "Height", cameraProp.Height.ToString()));

                cameraProp.IsExistFork = Convert.ToBoolean(XmlHelper.GetValue(camPropElement, "IsExistFork", cameraProp.IsExistFork.ToString()));
                cameraProp.Threshold1 = Convert.ToDouble(XmlHelper.GetValue(camPropElement, "Threshold1", cameraProp.Threshold1.ToString()));
                cameraProp.Threshold2 = Convert.ToDouble(XmlHelper.GetValue(camPropElement, "Threshold2", cameraProp.Threshold2.ToString()));
                cameraProp.IgnoreLeftXFromFork = Convert.ToInt32(XmlHelper.GetValue(camPropElement, "IgnoreLeftXFromFork", cameraProp.IgnoreLeftXFromFork.ToString()));
                cameraProp.IgnoreRightXFromFork = Convert.ToInt32(XmlHelper.GetValue(camPropElement, "IgnoreRightXFromFork", cameraProp.IgnoreRightXFromFork.ToString()));

                count++;
            }
        }
    }
}