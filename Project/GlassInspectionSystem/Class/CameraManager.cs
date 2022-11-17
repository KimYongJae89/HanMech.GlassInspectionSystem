using Device.Camera;
using Device.Edge;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassInspectionSystem.Class
{
    public class CameraManager : ICameraManager
    {
        private ICameraManager _cameraManager = null;

        public eCameraStatus CreateObject(eCameraType type)
        {
            switch (type)
            {
                case eCameraType.Basler:
                    _cameraManager = new BaslerCamera();
                    break;

                case eCameraType.HIK:
                    _cameraManager = new HikCamera();
                    break;

                default:
                    break;
            }
            return eCameraStatus.CAM_CONNECTION_SUCCESS;
        }

        public ICameraManager GetObject()
        {
            return _cameraManager;
        }

        public override eCameraStatus Initialize(List<CameraProperty> camPropertyList, int camMaxCount)
        {
            if (_cameraManager == null)
                return eCameraStatus.CAM_CONNECTION_ERR;

            eCameraStatus ret = _cameraManager.Initialize(camPropertyList, camMaxCount);

            _cameraManager.SetFovGlassHeight(Settings.Instance().Operation.Fov, Settings.Instance().Operation.GlassHeight);
            _cameraManager.SetUseGrabEdgeDetect(Settings.Instance().Operation.UseGrabEdgeDetect);

            return ret;
        }

        public override void SetTriggerOff()
        {
            if (_cameraManager == null)
                return;
            _cameraManager.SetTriggerOff();
        }

        public override bool StartGrab()
        {
            if (_cameraManager == null)
                return false;
            return _cameraManager.StartGrab();
        }

        public override bool StopGrab()
        {
            if (_cameraManager == null)
                return false;
            return _cameraManager.StopGrab();
        }

        public override bool IsGrabbing()
        {
            if (_cameraManager == null)
                return false;
            return _cameraManager.IsGrabbing();
        }

        public override bool IsCallBackCompleted()
        {
            if (_cameraManager == null)
                return true;
            return _cameraManager.IsCallBackCompleted();
        }

        public override bool IsOpen()
        {
            if (_cameraManager == null)
                return false;
            return _cameraManager.IsOpen();
        }

        public override bool IsOpen(int camNo)
        {
            if (_cameraManager == null)
                return false;
            return _cameraManager.IsOpen(camNo);
        }

        public override void SetExpose(int camNo, double expose)
        {
            if (_cameraManager == null)
                return;
            _cameraManager.SetExpose(camNo, expose);
        }

        public override double GetExpose(int camNo)
        {
            if (_cameraManager == null)
                return 0;
            return _cameraManager.GetExpose(camNo);
        }

        public override void SetLineRate(double vel)
        {
            if (_cameraManager == null)
                return;
            _cameraManager.SetLineRate(vel);
        }

        public override double GetLineRate(int camNo)
        {
            if (_cameraManager == null)
                return 0.0;
            return _cameraManager.GetLineRate(camNo);
        }

        public override void SetProperty(object param)
        {
            if (_cameraManager == null)
                return;
            _cameraManager.SetProperty(param);
        }

        public override void SetProperty(int camNo, object param)
        {
            if (_cameraManager == null)
                return;
            _cameraManager.SetProperty(camNo, param);
        }

        public override object GetProperty(int camNo)
        {
            if (_cameraManager == null)
                return null;
            return _cameraManager.GetProperty(camNo);
        }

        public override void Terminate()
        {
            if (_cameraManager == null)
                return;
            _cameraManager.StopGrab();
            _cameraManager.Terminate();
        }

        public override void SetSubImageList(int camNo, List<Bitmap> subImageList, Bitmap prevImage)
        {
            if (_cameraManager == null)
                return;

            _cameraManager.SetSubImageList(camNo, subImageList, prevImage);
        }

        public override void SetFinallyEdgeList(int camNo, List<EdgeElement> finallyEdgeList)
        {
            if (_cameraManager == null)
                return;
            _cameraManager.SetFinallyEdgeList(camNo, finallyEdgeList);
        }

        public override void SetTransportLayer(int camCount)
        {
            if (_cameraManager == null)
                return;
            _cameraManager.SetTransportLayer(camCount);
        }

        public override void SetFovGlassHeight(double fov, int glassHeight)
        {
            if (_cameraManager == null)
                return;
            _cameraManager.SetFovGlassHeight(fov, glassHeight);
        }

        public override int TotalSubImageCount()
        {
            if (_cameraManager == null)
                return -1;
            return _cameraManager.TotalSubImageCount();
        }

        public override List<ICamera> GetCameraList()
        {
            if (_cameraManager == null)
                return new List<ICamera>();
            return _cameraManager.GetCameraList();
        }

        public override Bitmap GetMergeImage(int camNo)
        {
            if (_cameraManager == null)
                return null;
            return _cameraManager.GetMergeImage(camNo);
        }

        public override void SetMaxCamCount(int maxCamCount)
        {
            if (_cameraManager == null)
                return;
            _cameraManager.SetMaxCamCount(maxCamCount);
        }

        public override int GetMaxCamCount(int camNo)
        {
            if (_cameraManager == null)
                return -1;

            return _cameraManager.GetMaxCamCount(camNo);
        }

        public override void SetUseGrabEdgeDetect(bool isUseGrabEdgeDetect)
        {
            if (_cameraManager == null)
                return;
            _cameraManager.SetUseGrabEdgeDetect(isUseGrabEdgeDetect);
        }

        public override int GetConnectedCount()
        {
            if (_cameraManager == null)
                return 0;
            return _cameraManager.GetConnectedCount();
        }

        public override void SetEnableShading(int camNo, bool enableShadig)
        {
            if (_cameraManager == null)
                return;
            _cameraManager.SetEnableShading(camNo, enableShadig);
        }

        public override bool IsEnableShading(int camNo)
        {
            if (_cameraManager == null)
                return false;
            return _cameraManager.IsEnableShading(camNo);
        }

        public override void Shading(int camNo, eShadingType type)
        {
            if (_cameraManager == null)
                return;
            _cameraManager.Shading(camNo, type);
        }

        public override void SetMergeImageCount(int count)
        {
            if (_cameraManager == null)
                return;

            _cameraManager.SetMergeImageCount(count);
        }
    }
}