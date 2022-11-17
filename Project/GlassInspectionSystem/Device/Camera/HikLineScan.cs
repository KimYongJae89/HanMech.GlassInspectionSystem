using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Device.Edge;
using HMechLogLib;
using HMechUtility;
using MvCamCtrl.NET;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace Device.Camera
{
    public class HikLineScan : ICamera
    {
        private List<EdgeElement> _edgeList = new List<EdgeElement>();
        private List<EdgeElement> _finallyEdgeList = null;
        private CameraProperty _property = new CameraProperty();

        private List<Bitmap> _subImageList = null;

        private Bitmap _prevBitmap = null;
        private bool _isConnectedError = false;
        private bool _isGrabbing = false;
        private int _maxCamCount = 0;
        private int _grabCount = 0;
        private int _subNo = 0;
        private int _camNo = 0;

        public UInt64 _startIndex = 0;
        private Bitmap _mergeImage = null;
        private int _mergeCount = 0;

        private bool _isTopDetect = false;
        private bool _isFirstGrab = false;

        public bool Accessible = false; // 끊김 체크
        private bool _isCallBackCompleted = true;

        private bool _isConnected = false;

        private bool _isopen = false;
        private MyCamera.cbOutputExdelegate ImageCallback;

        public override eCameraStatus Initialize()
        {
            try
            {
                if (HikCamera.CameraContextList[_camNo] == null)
                {
                    Logger.Write(eLogType.ERROR, "Camera is not connected", DateTime.Now);
                    return eCameraStatus.CAM_CONNECTION_FAIL_CAM_NULL;
                }
                if (OpenDevice())
                    _isConnected = true;
                else
                    _isConnected = false;

                _isopen = true;

                if (!IsAccessible())
                    return eCameraStatus.CAM_CONNECTION_FAIL_CAM_NULL;

                // Trigger Off
                SetTriggerOff();

                SetTransportLayer(_maxCamCount);
                SetProperty(this._property);

                ImageCallback = new MyCamera.cbOutputExdelegate(OnImageGrabbed);
                int nRet = HikCamera.CameraContextList[_camNo].MV_CC_RegisterImageCallBackEx_NET(ImageCallback, IntPtr.Zero);
                if (nRet != MyCamera.MV_OK)
                {
                    Console.WriteLine("Register Image CallBack Failed");
                    return eCameraStatus.CAM_CONNECTION_FAIL_INTERNAL_ERROR;
                }
                return eCameraStatus.CAM_CONNECTION_SUCCESS;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return eCameraStatus.CAM_CONNECTION_ERR;
            }
        }

        private bool IsAccessible()
        {
            try
            {
                if (HikCamera.CameraContextList[_camNo] == null)
                {
                    Logger.Write(eLogType.ERROR, "Camera is not connected", DateTime.Now);
                    _isConnected = false;
                }

                return HikCamera.CameraContextList[_camNo].MV_CC_IsDeviceConnected_NET();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

                return false;
            }
        }

        public override void SetMaxCamCount(int maxCamCount)
        {
            this._maxCamCount = maxCamCount;
        }

        public override int GetMaxCamCount()
        {
            return this._maxCamCount;
        }

        public override void SetCamNo(int camNo)
        {
            this._camNo = camNo;
        }

        public override int GetCamNo()
        {
            return _camNo;
        }

        public override void SetProperty(object param)
        {
            this._property = (CameraProperty)param;
        }

        public override object GetProperty()
        {
            return _property;
        }

        public override void SetFovGlassHeight(double fov, int glassHeight)
        {
            base.Fov = fov;
            base.GlassHeight = glassHeight;
        }

        public override void SetTransportLayer(int camCount)
        {
            //int interPacket = (HikCamera.PACKET_SIZE + HikCamera.GIGE_PROTOCOL_OVERHEAD) * (camCount * 1);
            int interPacket = (HikCamera.PACKET_SIZE + HikCamera.GIGE_PROTOCOL_OVERHEAD) * (camCount - 1);
            int frameTransmissionDelay = (HikCamera.PACKET_SIZE + HikCamera.GIGE_PROTOCOL_OVERHEAD) * this._camNo;

            int nRet = HikCamera.CameraContextList[_camNo].MV_CC_SetIntValueEx_NET("GevSCPSPacketSize", HikCamera.PACKET_SIZE);
            if (nRet != MyCamera.MV_OK)
                Console.WriteLine("PacketSize Setting Failed PacketSize : {0}, camNum : {1}", HikCamera.PACKET_SIZE, _camNo);

            nRet = HikCamera.CameraContextList[_camNo].MV_CC_SetIntValueEx_NET("GevSCPD", interPacket);
            if (nRet != MyCamera.MV_OK)
                Console.WriteLine("InterPacket Setting Failed PacketSize : {0}, camNum : {1}", interPacket, _camNo);
        }

        public override List<Bitmap> GetSubImageList()
        {
            return _subImageList;
        }

        public override void SetSubImageList(List<Bitmap> subImageList, Bitmap prevImage)
        {
            _subNo = 0;
            _subImageList = subImageList;
            _prevBitmap = prevImage;
        }
        public override void SetFinallyEdgeList(List<EdgeElement> finallyEdgeList)
        {
            _finallyEdgeList = finallyEdgeList;
        }

        public override int GetSubNo()
        {
            return _subNo;
        }

        public override bool IsGrabbing()
        {
            return this._isGrabbing;
        }
        public override void SetLineRate(double vel)
        {
            try
            {
                if (!IsOpen())
                    return;

                if (vel <= 100)
                    vel = 100;

                HikCamera.CameraContextList[_camNo].MV_CC_SetAcquisitionLineRate_NET((uint)vel);
            }
            catch (Exception err)
            {
                Logger.WriteException(eLogType.ERROR, err);
            }
        }

        public override double GetLineRate()
        {
            MyCamera.MVCC_INTVALUE intval = new MyCamera.MVCC_INTVALUE();
            int nRet = HikCamera.CameraContextList[_camNo].MV_CC_GetAcquisitionLineRate_NET(ref intval);
            if (nRet != MyCamera.MV_OK)
                Console.WriteLine("GetLineRate Failed  nRet : {0}, camNum : {1}", nRet, _camNo);
            return intval.nCurValue;
        }

        public override void ActiveProperty()
        {
            int nRet;
            nRet = HikCamera.CameraContextList[_camNo].MV_CC_SetIntValueEx_NET("Width", this._property.Width);
            if (nRet != MyCamera.MV_OK)
                Console.WriteLine("Set width Failed {0}", this._camNo);

            nRet = HikCamera.CameraContextList[_camNo].MV_CC_SetIntValueEx_NET("OffsetX", this._property.Offset);
            if (nRet != MyCamera.MV_OK)
                Console.WriteLine("Set offsetX Failed {0}", this._camNo);

            nRet = HikCamera.CameraContextList[_camNo].MV_CC_SetFloatValue_NET("ExposureTime", (float)this._property.Exposure * 1000);
            if (nRet != MyCamera.MV_OK)
                Console.WriteLine("Set ExposureTime Failed {0}", this._camNo);

            nRet = HikCamera.CameraContextList[_camNo].MV_CC_SetIntValueEx_NET("Height", this._property.Height);
            if (nRet != MyCamera.MV_OK)
                Console.WriteLine("Set Height Failed {0}", this._camNo);
        }
        public override bool StartGrab()
        {
            try
            {
                //if (!IsAccessible())
                //    return false;

                if (!IsOpen())
                {
                    string message = "camera context is null. cam index : " + _camNo.ToString();
                    Logger.Write(eLogType.ERROR, message, DateTime.Now);
                    return false;
                }

                _grabCount = 0;
                _isFirstGrab = true;
                _startIndex = 0;
                _isTopDetect = false;
                _edgeList.Clear();

                if (!IsGrabbing())
                {
                    HikCamera.CameraContextList[_camNo].MV_CC_StartGrabbing_NET();
                    _isGrabbing = true;
                }
                return true;
            }
            catch (Exception err)
            {
                Logger.WriteException(eLogType.ERROR, err);
                return false;
            }
        }

        public override bool IsOpen()
        {
            if (HikCamera.CameraContextList[_camNo] == null)
            {
                this._isConnectedError = true;
                string message = "CamNo : " + _camNo.ToString() + " CameraContext = null ";
                Logger.Write(eLogType.ERROR, message, DateTime.Now);
                return false;
            }

            _isopen = true;

            bool ret = HikCamera.CameraContextList[_camNo].MV_CC_IsDeviceConnected_NET();

            if (ret == false)
            {
                string message = "CamNo : " + _camNo.ToString() + " IsOpen Error_Accessible : " + Accessible.ToString() + " IsConnected : "
                    + this._isConnected.ToString() + " IsOpen : " + this.IsOpen().ToString();

                Logger.Write(eLogType.ERROR, message, DateTime.Now);

                this._isConnectedError = true;
            }
            else
                this._isConnectedError = false;

            if (!ret)
            {
                if (DeleDisConnected != null)
                    DeleDisConnected(_camNo);
            }
            return ret;
        }

        public override bool StopGrab()
        {
            try
            {
                //if (!IsAccessible())
                //    return false;
                //if (_isGrabbing)
                HikCamera.CameraContextList[_camNo].MV_CC_StopGrabbing_NET();

                _isFirstGrab = false;
                _isGrabbing = false;
                Console.WriteLine("Stop Grab");
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void Terminate()
        {
            try
            {
                int nRet;

                nRet = HikCamera.CameraContextList[_camNo].MV_CC_StopGrabbing_NET();
                _isGrabbing = false;

                // Trigger Off
                SetTriggerOff();

                nRet = HikCamera.CameraContextList[_camNo].MV_CC_CloseDevice_NET();
                _isopen = false;

                nRet = HikCamera.CameraContextList[_camNo].MV_CC_DestroyDevice_NET();
                if (nRet == MyCamera.MV_OK)
                    Console.WriteLine("Destory Camera : Camnum {0}", _camNo);
                HikCamera.CameraContextList[_camNo] = null;
                //SubImageListClear();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        private void ReadyMergeImage(int width, int height, bool isLive)
        {
            if (_mergeImage != null)
            {
                _mergeImage.Dispose();
                _mergeImage = null;
            }

            double calc = (double)base.GlassHeight / ((double)base.Fov / (double)width);
            int mergeHeight = 0;
            if (isLive)
            {
                base.SubNoMax = 1;
                mergeHeight = height;
            }
            else
            {
                if (!this.UseGrabEdgeDetect)
                    return;
                //base.SubNoMax = (int)(calc / height) + 2; // 2 : 처음 Edge 앞의 Image와 마지막 Edge 다음 Image
                base.SubNoMax = (int)(calc / height) + 5; // 3 : 처음 Edge 앞의 Image와 마지막 Edge 다음 Image 와 LineRate 값이 안맞아 늘어질 경우를 생각
                mergeHeight = height * base.SubNoMax;
            }

            _mergeImage = new Bitmap(width, mergeHeight, PixelFormat.Format8bppIndexed);
            ColorPalette paletee = _mergeImage.Palette;

            Color[] _entries = paletee.Entries;
            for (int i = 0; i < 256; i++)
            {
                Color b = new Color();
                b = Color.FromArgb((byte)i, (byte)i, (byte)i);
                _entries[i] = b;
            }
            _mergeImage.Palette = paletee;
        }
        private void AddSubImage(Bitmap bmp)
        {
            try
            {
                _subImageList.Add((Bitmap)bmp.Clone());
                lock (ICamera.ObjLock)
                {
                    ICamera.SubImageInfoList.Enqueue(new SubImg(_camNo, _subNo, bmp.Width, bmp.Height));
                    //Console.WriteLine("CamNo : " + _camNo.ToString() + "  SubNo : " + _subNo.ToString());
                }
                if (base.UseGrabEdgeDetect)
                    AddImageInMerge(bmp, _subNo);

                SearchEdge(BitmapConverter.ToMat(bmp)); // _subNo 때문에 순서 중요

                _finallyEdgeList.Clear();
                _finallyEdgeList.AddRange(base.GetFinallyEdge(this._edgeList, this._maxCamCount));
                _subNo++;
                Console.WriteLine("CamNo : " + _camNo.ToString() + " SubCount : " + _subImageList.Count() + " SubNoMax : " + base.SubNoMax.ToString());
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void SearchEdge(Mat mat)
        {
            if (this._camNo == 0) // Top,Left,Bottom
            {
                EdgeElement leftElement = EdgeDetect.FindLeftEdgeIndex(mat, _camNo, _subNo);
                EdgeElement topElement = EdgeDetect.FindTopEdgeIndex(mat, _camNo, _subNo, true);
                EdgeElement bottomElement = EdgeDetect.FindBottomEdgeIndex(mat, _camNo, _subNo);

                if (leftElement.Index != -1)
                {
                    _edgeList.Add(leftElement);
                    lock (ICamera.ObjLockEdgeInsp)
                    {
                        ICamera.LeftRightEdgeInfoList.Enqueue(leftElement.Copy());
                    }
                }

                if (topElement.Index != -1)
                {
                    _edgeList.Add(topElement);
                }

                if (bottomElement.Index != -1)
                    _edgeList.Add(bottomElement);
            }
            else if (this._camNo == (this._maxCamCount - 1))// Top, Right, Bottom
            {
                EdgeElement rightElement = EdgeDetect.FindRightEdgeIndex(mat, _camNo, _subNo);
                EdgeElement topElement = EdgeDetect.FindTopEdgeIndex(mat, _camNo, _subNo, true);
                EdgeElement bottomElement = EdgeDetect.FindBottomEdgeIndex(mat, _camNo, _subNo);

                if (rightElement.Index != -1)
                {
                    _edgeList.Add(rightElement);
                    lock (ICamera.ObjLockEdgeInsp)
                    {
                        ICamera.LeftRightEdgeInfoList.Enqueue(rightElement.Copy());
                    }
                }

                if (topElement.Index != -1)
                    _edgeList.Add(topElement);

                if (bottomElement.Index != -1)
                    _edgeList.Add(bottomElement);
            }
            else // Top, Bottom
            {
                EdgeElement topElement = EdgeDetect.FindTopEdgeIndex(mat, _camNo, _subNo, true);
                EdgeElement bottomElement = EdgeDetect.FindBottomEdgeIndex(mat, _camNo, _subNo);

                if (topElement.Index != -1)
                    _edgeList.Add(topElement);

                if (bottomElement.Index != -1)
                    _edgeList.Add(bottomElement);
            }
        }

        private void AddImageInMerge(Bitmap bmp, int subNo)
        {
            try
            {
                if (_mergeImage == null)
                    return;
                unsafe
                {
                    BitmapData subBmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
                    byte* subData = (byte*)(void*)subBmpData.Scan0;

                    UInt64 startIndex = (UInt64)(subBmpData.Stride * bmp.Height) * (UInt64)subNo;
                    UInt64 length = (UInt64)(subBmpData.Stride * bmp.Height);

                    BitmapData targetBmpData = _mergeImage.LockBits(new Rectangle(0, 0, _mergeImage.Width, _mergeImage.Height), ImageLockMode.ReadWrite, _mergeImage.PixelFormat);
                    byte* targetData = (byte*)(void*)targetBmpData.Scan0 + startIndex;

                    UInt64 mergeLength = (UInt64)(targetBmpData.Stride * _mergeImage.Height);

                    Buffer.MemoryCopy(subData, targetData, mergeLength, length);

                    bmp.UnlockBits(subBmpData);
                    _mergeImage.UnlockBits(targetBmpData);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        //         private void OnConnectionLost(Object sender, EventArgs e)
        //         {
        //             //카메라 연결이 끊어졌을 때
        //             Logger.Write(eLogType.ERROR, "OnConnectionLost has been called.", DateTime.Now);
        //
        //             if (BaslerCamera.CameraContextList[_camNo] != null)
        //             {
        //                 if (BaslerCamera.CameraContextList[_camNo].IsConnected)
        //                     BaslerCamera.CameraContextList[_camNo].Dispose();
        //
        //                 if (BaslerCamera.CameraContextList[_camNo].IsOpen)
        //                     BaslerCamera.CameraContextList[_camNo].Close();
        //
        //                 _isConnectedError = true;
        //             }
        //         }

        private void OnImageGrabbed(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX FrameInfo, IntPtr pUser)
        {
            try
            {
                _isCallBackCompleted = false;
                if (pData == null)
                    return;

                if (FrameInfo.nWidth != this._property.Width || FrameInfo.nHeight != this._property.Height)
                {
                    Console.WriteLine("GrabImage err GrabWxH : " + FrameInfo.nWidth + "x" + FrameInfo.nHeight + ", ProWxH : " + this._property.Width + "x" + this._property.Height);
                    _isCallBackCompleted = true;
                    return;
                }

                if (_isFirstGrab)
                {
                    _isFirstGrab = false;
                    ReadyMergeImage(FrameInfo.nWidth, FrameInfo.nHeight, ICamera.IsLive);
                }
                int size = FrameInfo.nWidth * FrameInfo.nHeight;
                byte[] buffer = new byte[size];

                Marshal.Copy(pData, buffer, 0, size);

                Bitmap grabBitmap = ImageHelper.ConvertToGrey8BitBitmap(buffer, FrameInfo.nWidth, FrameInfo.nHeight);
                Mat grabMat = BitmapConverter.ToMat(grabBitmap);

                _grabCount++;

                if (ICamera.IsLive)
                {
                    //if (_property.TriggerMode.Equals(eCamTriggerMode.FREERUN))
                    //{
                    //    AddSubImage(grabBitmap);
                    //    grabMat.Dispose();
                    //}
                }
                else
                {
                    if (base.UseGrabEdgeDetect)
                    {
                        if (_subImageList.Count == base.SubNoMax)
                        {
                            grabMat.Dispose();
                            StopGrab();
                            _isCallBackCompleted = true;
                            return;
                        }
                        if (_subImageList.Count > base.SubNoMax)
                        {
                            grabMat.Dispose();
                            StopGrab();
                            _isCallBackCompleted = true;
                            return;
                        }
                        else
                        {
                            if (_isTopDetect == false)
                            {
                                EdgeElement element = EdgeDetect.FindTopEdgeIndex(grabMat, _camNo, _grabCount, true);
                                if (element.Index != -1)
                                {
                                    _isTopDetect = true;
                                    AddSubImage(_prevBitmap);
                                    AddSubImage(grabBitmap);
                                }
                            }
                            else
                            {
                                AddSubImage(grabBitmap);
                            }
                            grabMat.Dispose();
                        }
                    }
                    else
                    {
                        AddSubImage(grabBitmap);
                        grabMat.Dispose();
                    }

                    if (_isTopDetect == false)
                    {
                        if (_prevBitmap != null)
                        {
                            _prevBitmap.Dispose();
                            _prevBitmap = null;
                        }
                        _prevBitmap = (Bitmap)grabBitmap.Clone();
                    }
                }

                _isCallBackCompleted = true;
                _grabCount++;
            }
            catch (Exception err)
            {
                _isCallBackCompleted = true;
                _finallyEdgeList.AddRange(base.GetFinallyEdge(this._edgeList, this._maxCamCount));
                Logger.WriteException(eLogType.ERROR, err);
            }
        }

        public override Bitmap GetMergeImage()
        {
            if (base.UseGrabEdgeDetect)
                return _mergeImage;
            else
            {
                if (_mergeImage != null)
                {
                    _mergeImage.Dispose();
                    _mergeImage = null;
                }
                if (_subImageList.Count <= 0)
                    return null;

                _mergeImage = new Bitmap(_subImageList[0].Width, _subImageList[0].Height * _mergeCount, PixelFormat.Format8bppIndexed);
                ColorPalette paletee = _mergeImage.Palette;

                Color[] _entries = paletee.Entries;
                for (int i = 0; i < 256; i++)
                {
                    Color b = new Color();
                    b = Color.FromArgb((byte)i, (byte)i, (byte)i);
                    _entries[i] = b;
                }
                _mergeImage.Palette = paletee;
                for (int i = 0; i < _mergeCount; i++)
                {
                    AddImageInMerge(_subImageList[i], i);
                }
                return _mergeImage;
            }
        }

        public override void SetEnableShading(bool enableShading)
        {
            HikCamera.CameraContextList[_camNo].MV_CC_SetBoolValue_NET("NUCEnable", enableShading);
        }

        public override bool IsEnableShading()
        {
            bool ret = false;
            HikCamera.CameraContextList[_camNo].MV_CC_GetBoolValue_NET("NUCEnable", ref ret);
            return ret;
        }

        public override void Shading(eShadingType type)
        {
            HikCamera.CameraContextList[_camNo].MV_CC_SetCommandValue_NET("ActivateShading");
        }

        public override void SetExpose(double expose)
        {
            int nRet = HikCamera.CameraContextList[_camNo].MV_CC_SetFloatValue_NET("ExposureTime", (float)this._property.Exposure * 1000);
            if (nRet != MyCamera.MV_OK)
                Console.WriteLine("Set ExposureTime Failed {0}", this._camNo);
        }

        public override double GetExpose()
        {
            MyCamera.MVCC_FLOATVALUE stFloatVal = new MyCamera.MVCC_FLOATVALUE();
            return HikCamera.CameraContextList[_camNo].MV_CC_GetFloatValue_NET("ExposureTime", ref stFloatVal);
        }

        public override void SetMergeImageCount(int count)
        {
            _mergeCount = count;
        }

        private bool OpenDevice()
        {
            int nRet;
            int nPacketSize;
            bool ret = false;
            nRet = HikCamera.CameraContextList[_camNo].MV_CC_OpenDevice_NET();
            if (nRet != MyCamera.MV_OK)
            {
                Console.WriteLine("Failed Open Device");
                ret = false;
            }
            else
                ret = true;

            nPacketSize = HikCamera.CameraContextList[_camNo].MV_CC_GetOptimalPacketSize_NET();
            if (nPacketSize > 0)
            {
                nRet = HikCamera.CameraContextList[_camNo].MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)nPacketSize);
                if (nRet != MyCamera.MV_OK)
                {
                    Console.WriteLine("Failed Set Packet Size");
                    ret = false;
                }
                else
                    ret = true;
            }

            //nRet = HikCamera.CameraContextList[_camNo].MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
            //if (nRet != MyCamera.MV_OK)
            //{
            //    Console.WriteLine("Failed Set Trigger Mode");
            //    ret = false;
            //}
            //else
            //    ret = true;
            return ret;
        }
        private void SubImageListClear()
        {
            if (_subImageList.Count != 0)
            {
                foreach (Bitmap bmp in _subImageList)
                    bmp.Dispose();
                _subImageList.Clear();
            }
        }

        public override void SetTriggerOff()
        {
            HikCamera.CameraContextList[_camNo].MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
        }

        public override bool IsCallBackCompleted()
        {
            return _isCallBackCompleted;
        }
    }
}