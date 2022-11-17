using Device.Edge;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Camera
{
    public abstract class ICameraManager
    {
        public abstract eCameraStatus Initialize(List<CameraProperty> camPropertyList, int camMaxCount);

        public abstract bool StartGrab();

        public abstract bool StopGrab();

        public abstract void SetTriggerOff();

        public abstract bool IsGrabbing();

        public abstract bool IsCallBackCompleted();

        public abstract bool IsOpen();

        public abstract bool IsOpen(int camNo);

        public abstract void SetExpose(int camNo, double expose);

        public abstract double GetExpose(int camNo);

        public abstract void SetLineRate(double vel);

        public abstract double GetLineRate(int camNo);

        public abstract void SetProperty(object param);

        public abstract void SetProperty(int camNo, object param);

        public abstract object GetProperty(int camNo);

        public abstract void Terminate();

        public abstract void SetSubImageList(int camNo, List<Bitmap> subImageList, Bitmap prevImage);

        public abstract void SetFinallyEdgeList(int camNo, List<EdgeElement> finallyEdgeList);

        public abstract void SetTransportLayer(int camCount);

        public abstract void SetFovGlassHeight(double fov, int glassHeight);

        public abstract int TotalSubImageCount();

        public abstract List<ICamera> GetCameraList();

        public abstract Bitmap GetMergeImage(int camNo);

        public abstract void SetMaxCamCount(int maxCamCount);

        public abstract int GetMaxCamCount(int camNo);

        public abstract void SetUseGrabEdgeDetect(bool isUseGrabEdgeDetect);

        public abstract int GetConnectedCount();

        public abstract void SetEnableShading(int camNo, bool enableShadig);

        public abstract bool IsEnableShading(int camNo);

        public abstract void Shading(int camNo, eShadingType type);

        public abstract void SetMergeImageCount(int count);
    }
}