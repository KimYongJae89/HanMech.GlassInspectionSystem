using AI;
using Device.Camera;
using Device.Edge;
using Device.PLC;
using enumType;
using MechAI.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMechUtility;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using HMechLogLib;
using System.IO;
using RuleAlgorithm.Utility;

namespace GlassInspectionSystem.Class
{
    public class CropInfo
    {
        public EdgeElement Element;
        public Bitmap Image = null;
        public eInspectionType InspType = eInspectionType.None;

        public void Clear()
        {
            if (this.Image != null)
            {
                this.Image.Dispose();
                this.Image = null;
            }
        }

        public CropInfo Copy()
        {
            CropInfo info = new CropInfo();
            info.Element = Element.Copy();
            info.Image = (Bitmap)this.Image.Clone();
            info.InspType = this.InspType;
            return info;
        }
    }

    public class ForkImageRoi
    {
        public bool IsForkImage = false;
        public Rectangle Roi = new Rectangle();

        public ForkImageRoi(bool isForkImage, Rectangle rect)
        {
            this.IsForkImage = isForkImage;
            this.Roi = rect;
        }
    }

    public class InspectionObject
    {
        public int CamNo = -1;
        public int SubNo = -1;
        public Bitmap Image = null;
        public eInspectionType InspType = eInspectionType.None;
        public eEdgeType InspDirection = eEdgeType.None;
        public List<Defect> DefectList = new List<Defect>();
        public bool IsCrop = false;
        public bool IsExistDefect = false;
    }

    public class Defect
    {
        public Bitmap Image = null;
        public eInspectionType InspectionType;
        //public eDefectClass DefectType;
        public string DefectName;
        public int Pid;
        public int CamNo;
        public eDefectType AlarmType;
        public double Confidence;
        public double ImageCenterPosX;
        public double ImageCenterPosY;
        public double RealPosX;
        public double RealPosY;
        public double BoundingPosX;
        public double BoundingPosY;
        public double BoundingWidth;
        public double BoundingHeight;
    }

    public class CornerInfo
    {
        public Rectangle LeftTopCornerRect = new Rectangle(); //Corner Rect(Real Pos)
        public Rectangle LeftBottomCornerRect = new Rectangle(); //Corner Rect(Real Pos)
        public Rectangle RightTopCornerRect = new Rectangle(); //Corner Rect(Real Pos)
        public Rectangle RightBottomCornerRect = new Rectangle(); //Corner Rect(Real Pos)

        public System.Drawing.Point LeftTopRealPoint = new System.Drawing.Point(); //Corner Point(Real Pos)
        public System.Drawing.Point LeftBottomRealPoint = new System.Drawing.Point(); //Corner Point(Real Pos)
        public System.Drawing.Point RightTopRealPoint = new System.Drawing.Point(); //Corner Point(Real Pos)
        public System.Drawing.Point RightBottomRealPoint = new System.Drawing.Point(); //Corner Point(Real Pos)

    }

    public class InspResult
    {
        public List<InspectionObject> InspObjectList = new List<InspectionObject>(); // 검사 결과

        public List<CropInfo> CropAIImageList = new List<CropInfo>(); // AI 검사하려고 Crop한 이미지 List

        public List<CropInfo> CropBrokenImageListFork = new List<CropInfo>(); // Fork Broken 검사하려고 Crop한 이미지 List
        public List<CropInfo> CropBrokenImageListNonFork = new List<CropInfo>(); // Fork Contour 검사하려고 Crop한 이미지 List

        public List<CropInfo> CropContourImageListFork = new List<CropInfo>(); // NonFork(Edge) Broken 검사하려고 Crop한 이미지 List
        public List<CropInfo> CropContourImageListNonFork = new List<CropInfo>(); // NonFork(Edge) Contour 검사하려고 Crop한 이미지 List


        public List<Defect> FinallyDefectList = new List<Defect>();
        private List<Defect> _defectList = new List<Defect>();

        public CornerInfo Corner = new CornerInfo();
     
        private string _glassID = "";
        public string GlassID
        {
            get { return _glassID; }
            set { _glassID = value; }
        }

        private double _inspTime = 0.0;
        public double InspTime
        {
            get { return _inspTime; }
            set { _inspTime = value; }
        }

