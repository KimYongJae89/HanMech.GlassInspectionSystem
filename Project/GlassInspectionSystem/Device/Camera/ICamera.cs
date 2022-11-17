using Device.Edge;
using HMechLogLib;
using OpenCvSharp;
using RuleAlgorithm.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Camera
{
    public enum eCameraType
    {
        None,
        Basler,
        HIK,
    }

    public enum eShadingType
    {
        Off,
        Once,
    }
    
    public class CameraProperty
    {
        public string CamName;
        public string CamAddress;
        public string SerialNumber;
        public double Exposure = 0.024;
        //public double LineRate;
        public int Offset = 0;
        public int Width = 4096;
        public int Height = 1024;

        private bool _isExistFork = false;
        public bool IsExistFork
        {
            get { return _isExistFork; }
            set { _isExistFork = value; }
        }

        private int _ignoreLeftXFromFork = 0;
        public int IgnoreLeftXFromFork
        {
            get { return _ignoreLeftXFromFork; }
            set { _ignoreLeftXFromFork = value; }
        }

        private int _ignoreRightXFromFork = 0;
        public int IgnoreRightXFromFork
        {
            get { return _ignoreRightXFromFork; }
            set { _ignoreRightXFromFork = value; }
        }

        private double _threshold1 = 30.0;
        public double Threshold1
        {
            get { return _threshold1; }
            set { _threshold1 = value; }
        }

        private double _threshold2 = 90.0;
        public double Threshold2
        {
            get { return _threshold2; }
            set { _threshold2 = value; }
        }

        public void SetProperty(CameraProperty property)
        {
            this.CamName = property.CamName;
            this.CamAddress = property.CamAddress;
            this.SerialNumber = property.SerialNumber;
            this.Exposure = property.Exposure;
            //this.LineRate = property.LineRate;
            this.Offset = property.Offset;
            this.Width = property.Width;
            this.Height = property.Height;

            this.IsExistFork = property.IsExistFork;
            this.IgnoreLeftXFromFork = property.IgnoreLeftXFromFork;
            this.IgnoreRightXFromFork = property.IgnoreRightXFromFork;
            this.Threshold1 = property.Threshold1;
            this.Threshold2 = property.Threshold2;
        }

        public CameraProperty Copy()
        {
            CameraProperty property = new CameraProperty();
            property.CamName = this.CamName;
            property.CamAddress = this.CamAddress;
            property.SerialNumber = this.SerialNumber;
            property.Exposure = this.Exposure;
            property.Offset = this.Offset;
            property.Width = this.Width;
            property.Height = this.Height;
            property.IsExistFork = this.IsExistFork;
            property.IgnoreLeftXFromFork = this.IgnoreLeftXFromFork;
            property.IgnoreRightXFromFork = this.IgnoreRightXFromFork;
            property.Threshold1 = this.Threshold1;
            property.Threshold2 = this.Threshold2;

            return property;
        }
    }

    public struct SubImg
    {
        public int CamNo;
        public int SubNo;
        public int Width;
        public int Height;

        public SubImg(int camNo, int subNo, int width, int height)
        {
            this.CamNo = camNo;
            this.SubNo = subNo;
            this.Width = width;
            this.Height = height;
        }
    }

    public abstract class ICamera
    {
        public Action<EdgeElement> VerticalInspection;

        public Action<int> DeleDisConnected;

        public static int MAX_FRAME_COUNT = 50;
        public static Queue<SubImg> SubImageInfoList = null;
        public static object ObjLock = new object();
        public static Queue<EdgeElement> LeftRightEdgeInfoList = null;// Edge 검사시 Left Right 먼저 검사
        public static object ObjLockEdgeInsp = new object();

        public static bool IsLive = false;
        public bool UseGrabEdgeDetect = false;
        public double Fov = 0;
        public int GlassHeight = 0;
        public int SubNoMax = 0;

        public abstract eCameraStatus Initialize();

        public abstract bool StartGrab();

        public abstract void SetTriggerOff();

        public abstract bool StopGrab();

        public abstract bool IsGrabbing();

        public abstract bool IsCallBackCompleted();

        public abstract bool IsOpen();

        public abstract void SetLineRate(double vel);

        public abstract double GetLineRate();

        public abstract void SetProperty(object param);

        public abstract object GetProperty();

        public abstract void ActiveProperty();

        public abstract void Terminate();

        public abstract List<Bitmap> GetSubImageList();

        public abstract void SetSubImageList(List<Bitmap> subImageList, Bitmap prevImage);

        public abstract void SetFinallyEdgeList(List<EdgeElement> finallyEdgeList);

        public abstract void SetCamNo(int camNo);

        public abstract int GetCamNo();

        public abstract int GetSubNo();

        public abstract void SetMaxCamCount(int maxCamCount);

        public abstract int GetMaxCamCount();

        public abstract void SetTransportLayer(int camCount);

        public abstract void SetFovGlassHeight(double fov, int glassHeight);

        public List<EdgeElement> GetFinallyEdge(List<EdgeElement> sourceList, int maxCamCount)
        {
            try
            {
                List<EdgeElement> list = new List<EdgeElement>();

                EdgeElement TopElement = new EdgeElement();
                TopElement.Type = eEdgeType.Top;
                TopElement.CropRealPoint = new System.Drawing.Point(0, 99999);

                EdgeElement BottomElement = new EdgeElement();
                BottomElement.Type = eEdgeType.Bottom;
                BottomElement.CropRealPoint = new System.Drawing.Point(0, 0);

                bool isTopElement = false;
                bool isBottomElement = false;
                int leftOrder = 1;
                int rightOrder = 1;

                foreach (EdgeElement element in sourceList)
                {
                    if (element.Type == eEdgeType.Top)
                    {
                        if (element.CropRealPoint.Y < TopElement.CropRealPoint.Y)
                        {
                            isTopElement = true;
                            TopElement = element.Copy();
                        }
                    }
                    //Bottom 모든 Cam에 대한 Bottom Data
                    if (element.Type == eEdgeType.Bottom)
                    {
                        if (element.CropRealPoint.Y > BottomElement.CropRealPoint.Y)
                        {
                            isBottomElement = true;
                            BottomElement = element.Copy();
                        }
                    }

                    //Left Frist Cam번에 대한 Left Data
                    if (element.CamNo == 0 && element.Type == eEdgeType.Left)
                    {
                        list.Add(element.Copy());
                        leftOrder++;
                    }
                    //Right Last Cam번에 대한 Right Data
                    if (element.CamNo == maxCamCount - 1 && element.Type == eEdgeType.Right)
                    {
                        list.Add(element.Copy());
                        rightOrder++;
                    }
                }
                if (isTopElement)
                    list.Add(TopElement.Copy());
                if (isBottomElement)
                    list.Add(BottomElement.Copy());

                return list;
            }
            catch (Exception err)
            {
                Logger.WriteException(eLogType.ERROR, err);
                return null;
            }
        }

        public abstract Bitmap GetMergeImage();

        public abstract void SetEnableShading(bool enableShadig);

        public abstract bool IsEnableShading();

        public abstract void Shading(eShadingType type);

        public abstract void SetExpose(double expose);

        public abstract double GetExpose();

        public abstract void SetMergeImageCount(int count);
    }
}