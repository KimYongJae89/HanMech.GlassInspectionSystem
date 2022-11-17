using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Device.Camera;
using Device.Edge;
using MvCamCtrl.NET;

namespace Device.Camera
{
    public class HikCamera : ICameraManager
    {
        private MyCamera.MV_CC_DEVICE_INFO_LIST stDevList = new MyCamera.MV_CC_DEVICE_INFO_LIST();

        private List<ICamera> _cameraList = new List<ICamera>();
        private System.Threading.Thread _actionThread = null;
        private System.Threading.Thread _hReceiveImageThreadHandle = null;
        private bool _isGrabMode = false;
        public static int PACKET_SIZE = 1500;
        public static int GIGE_PROTOCOL_OVERHEAD = 36;

        public static List<MyCamera> CameraContextList = new List<MyCamera>();
        public static bool bStop = false;
        private static bool g_bExit = false;
        private static uint g_nPayloadSize = 0;

        public override eCameraStatus Initialize(List<CameraProperty> camProList, int camMaxCount)
        {
            try
            {
                int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref stDevList);
                if (nRet != MyCamera.MV_OK)
                    return eCameraStatus.CAM_CONNECTION_FAIL_NOT_FOUND_CAM;

                if (stDevList.nDeviceNum == 0 || camProList.Count == 0)
                    return eCameraStatus.CAM_CONNECTION_FAIL_NOT_FOUND_CAM;

                for (int i = 0; i < camMaxCount; i++)
                {
                    for (int j = 0; j < stDevList.nDeviceNum; j++)
                    {
                        MyCamera.MV_CC_DEVICE_INFO stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(stDevList.pDeviceInfo[j], typeof(MyCamera.MV_CC_DEVICE_INFO));

                        if (camProList[i].SerialNumber == GetSerialNumber(stDevInfo))
                        {
                            camProList[i] = SetCamProperty(stDevInfo);
                            _cameraList.Add(new HikLineScan());
                            CameraContextList.Add(new MyCamera());
                            CameraContextList[i].MV_CC_CreateDevice_NET(ref stDevInfo);
                            if (nRet != MyCamera.MV_OK)
                            {
                                Console.WriteLine("HIK Camera Create Device Failed.");
                            }
                            _cameraList[i].SetCamNo(i);
                            _cameraList[i].SetMaxCamCount(camMaxCount);
                            _cameraList[i].SetProperty(camProList[i]);
                            _cameraList[i].Initialize();
                            _cameraList[i].ActiveProperty();
                            break;
                        }
                    }
                }

                return eCameraStatus.CAM_CONNECTION_SUCCESS;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured!", ex.Message);
                System.Windows.Forms.MessageBox.Show("Camera Not Found!");
                return eCameraStatus.CAM_NOT_FOUND;
            }
        }

        private CameraProperty SetCamProperty(MyCamera.MV_CC_DEVICE_INFO stDevInfo)
        {
            MyCamera.MV_GIGE_DEVICE_INFO stGigEDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));

            CameraProperty camPropety = new CameraProperty();
            camPropety.CamName = stGigEDeviceInfo.chModelName + "#" + stGigEDeviceInfo.chSerialNumber;
            uint nIp1 = ((stGigEDeviceInfo.nCurrentIp & 0xff000000) >> 24);
            uint nIp2 = ((stGigEDeviceInfo.nCurrentIp & 0x00ff0000) >> 16);
            uint nIp3 = ((stGigEDeviceInfo.nCurrentIp & 0x0000ff00) >> 8);
            uint nIp4 = (stGigEDeviceInfo.nCurrentIp & 0x000000ff);
            camPropety.CamAddress = nIp1 + "." + nIp2 + "." + nIp3 + "." + nIp4;
            return camPropety;
        }

        public override void SetTriggerOff()
        {
            foreach (ICamera camera in this._cameraList)
            {
                camera.SetTriggerOff();
            }
        }

        public string GetCameraName(MyCamera.MV_CC_DEVICE_INFO stDevInfo)
        {
            if (MyCamera.MV_GIGE_DEVICE == stDevInfo.nTLayerType)
            {
                MyCamera.MV_GIGE_DEVICE_INFO stGigeDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                uint nIp1 = ((stGigeDeviceInfo.nCurrentIp & 0xff000000) >> 24);
                uint nIp2 = ((stGigeDeviceInfo.nCurrentIp & 0x00ff0000) >> 16);
                uint nIp3 = ((stGigeDeviceInfo.nCurrentIp & 0x0000ff00) >> 8);
                uint nIp4 = (stGigeDeviceInfo.nCurrentIp & 0x000000ff);
                string CamAddress = nIp1 + "." + nIp2 + "." + nIp3 + "." + nIp4;
                return CamAddress;
            }
            return "";
        }

        public string GetIpaddress(MyCamera.MV_CC_DEVICE_INFO stDevInfo)
        {
            if (MyCamera.MV_GIGE_DEVICE == stDevInfo.nTLayerType)
            {
                MyCamera.MV_GIGE_DEVICE_INFO stGigeDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                return stGigeDeviceInfo.chModelName + "#" + stGigeDeviceInfo.chSerialNumber; ;
            }
            return "";
        }
        private string GetSerialNumber(MyCamera.MV_CC_DEVICE_INFO stDevInfo)
        {
            if (MyCamera.MV_GIGE_DEVICE == stDevInfo.nTLayerType)
            {
                MyCamera.MV_GIGE_DEVICE_INFO stGigeDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                return stGigeDeviceInfo.chSerialNumber;
            }
            return "";
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
            g_bExit = true;
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
            if (expose <= 0.002 || _cameraList.Count == 0)
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

        public unsafe static T[] PtrToStructurs<T>(IntPtr pt, int lenth)
        {
            T[] structurs = new T[lenth];
            for (int i = 0; i < lenth; i++)
            {
                IntPtr ptr = new IntPtr((long)pt + (i * Marshal.SizeOf(typeof(T))));
                structurs[i] = (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            return structurs;
        }

        public static void ReceiveImageWorkThread(object obj)
        {
            int nRet = MyCamera.MV_OK;
            MyCamera device = obj as MyCamera;
            MyCamera.MV_FRAME_OUT_INFO_EX stImageInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();
            IntPtr pData = Marshal.AllocHGlobal((int)g_nPayloadSize);
            if (pData == IntPtr.Zero)
            {
                return;
            }
            uint nDataSize = g_nPayloadSize;

            while (true)
            {
                nRet = device.MV_CC_GetOneFrameTimeout_NET(pData, nDataSize, ref stImageInfo, 1000);
                if (nRet == MyCamera.MV_OK)
                {
                    Console.WriteLine("Get One Frame:" + "Width[" + Convert.ToString(stImageInfo.nWidth) + "] , Height[" + Convert.ToString(stImageInfo.nHeight)
                                    + "] , FrameNum[" + Convert.ToString(stImageInfo.nFrameNum) + "]");
                }
                else
                {
                    Console.WriteLine("No data:{0:x8}", nRet);
                }
                if (g_bExit)
                {
                    break;
                }
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
            //return false;
            return _cameraList[camNo].IsEnableShading();
        }

        public override void Shading(int camNo, eShadingType type)
        {
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