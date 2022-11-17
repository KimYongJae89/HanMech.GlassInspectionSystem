using Device.Camera;
using Device.PLC;
using Device.DIO;
using HMechLogLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenCvSharp.Extensions;
using OpenCvSharp;
using HMechUtility;
using System.Drawing;
using System.IO;
using enumType;
using System.Diagnostics;
using Device.Edge;

namespace GlassInspectionSystem.Class
{
    public class Sequence
    {
        private SubSequence _subSequence = null;
        private Thread _seqThread = null;

        private int _glassInSleepTime = 4000;
        private int _glassOutSleepTime = 10000;

        private bool _isStop = false;

        public bool IsStop
        {
            get { return _isStop; }
            set { _isStop = value; }
        }

        private eSeqStep _seqStep = eSeqStep.SEQ_STOP;

        public eSeqStep SeqStep
        {
            get { return _seqStep; }
            set { _seqStep = value; }
        }

        private string[] _loadFileNames = null;
        private bool _isLoadFiles = false;

        public void StartSequence()
        {
            _isStop = false;
            _seqThread = new Thread(ThreadFunc);
            _seqThread.Start();
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
                    FormMain.Instance().Log(eLogType.SEQ, "Light Off.", Status.Instance().NowTime, true);

                    Machine.Instance().CameraManager.StopGrab();   // Grab Stop
                    FormMain.Instance().Log(eLogType.SEQ, "Grab Stop.", Status.Instance().NowTime, true);

                    _isStop = true;
                }
                Thread.Sleep(5);
            }
        }

        private void SeqSteps()
        {
            try
            {
                if (_isLoadFiles)
                {
                    _seqStep = eSeqStep.SEQ_LOAD_IMAGE_INSPECTION;
                }
                switch (_seqStep)
                {
                    case eSeqStep.SEQ_LOAD_IMAGE_INSPECTION:

                        this._subSequence = new SubSequence(Settings.Instance().Operation.CamCount, true);
                        FormMain.Instance().Log(eLogType.SEQ, "Create SubSequence.", Status.Instance().NowTime);

                        this._subSequence.LoadSubImage(this._loadFileNames);
                        FormMain.Instance().Log(eLogType.SEQ, "Load Image.", Status.Instance().NowTime);

                        this._subSequence.GlassInTime = Status.Instance().NowTime;
                        this._subSequence.GlassID = Machine.Instance().GetGlassID(this._subSequence.GlassInTime);
                        FormMain.Instance().Log(eLogType.SEQ, "Get Glass ID(glassIn) : " + this._subSequence.GlassID, Status.Instance().NowTime);
                        FormMain.Instance().Log(eLogType.INSPECTION, "Get Glass ID(glassIn) : " + this._subSequence.GlassID, Status.Instance().NowTime);

                        this._subSequence.Start(true);
                        FormMain.Instance().Log(eLogType.SEQ, "SubSequence Start.", Status.Instance().NowTime);

                        _seqStep = eSeqStep.SEQ_GLASS_OUT;
                        _isLoadFiles = false;
                        _isStop = true;
                        break;

                    case eSeqStep.SEQ_STOP:
                        FormMain.Instance().Log(eLogType.SEQ, "Sequence Stop.", Status.Instance().NowTime);

                        Machine.Instance().LightOn(false);
                        FormMain.Instance().Log(eLogType.SEQ, "Light Off.", Status.Instance().NowTime);

                        Machine.Instance().CameraManager.StopGrab();   // Grab Stop
                        FormMain.Instance().Log(eLogType.SEQ, "Grab Stop.", Status.Instance().NowTime, true);

                        _isStop = true;
                        break;

                    case eSeqStep.SEQ_START:

                        FormMain.Instance().Log(eLogType.SEQ, "Main Sequence Start.", Status.Instance().NowTime, true);
                        _seqStep = eSeqStep.SEQ_INIT;

                        break;

                    case eSeqStep.SEQ_INIT:

                        Machine.Instance().LightOn(false);
                        FormMain.Instance().Log(eLogType.SEQ, "Light Off.", Status.Instance().NowTime, true);
                        Thread.Sleep(100);
                        Machine.Instance().SetLightValue(Settings.Instance().Operation.LightValue);

                        if (Settings.Instance().Operation.LineRateType == eLineRateType.ConstantVel)
                        {
                            SetLineRate(Settings.Instance().Operation.ConstantVel);
                        }
                        else if(Settings.Instance().Operation.LineRateType == eLineRateType.VariableVel)
                        {
                            int vel = Convert.ToInt16(Status.Instance().Plc.GetPacketValue(ePLCAddress.PLC_TARGET_VELOCITY));
                            SetLineRate(vel);
                        }

                        _seqStep = eSeqStep.SEQ_INSPECTION_WAIT;
                        FormMain.Instance().Log(eLogType.SEQ, "Wait Glass In.", Status.Instance().NowTime, true);
                        break;

                    case eSeqStep.SEQ_INSPECTION_WAIT:

                        if (!Machine.Instance().IsGlassIn())
                            break;
                        FormMain.Instance().Log(eLogType.SEQ, "Glass In.", Status.Instance().NowTime, true);


                        eCVDirection cvDirection = Machine.Instance().GetCVDirection();
                        if (cvDirection != eCVDirection.CW)
                        {
                            FormMain.Instance().Log(eLogType.SEQ, "CV Direction is not CW. Now : " + cvDirection.ToString(), Status.Instance().NowTime, true);
                            _seqStep = eSeqStep.SEQ_INIT;
                            break;
                        }

                        Machine.Instance().LightOn(true);
                        FormMain.Instance().Log(eLogType.SEQ, "Light On.", Status.Instance().NowTime, true);

                        GrabDelay(Settings.Instance().Operation.StartGrabDelay);

                        this._subSequence = new SubSequence(Settings.Instance().Operation.CamCount);
                        FormMain.Instance().Log(eLogType.SEQ, "Create SubSequence.", Status.Instance().NowTime);

                        this._subSequence.GlassInTime = Status.Instance().NowTime;
                        this._subSequence.GlassID = Machine.Instance().GetGlassID(this._subSequence.GlassInTime);
                        FormMain.Instance().Log(eLogType.SEQ, "Get Glass ID(glassIn) : " + this._subSequence.GlassID, Status.Instance().NowTime);
                        FormMain.Instance().Log(eLogType.INSPECTION, "Get Glass ID(glassIn) : " + this._subSequence.GlassID, Status.Instance().NowTime);

                        Machine.Instance().CameraManager.StartGrab();
                        FormMain.Instance().Log(eLogType.SEQ, "Grab Start.", Status.Instance().NowTime);

                        this._subSequence.Start(false);
                        FormMain.Instance().Log(eLogType.SEQ, "SubSequence Start.", Status.Instance().NowTime);

                        _seqStep = eSeqStep.SEQ_GLASS_OUT;

                        break;

                    case eSeqStep.SEQ_GLASS_OUT:

                        if (Settings.Instance().Operation.LineRateType == eLineRateType.VariableVel)
                        {
                            CheckRealVelocity();
                        }

                        if (Settings.Instance().Operation.UseGrabEdgeDetect)
                        {
                            if (Machine.Instance().CameraManager.IsGrabbing())
                                break;
                            Status.Instance().TestSensor = false;
                        }
                        else
                        {
                            if (!Machine.Instance().IsGlassOut())
                                break;
                        }

                        FormMain.Instance().Log(eLogType.SEQ, "Glass Out", Status.Instance().NowTime);

                        GrabDelay(Settings.Instance().Operation.EndGrabDelay);

                        Machine.Instance().CameraManager.StopGrab();   // Grab Stop
                        FormMain.Instance().Log(eLogType.SEQ, "Stop Grab", Status.Instance().NowTime, true);


                        this._subSequence.TactTimeStopWatch.Restart(); // Glass Out 후 검사 종류 까지 시간

                        Machine.Instance().LightOn(false); // Light Off
                        FormMain.Instance().Log(eLogType.SEQ, "Light Off.", Status.Instance().NowTime, true);

                        this._subSequence.GlassID = Machine.Instance().GetGlassID(this._subSequence.GlassInTime);
                        FormMain.Instance().Log(eLogType.SEQ, "Get Glass ID(glassOut) : " + this._subSequence.GlassID, Status.Instance().NowTime);
                        FormMain.Instance().Log(eLogType.INSPECTION, "Get Glass ID(glassOut) : " + this._subSequence.GlassID, Status.Instance().NowTime);

                        _seqStep = eSeqStep.SEQ_INIT;

                        break;

                    case eSeqStep.SEQ_ERROR:

                        Machine.Instance().LightOn(false);   // Light Off
                        FormMain.Instance().Log(eLogType.SEQ, "Error!, Stop Sequence, Light Off", Status.Instance().NowTime, true);

                        Machine.Instance().CameraManager.StopGrab(); // Camera Grab Stop
                        FormMain.Instance().Log(eLogType.SEQ, "Error!, Stop Sequence, Camera Grab Stop", Status.Instance().NowTime, true);

                        FormMain.Instance().Log(eLogType.SEQ, "Error!, Stop Sequence, Restart Sequence.", Status.Instance().NowTime, true);

                        _seqStep = eSeqStep.SEQ_START;
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
                _isLoadFiles = false;
            }
        }

        private void SetLineRate(double vel)
        {
            double lineRate = Machine.Instance().GetLineRate(vel);

            Machine.Instance().CameraManager.SetLineRate(lineRate);

            double applyLineRate = Machine.Instance().CameraManager.GetLineRate(0);

            string message = string.Format("Set LineRate. Vel : {0} mms Calc LineRate : {1} ApplyLineRate : {2}",
                                            vel.ToString(), lineRate.ToString(), applyLineRate.ToString());

            FormMain.Instance().Log(eLogType.SEQ, message, Status.Instance().NowTime, false);
        }

        public void GrabDelay(int ms)
        {
            if (Settings.Instance().Operation.UseTestMode == false)
            {
                if (Settings.Instance().Operation.InspectionTriggerType == eInspectionTriggerType.SENSOR)
                {
                    System.Threading.AutoResetEvent waitHandler = new System.Threading.AutoResetEvent(false);
                    waitHandler.WaitOne(ms);
                    FormMain.Instance().Log(eLogType.SEQ, "Grab Delay : " + ms.ToString(), Status.Instance().NowTime, false);
                }
            }
        }

        private int _prevVel = 0;
        private void CheckRealVelocity()
        {
            int nowVel = Convert.ToInt16(Status.Instance().Plc.GetPacketValue(ePLCAddress.PLC_REAL_VELOCITY));
            if((_prevVel - nowVel) > 0)
            {
                int newVel = Convert.ToInt16(Status.Instance().Plc.GetPacketValue(ePLCAddress.PLC_SLOW_VELOCITY));
                SetLineRate(newVel);
            }
            _prevVel = nowVel;
        }

        public void Terminate()
        {
            _isStop = true;
        }

        public void SetSeqStep(eSeqStep step)
        {
            _seqStep = step;
        }

        public void SetSeqLoadImage(string[] fileNames)
        {
            _loadFileNames = fileNames;
            _isLoadFiles = true;
        }
    }
}