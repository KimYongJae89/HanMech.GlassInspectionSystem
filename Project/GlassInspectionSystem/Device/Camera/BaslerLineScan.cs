using Basler.Pylon;
using Device.Edge;
using HMechLogLib;
using HMechUtility;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Device.Camera
{
    public class BaslerLineScan : ICamera
    {
        private Basler.Pylon.Camera _cameraContext = new Basler.Pylon.Camera();

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

        public BaslerLineScan(Basler.Pylon.Camera camera)
        {
            this._cameraContext = camera;
        }

        public override eCameraStatus Initialize()
        {
            try
            {
                if (_cameraContext == null)
                {
                    Logger.Write(eLogType.ERROR, "Camera is not connected", DateTime.Now);
                    return eCameraStatus.CAM_CONNECTION_FAIL_CAM_NULL;
                }

                if (!IsAccessible())
                    return eCameraStatus.CAM_CONNECTION_FAIL_CAM_NULL;

                _cameraContext.Open();

                _property.SerialNumber = _cameraContext.CameraInfo.GetValueOrDefault(CameraInfoKey.SerialNumber, "Nothing");
                _property.CamName = _cameraContext.CameraInfo.GetValueOrDefault(CameraInfoKey.FullName, "Nothing");
                _property.CamAddress = _cameraContext.CameraInfo.GetValueOrDefault(CameraInfoKey.DeviceIpAddress, "Nothing");

                _cameraContext.CameraOpened += Configuration.AcquireContinuous;
                _cameraContext.StreamGrabber.ImageGrabbed += OnImageGrabbed;

                // Trigger Off
                SetTriggerOff();

                SetTransportLayer(this._maxCamCount);
                _cameraContext.Parameters[(EnumName)"PixelFormat"].TrySetValue("Mono8");

                SetProperty(this._property);

                return eCameraStatus.CAM_CONNECTION_SUCCESS;
            }
            catch (Exception err)
            {
                Logger.WriteException(eLogType.ERROR, err);
                return eCameraStatus.CAM_CONNECTION_ERR;
            }
        }

        private bool IsAccessible()
        {
            if (_cameraContext == null)
                return false;
            DeviceAccessibilityInfo accessInfo = CameraFinder.GetDeviceAccessibilityInfo(_cameraContext.CameraInfo);
            Accessible = accessInfo != DeviceAccessibilityInfo.NotReachable;
            return Accessible;
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
            // 객체 소멸 되는지 확인 필요
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
            int interPacket = (BaslerCamera.INTER_PACKET_DELAY + BaslerCamera.GIGE_PROTOCOL_OVERHEAD) * (camCount - 1);
            //0번 Cam부터 증가
            //int frameTransmissionDelay = (BaslerCamera.INTER_PACKET_DELAY + BaslerCamera.GIGE_PROTOCOL_OVERHEAD) * (camCount - this._camNo - 1);

            //마지막 Camo부터 증가
            int frameTransmissionDelay = (BaslerCamera.INTER_PACKET_DELAY + BaslerCamera.GIGE_PROTOCOL_OVERHEAD) * this._camNo;

            _cameraContext.Parameters[PLGigECamera.GevSCPSPacketSize].TrySetValue(BaslerCamera.PACKET_SIZE);
            _cameraContext.Parameters[PLGigECamera.GevSCPD].TrySetValue(interPacket);
            _cameraContext.Parameters[PLGigECamera.GevSCFTD].TrySetValue(frameTransmissionDelay);
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

                _cameraContext.Parameters[PLGigECamera.AcquisitionLineRateAbs].TrySetValue(vel);
            }
            catch (Exception err)
            {
                Logger.WriteException(eLogType.ERROR, err);
            }
        }

        public override double GetLineRate()
        {
            return _cameraContext.Parameters[PLGigECamera.ResultingLineRateAbs].GetValue();
        }
        
        public override void ActiveProperty()
        {
            _cameraContext.Parameters[PLGigECamera.OffsetX].TrySetValue(0);
            _cameraContext.Parameters[PLGigECamera.Width].TrySetValue(this._property.Width);
            _cameraContext.Parameters[PLGigECamera.OffsetX].TrySetValue(this._property.Offset);
            _cameraContext.Parameters[PLGigECamera.Height].TrySetValue(this._property.Height);
            _cameraContext.Parameters[PLGigECamera.ExposureTimeAbs].TrySetValue(this._property.Exposure * 1000);
        }

        public override bool StartGrab()
        {
            try
            {
                if (!IsOpen())
                {
                    string message = "camera context is null. cam index : " + _camNo.ToString();
                    Logger.Write(eLogType.ERROR, message, DateTime.Now);
                    return false;
                }

                _grabCount = 0;
                _isFirstGrab = true;
                _startIndex = 0;
                _isGrabbing = true;
                _isTopDetect = false;
                _edgeList.Clear();

                if (!_cameraContext.StreamGrabber.IsGrabbing)
                {
                    _cameraContext.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
                }
                return true;
            }
            catch (Exception err)
            {
                Logger.WriteException(eLogType.ERROR, err);
                return false;
            }
        }

        public override void SetTriggerOff()
        {
            // Get required Enumerations.
            IEnumParameter triggerSelector = _cameraContext.Parameters[PLCamera.TriggerSelector];
            IEnumParameter triggerMode = _cameraContext.Parameters[PLCamera.TriggerMode];

            // remember old selector value
            string oldSelectorValue = triggerSelector.IsReadable ? triggerSelector.GetValue() : null;

            // Turn trigger mode off for all trigger selector entries.
            foreach (string trigger in triggerSelector)
            {
                triggerSelector.SetValue(trigger);
                triggerMode.SetValue(PLCamera.TriggerMode.Off);
            }
        }

        public override bool IsOpen()
        {
            if (_cameraContext == null)
            {
                this._isConnectedError = true;
                string message = "CamNo : " + _camNo.ToString() + " CameraContext = null ";
                Logger.Write(eLogType.ERROR, message, DateTime.Now);
                return false;
            }

            if (this._isConnectedError)
                return false;

            bool ret = _cameraContext.IsConnected && _cameraContext.IsOpen;

            if (!ret)
            {
                string message = "CamNo : " + _camNo.ToString() + " IsOpen Error_Accessible : " + Accessible.ToString() + " IsConnected : "
                    + _cameraContext.IsConnected.ToString() + " IsOpen : " + _cameraContext.IsOpen.ToString();

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
            _cameraContext.StreamGrabber.Stop();
            _isFirstGrab = false;
            _isGrabbing = false;
            Console.WriteLine("Stop Grab");
            return true;
        }

        public override void Terminate()
        {
            if (_cameraContext != null)
            {
                if (_cameraContext.StreamGrabber.IsGrabbing)
                    _cameraContext.StreamGrabber.Stop();

                SetTriggerOff();

                if (_cameraContext.IsOpen)
                    _cameraContext.Close();

                if (_cameraContext != null)
                    _cameraContext.Dispose();

                _cameraContext = null;
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
                base.SubNoMax = (int)(calc / height) + 7; // 3 : 처음 Edge 앞의 Image와 마지막 Edge 다음 Image 와 LineRate 값이 안맞아 늘어질 경우를 생각
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
                //_subImageList.Add((Bitmap)bmp.Clone());
                _subImageList.Add(bmp);
                Mat mat = BitmapConverter.ToMat(bmp);
                lock (ICamera.ObjLock)
                {
                    ICamera.SubImageInfoList.Enqueue(new SubImg(_camNo, _subNo, bmp.Width, bmp.Height));
                }
                //if (base.UseGrabEdgeDetect)
                //    AddImageInMerge(bmp, _subNo);

                SearchEdge(mat); // _subNo 때문에 순서 중요

                _finallyEdgeList.Clear();
                _finallyEdgeList.AddRange(base.GetFinallyEdge(this._edgeList, this._maxCamCount));
                _subNo++;
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
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
                    if (leftElement.Index >= (mat.Width / 2))
                        return;
                    _edgeList.Add(leftElement);
                    lock(ICamera.ObjLockEdgeInsp)
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
                    if (rightElement.Index <= (mat.Width / 2))
                        return;

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

        private void OnConnectionLost(Object sender, EventArgs e)
        {
            //카메라 연결이 끊어졌을 때
            Logger.Write(eLogType.ERROR, "OnConnectionLost has been called.", DateTime.Now);

            if (_cameraContext != null)
            {
                if (_cameraContext.IsConnected)
                    _cameraContext.Dispose();

                if (_cameraContext.IsOpen)
                    _cameraContext.Close();

                _isConnectedError = true;
            }
        }

        private void OnImageGrabbed(Object sender, ImageGrabbedEventArgs e)
        {
            try
            {
                _isCallBackCompleted = false;
                IGrabResult grabResult = e.GrabResult;
                if (grabResult.GrabSucceeded == false)
                {
                    _isCallBackCompleted = true;
                    Console.WriteLine("OnImageGrabbed Error:[" + grabResult.ErrorCode + "]:" + grabResult.ErrorDescription);
                    Logger.Write(eLogType.ERROR, "OnImageGrabbed Error:[" + grabResult.ErrorCode + "]:" + grabResult.ErrorDescription);
                    return;
                }
                if (grabResult.Width != this._property.Width || grabResult.Height != this._property.Height)
                {
                    string message = string.Format("Image Size Err : [Setting] Width : {0}, Height : {1} [Grab] Width : {2}, Height : {3}"
                        , this._property.Width
                        , this._property.Height
                        , grabResult.Width
                        , grabResult.Height
                        );
                    Logger.Write(eLogType.ERROR, message);
                    _isCallBackCompleted = true;
                    return;
                }

                Console.WriteLine(grabResult.Width.ToString() + "   " + grabResult.Height.ToString());
                if (_isFirstGrab)
                {
                    _isFirstGrab = false;
                    ReadyMergeImage(grabResult.Width, grabResult.Height, ICamera.IsLive);
                }

                byte[] buffer = grabResult.PixelData as byte[];

                Bitmap grabBitmap = ImageHelper.ConvertToGrey8BitBitmap(buffer, grabResult.Width, grabResult.Height);
                Mat grabMat = BitmapConverter.ToMat(grabBitmap);

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
            finally
            {
                e.DisposeGrabResultIfClone();
            }
        }

        public override Bitmap GetMergeImage()
        {
            if (base.UseGrabEdgeDetect)
            {
                for (int i = 0; i < _subImageList.Count; i++)
                {
                    AddImageInMerge(_subImageList[i], i);
                }
                return _mergeImage;
            }
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
            _cameraContext.Parameters[PLGigECamera.ShadingEnable].TrySetValue(enableShading);
        }

        public override bool IsEnableShading()
        {
            return _cameraContext.Parameters[PLGigECamera.ShadingEnable].GetValue();
        }

        public override void Shading(eShadingType type)
        {
            if (type == eShadingType.Once)
                _cameraContext.Parameters[PLGigECamera.ShadingSetCreate].TrySetValue("Once");
            else if (type == eShadingType.Off)
                _cameraContext.Parameters[PLGigECamera.ShadingSetCreate].TrySetValue("Off");
            else
            { }
        }

        public override void SetExpose(double expose)
        {
            _cameraContext.Parameters[PLGigECamera.ExposureTimeAbs].TrySetValue(expose * 1000);
        }

        public override double GetExpose()
        {
            return _cameraContext.Parameters[PLGigECamera.ExposureTimeAbs].GetValue() / 1000;
        }

        public override void SetMergeImageCount(int count)
        {
            _mergeCount = count;
        }

        public override bool IsCallBackCompleted()
        {
            return _isCallBackCompleted;
        }
    }
}