        private string _saveImagePath = "";
        public string SaveImagePath
        {
            get { return _saveImagePath; }
            set { _saveImagePath = value; }
        }

        private string _dbImagePath = "";
        public string DBImagePath
        {
            get { return _dbImagePath; }
            set { _dbImagePath = value; }
        }

        private double _tactTime = 0.0;
        public double TactTime
        {
            get { return _tactTime; }
            set { _tactTime = value; }
        }

        private eResultConstant _inspResultType = eResultConstant.OK;
        public eResultConstant InspResultType
        {
            get { return _inspResultType; }
            set { _inspResultType = value; }
        }

        /// <summary>
        /// 전면 검사 일 경우
        /// </summary>
        public void AddAIFrontDefectList(Bitmap bmp, List<MechItem> mechItemList, SubImg subImg, eInspectionType inspType)
        {
            //bool isDefect = false;
            InspectionObject InspObj = new InspectionObject();
            InspObj.CamNo = subImg.CamNo;
            InspObj.SubNo = subImg.SubNo;
            InspObj.InspType = inspType;
            InspObj.InspDirection = eEdgeType.None;
            InspObj.Image = (Bitmap)bmp.Clone();
            InspObj.IsCrop = false;
            foreach (MechItem mechItem in mechItemList)
            {
                //eDefectClass defectType = (eDefectClass)mechItem.Type;
                int defectIndex = mechItem.Type;

                //AIProperty property = Settings.Instance().AISettings.GetAIProperty(defectType);
                AIProperty property = Settings.Instance().AISettings.GetAIProperty(defectIndex);

                if (property != null)
                {
                    Defect defect = new Defect();
                    //defect.Pid = DB 등록 시 작성
                    defect.CamNo = subImg.CamNo;
                    defect.InspectionType = inspType;
                    //defect.DefectType = property.Type;
                    defect.DefectName = property.DefectName;
                    defect.AlarmType = property.AlarmType;
                    defect.ImageCenterPosX = mechItem.Center().X;
                    defect.ImageCenterPosY = mechItem.Center().Y + subImg.Height * subImg.SubNo;

                    defect.RealPosX = mechItem.X; // 마지막 후처리 시 다시 계산
                    defect.RealPosY = subImg.Height * subImg.SubNo + mechItem.Y; // 마지막 후처리 시 다시 계산
                    //defect.RealPosX = 0; // 마지막 후처리 시 다시 계산
                    //defect.RealPosY = 0; // 마지막 후처리 시 다시 계산

                    defect.BoundingPosX = mechItem.X;
                    defect.BoundingPosY = mechItem.Y + subImg.Height * subImg.SubNo;
                    defect.BoundingWidth = mechItem.Width;
                    defect.BoundingHeight = mechItem.Height;
                    defect.Confidence = mechItem.Confidence;
                    if (property.UseClass)
                    {
                        if (property.Confidence < defect.Confidence)
                        {
                            InspObj.DefectList.Add(defect);
                        }
                    }
                }
            }
            this.InspObjectList.Add(InspObj);
        }

