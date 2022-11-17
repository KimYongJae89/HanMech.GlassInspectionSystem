using Basler.Pylon;
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
    public class BaslerCamera : ICameraManager
    {
        private List<ICamera> _cameraList = new List<ICamera>();
        private System.Threading.Thread _actionThread = null;
        private bool _isGrabMode = false;
        public static int PACKET_SIZE = 9000;
        public static int INTER_PACKET_DELAY = 500;
        public static int GIGE_PROTOCOL_OVERHEAD = 14;
    

        public override eCameraStatus Initialize(List<CameraProperty> camProList, int camMaxCount)
        {
            try
            {
                List<ICameraInfo> cameraInfoList = CameraFinder.Enumerate();

                if (cameraInfoList.Count == 0 || camProList.Count == 0)
                    return eCameraStatus.CAM_NOT_FOUND;

                for (int i = 0; i < camMaxCount; i++)
                {
                    for (int j = 0; j < cameraInfoList.Count; j++) // 찾은 카메라 만큼 반복합니다.
                    {
                        if (camProList[i].SerialNumber == cameraInfoList[j].GetValueOrDefault(CameraInfoKey.SerialNumber, "Nothing")) // 연결하려는 카메라인지 검사합니다.
                        {
                            /* 카메라를 셋팅합니다. */
                            _cameraList.Add(new BaslerLineScan(new Basler.Pylon.Camera(cameraInfoList[j])));
                            _cameraList[i].SetCamNo(i);
                            _cameraList[i].SetMaxCamCount(camMaxCount);
                            _cameraList[i].SetProperty(camProList[i]);
                            _cameraList[i].Initialize();
                            _cameraList[i].ActiveProperty();
                            break;
                        }
                    }
                }
                SetTriggerOff();

                return eCameraStatus.CAM_CONNECTION_SUCCESS;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured!", ex.Message);
                System.Windows.Forms.MessageBox.Show("Camera Not Found!");
                return eCameraStatus.CAM_NOT_FOUND;
            }
        }

        public override void SetTriggerOff()
        {
            foreach (ICamera camera in _cameraList)
            {
                camera.SetTriggerOff();
            }
        }

        public override void Terminate()
        {
            foreach (ICamera camera in this._cameraList)
            {
                camera.Terminate();
            }
        }

        public override void SetProperty(object param)
        {
            foreach (ICamera camera in _cameraList)
            {
                camera.SetProperty(param);
            }
        }

        public override void SetProperty(int camNo, object param)
        {
            if (_cameraList.Count == 0)
                return;
            _cameraList[camNo].SetProperty(param);
        }

        public override object GetProperty(int camNo)
        {
            if (_cameraList.Count == 0)
                return null;
            return _cameraList[camNo].GetProperty();
        }

        public override List<ICamera> GetCameraList()
        {
            return _cameraList;
        }

        public override void SetMaxCamCount(int maxCamCount)
        {
            foreach (ICamera camera in _cameraList)
            {
                camera.SetMaxCamCount(maxCamCount);
            }
        }

        public override int GetMaxCamCount(int camNo)
        {
            if (_cameraList.Count == 0)
                return 0;
            return _cameraList[camNo].GetMaxCamCount();
        }

        public override int GetConnectedCount()
        {
            if (_cameraList.Count == 0)
                return 0;
            return _cameraList.Count;
        }

        public override bool IsOpen()
        {
            bool ret = true;
            foreach (ICamera camera in _cameraList)
            {
                ret |= camera.IsOpen();
            }
            return ret;
        }

        public override bool IsOpen(int camNo)
        {
            if (_cameraList.Count == 0)
                return false;
            return _cameraList[camNo].IsOpen();
        }

        public override bool StartGrab()
        {
            bool ret = true;
            _isGrabMode = true;
            Console.WriteLine("Start Grab");
            foreach (ICamera camera in _cameraList)
            {
                ret |= camera.StartGrab();
            }
            return ret;
        }

        public override bool IsGrabbing()
        {
            bool ret = true;
            foreach (ICamera camera in _cameraList)
            {
                bool te = camera.IsGrabbing();
                ret &= camera.IsGrabbing();
            }
            return ret;
        }

        public override bool IsCallBackCompleted()
        {
            bool ret = true;
            foreach (ICamera camera in _cameraList)
            {
                bool te = camera.IsCallBackCompleted();
                ret &= camera.IsCallBackCompleted();
            }
            return ret;
        }

        public override bool StopGrab()
        {
            bool ret = true;
            foreach (ICamera camera in _cameraList)
            {
                ret |= camera.StopGrab();
            }
            _isGrabMode = false;
            return ret;
        }

        public override void SetExpose(int camNo, double expose)
        {
            if (_cameraList.Count == 0)
                return;
            if (expose <= 0.002)
                expose = 0.002;
            _cameraList[camNo].SetExpose(expose);
        }

        public override double GetExpose(int camNo)
        {
            if (_cameraList.Count == 0)
                return 0;
            return _cameraList[camNo].GetExpose();
        }

        public override void SetLineRate(double vel)
        {
            foreach (ICamera camera in _cameraList)
            {
                camera.SetLineRate(vel);
            }
        }

        public override double GetLineRate(int camNo)
        {
            if (_cameraList.Count == 0)
                return 0;
            return _cameraList[camNo].GetLineRate();
        }

        public override void SetTransportLayer(int camCount)
        {
            for (int i = 0; i < _cameraList.Count; i++)
            {
                _cameraList[i].SetTransportLayer(camCount);
            }
        }

        public override void SetFovGlassHeight(double fov, int glassHeight)
        {
            for (int i = 0; i < _cameraList.Count; i++)
            {
                _cameraList[i].SetFovGlassHeight(fov, glassHeight);
            }
        }

        public override void SetSubImageList(int camNo, List<Bitmap> subImageList, Bitmap prevImage)
        {
            _cameraList[camNo].SetSubImageList(subImageList, prevImage);
        }

        public override int TotalSubImageCount()
        {
            int count = 0;
            for (int i = 0; i < _cameraList.Count; i++)
            {
                count += _cameraList[i].SubNoMax;
            }
            return count;
        }

        public override Bitmap GetMergeImage(int camNo)
        {
            if (_cameraList.Count == 0)
                return null;
            return _cameraList[camNo].GetMergeImage();
        }

        public override void SetUseGrabEdgeDetect(bool isUseGrabEdgeDetect)
        {
            foreach (ICamera camera in _cameraList)
            {
                camera.UseGrabEdgeDetect = isUseGrabEdgeDetect;
            }
        }

        public override void SetFinallyEdgeList(int camNo, List<EdgeElement> finallyEdgeList)
        {
            _cameraList[camNo].SetFinallyEdgeList(finallyEdgeList);
        }

        public override void SetEnableShading(int camNo, bool enableShadig)
        {
            if (_cameraList.Count == 0)
                return;
            _cameraList[camNo].SetEnableShading(enableShadig);
        }

        public override bool IsEnableShading(int camNo)
        {
            if (_cameraList.Count == 0)
                return false;
            return _cameraList[camNo].IsEnableShading();
        }

        public override void Shading(int camNo, eShadingType type)
        {
            if (_cameraList.Count == 0)
                return;
            _cameraList[camNo].Shading(type);
        }

        public override void SetMergeImageCount(int count)
        {
            foreach (ICamera camera in _cameraList)
            {
                camera.SetMergeImageCount(count);
            }
        }
    }
}