        /// <summary>
        /// Edge 검사일 경우(AI)
        /// </summary>
        public void AddAIEdgeDefectList(Bitmap bmp, List<MechItem> mechItemList, EdgeElement element, eInspectionType inspType)
        {
            //bool isDefect = false;
            InspectionObject InspObj = new InspectionObject();
            InspObj.CamNo = element.CamNo;
            InspObj.SubNo = element.SubNo;
            InspObj.InspType = inspType;
            InspObj.InspDirection = element.Type;
            InspObj.Image = (Bitmap)bmp.Clone();
            InspObj.IsCrop = true;

            foreach (MechItem mechItem in mechItemList)
            {
                System.Drawing.Point centerPoint = new System.Drawing.Point((int)element.CropRealPoint.X + mechItem.X + (mechItem.Width / 2), (int)element.CropRealPoint.Y + mechItem.Y + (mechItem.Height / 2));
                //eDefectClass defectType = (eDefectClass)mechItem.Type;
                int defectIndex = mechItem.Type;

                AIProperty property = Settings.Instance().AISettings.GetAIProperty(defectIndex);

                if (property != null)
                {
                    Defect defect = new Defect();
                    //defect.Pid = DB 등록 시 작성
                    defect.CamNo = element.CamNo;
                    defect.InspectionType = inspType;
                    //defect.DefectType = property.Type;
                    defect.DefectName = property.DefectName;
                    defect.AlarmType = property.AlarmType;

                    defect.ImageCenterPosX = centerPoint.X;
                    defect.ImageCenterPosY = centerPoint.Y;

                    //defect.RealPosX = 0; // 마지막 후처리 시 다시 계산
                    //defect.RealPosY = 0; // 마지막 후처리 시 다시 계산

                    defect.BoundingPosX = mechItem.X + element.CropRealPoint.X;
                    defect.BoundingPosY = mechItem.Y + element.CropRealPoint.Y;
                    defect.BoundingWidth = mechItem.Width;
                    defect.BoundingHeight = mechItem.Height;
                    defect.Confidence = mechItem.Confidence;

                    Rectangle defectRect = new Rectangle((int)defect.BoundingPosX, (int)defect.BoundingPosY, (int)defect.BoundingWidth, (int)defect.BoundingHeight);

                    if (property.UseClass)
                    {
                        if (property.Confidence < defect.Confidence)
                        {
                            InspObj.DefectList.Add(defect);
                        }
                    }
                }
            }
            this.InspObjectList.Add(InspObj);
        }

        /// <summary>
        /// Edge검사일 경우(Rule)
        /// </summary>
        //public void AddRuleEdgeDefectList(Bitmap bmp, List<Rectangle> defectList, EdgeElement element, eInspectionType inspType, eDefectClass defectType)
        public void AddRuleEdgeDefectList(Bitmap bmp, List<Rectangle> defectList, EdgeElement element, eInspectionType inspType, string defectName)
        {
            InspectionObject InspObj = new InspectionObject();
            InspObj.CamNo = element.CamNo;
            InspObj.SubNo = element.SubNo;
            InspObj.InspType = inspType;
            InspObj.InspDirection = element.Type;
            InspObj.Image = (Bitmap)bmp.Clone();
            InspObj.IsCrop = true;

            foreach (Rectangle rect in defectList)
            {
                System.Drawing.Point centerPoint = new System.Drawing.Point((int)element.CropRealPoint.X + rect.X + (rect.Width / 2), (int)element.CropRealPoint.Y + rect.Y + (rect.Height / 2));
                Defect defect = new Defect();
                //defect.Pid = DB 등록 시 작성
                defect.CamNo = element.CamNo;
                defect.InspectionType = inspType;
                //defect.DefectType = defectType;
                defect.DefectName = defectName;
                //defect.AlarmType = GetRuleDefectType(defectType);
                defect.AlarmType = GetRuleDefectType(defectName);
                defect.ImageCenterPosX = centerPoint.X;
                defect.ImageCenterPosY = centerPoint.Y;

                defect.RealPosX = 0; // 마지막 후처리 시 다시 계산
                defect.RealPosY = 0; // 마지막 후처리 시 다시 계산

                defect.BoundingPosX = rect.X + element.CropRealPoint.X;
                defect.BoundingPosY = rect.Y + element.CropRealPoint.Y;
                defect.BoundingWidth = rect.Width;
                defect.BoundingHeight = rect.Height;
                defect.Confidence = 0.99;

                InspObj.DefectList.Add(defect);
            }
            this.InspObjectList.Add(InspObj);
        }

        //private eDefectType GetRuleDefectType(eDefectClass defectclass)
        private eDefectType GetRuleDefectType(string defectName)
        {
            eDefectType type = eDefectType.None;
            defectName = defectName.ToUpper();
            switch (defectName)
            {
                case "BROKEN":
                    type = eDefectType.Broken;
                    break;

                case "CHIPPING":
                    type = eDefectType.Chipping;
                    break;

                case "EDGECRACK":
                case "INNERCRACK":
                case "STARCRACK":
                case "CRACK":
                    type = eDefectType.Crack;
                    break;

                default:
                    type = eDefectType.None;
                    break;
            }
            return type;
        }

        public void FilterDefect(List<EdgeElement>[] _edgeList)
        {
            this.FinallyDefectList.Clear();
            
            foreach (InspectionObject info in this.InspObjectList)
            {
                bool isExistDefect = false;
                foreach (Defect defect in info.DefectList)
                {
                    Rectangle defectRect = new Rectangle((int)defect.BoundingPosX, (int)defect.BoundingPosY, (int)defect.BoundingWidth, (int)defect.BoundingHeight);

                    if (IsCheckCorner(defect.CamNo, defectRect))
                        continue;
                    if(defect.CamNo == 0)
                    {
                        if (defectRect.X <= EdgeDetect.IgnoreLeftXOffsetForEdgeDetect)
                            continue;
                    }
                    else if(defect.CamNo == Settings.Instance().Operation.CamCount - 1)
                    {
                        if (defectRect.X + defectRect.Width >= Settings.Instance().Operation.CamProp[0].Width - EdgeDetect.IgnoreRightXOffsetForEdgeDetect)
                            continue;
                    }
                    isExistDefect = true;
                    //real Pos
                    int realX = 0, realY = 0;
                    int cameraWidth = Settings.Instance().Operation.CamProp[0].Width;

                    PointF defectPoint = new PointF((float)defect.ImageCenterPosX + (defect.CamNo * cameraWidth), (float)defect.ImageCenterPosY);
                    GetRealPos(defectPoint, ref realX, ref realY);

                    defect.RealPosX = realX;
                    defect.RealPosY = realY;

                    
                    this.FinallyDefectList.Add(defect);
                }
                info.IsExistDefect = isExistDefect;
            }

            if (this.FinallyDefectList.Count > 0)
                InspResultType = eResultConstant.NG;
            else
                InspResultType = eResultConstant.OK;
        }

        // GetCorner() 호출 후 사용해야 함
        public bool IsCheckCorner(int camNo, Rectangle rect)
        {
            if (camNo == 0)
            {
                if (this.Corner.LeftTopCornerRect.IntersectsWith(rect) || this.Corner.LeftBottomCornerRect.IntersectsWith(rect))
                {
                    return true;
                }
            }
            if (camNo == Settings.Instance().Operation.CamCount - 1)
            {
                if (this.Corner.RightTopCornerRect.IntersectsWith(rect) || this.Corner.RightBottomCornerRect.IntersectsWith(rect))
                {
                    return true;
                }
            }
            return false;
        }

        private void GetRealPos(PointF defectRealPoint, ref int realX, ref int realY)
        {
            CartesianCoordinate Coordination = new CartesianCoordinate();
            System.Drawing.PointF point = new PointF();
            float scale = (float)Settings.Instance().Operation.Fov / (float)Settings.Instance().Operation.CamProp[0].Width;

            switch (Settings.Instance().Operation.OriginDirection)
            {
                case eOriginDirection.LeftTop:
                    point = Coordination.Coordinate(this.Corner.LeftTopRealPoint, this.Corner.LeftBottomRealPoint, defectRealPoint);
                    break;

                case eOriginDirection.RightTop:
                    point = Coordination.Coordinate(this.Corner.RightTopRealPoint, this.Corner.RightBottomRealPoint, defectRealPoint);
                    break;

                case eOriginDirection.LeftBottom:
                    point = Coordination.Coordinate(this.Corner.LeftBottomRealPoint, this.Corner.LeftTopRealPoint, defectRealPoint);
                    break;

                case eOriginDirection.RightBottom:
                    point = Coordination.Coordinate(this.Corner.RightBottomRealPoint, this.Corner.RightTopRealPoint, defectRealPoint);
                    break;
                //case eOriginDirection.Center:
                default:
                    break;
            }
            //Point Glass Size 기준 실제 좌표 환산 함수 ( 방향, new Size(Settings. width, height), scale
            realX = (int)point.X;
            realY = (int)point.Y;
        }

        public void SetImagePath(DateTime glassInTime)
        {
            string imageFolder = Settings.Instance().Operation.ImageFolderPath;

            this.SaveImagePath = Path.Combine(imageFolder, glassInTime.Month.ToString(), glassInTime.Day.ToString(), _glassID);
            this.DBImagePath = Path.Combine(glassInTime.Month.ToString(), glassInTime.Day.ToString(), _glassID);
        }
    }
}