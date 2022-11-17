
using GlassInspectionSystem.Class;
using Device.Camera;
using Device.DIO;
using Device.Light;
using Device.PLC;
using HMechLogLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enumType;
using AI;
using System.IO;
using HMechUtility;
using System.Threading;

namespace GlassInspectionSystem
{
    public class Machine
    {
        public CameraManager CameraManager = new CameraManager();
        public LightManager LightManager = new LightManager();
        public DIO Dio = null;
        public PLCManager PLCManager = new PLCManager();
        public Sequence Sequence = new Sequence();

        public Thread DeleteThread = null;

        private static Machine _instance;
        public static Machine Instance()
        {
            if (_instance == null)
                _instance = new Machine();

            return _instance;
        }

        public void Initialize()
        {
            if (Settings.Instance().Operation.CameraType != eCameraType.None)
            {
                Machine.Instance().CameraManager.CreateObject(Settings.Instance().Operation.CameraType);
                Machine.Instance().CameraManager.Initialize(Settings.Instance().Operation.CamProp, Settings.Instance().Operation.CamCount);
            }

            if (Settings.Instance().Operation.InspectionTriggerType == eInspectionTriggerType.SENSOR)
            {
                Machine.Instance().Dio = new DIO();
                Machine.Instance().Dio.LoadDevice(Settings.Instance().Operation.DioBoardType, Settings.Instance().Operation.DioCardNo);
            }

            if (Settings.Instance().Operation.PlcType != ePLCType.None)
            {
                Machine.Instance().PLCManager.Initialize();
            }

            if (Settings.Instance().Operation.LightType == eLightType.Serial)
            {
                Machine.Instance().LightManager.CreateObject(Settings.Instance().Operation.SerialLightType);
                Machine.Instance().LightManager.Init(Settings.Instance().Operation.ComPort, Settings.Instance().Operation.BaudRate);

            }

            Machine.Instance().Sequence.StartSequence();
        }

        public void LightOn(bool isOn)
        {
            eLightType type = Settings.Instance().Operation.LightType;
            if (type == eLightType.IO)
                Machine.Instance().Dio.SetOutBit(DIO.OUT_Light_OnOff, isOn);
            else
                Machine.Instance().LightManager.LightOn(isOn);
        }

        public void SetLightValue(int value)
        {
            eSerialLightType serialLightType = Settings.Instance().Operation.SerialLightType;

            if(serialLightType == eSerialLightType.CCS_RS485)
            {
                Machine.Instance().LightManager.SetLightValue(value);
            }
        }
        // PLC Check
        private bool IsAlivePLC()
        {
            if (Machine.Instance().PLCManager != null && Machine.Instance().PLCManager.IsConnected())
                return true;
            else
                return false;
        }

        public bool IsPLCResultCompleted()
        {
            string value = Status.Instance().Plc.GetPacketValue(ePLCAddress.PC_INSPECTION_COMPLETE);

            bool isResultCompleted = Convert.ToBoolean(Convert.ToInt32(value));

            if (isResultCompleted)
                return true;
            else
                return false;
        }

        public void ClearPLCResult()
        {
            if (Settings.Instance().Operation.PlcType == ePLCType.None)
                return;
            if (IsAlivePLC())
            {
                Machine.Instance().PLCManager.ClearResultData();
            }
            else
            {
                Logger.Write(eLogType.ERROR, "PLC is Disconnected", DateTime.Now);
            }
        }

        public void SendResultToPLC(eResultConstant result)
        {
            if (Settings.Instance().Operation.PlcType == ePLCType.None)
            {
                Logger.Write(eLogType.SEQ, "PLC Type is None.", Status.Instance().NowTime);
                return;
            }
            if (IsAlivePLC())
            {
                Machine.Instance().PLCManager.WriteCommandJudge(result);
            }
            else
            {
                Logger.Write(eLogType.ERROR, "PLC is Disconnected", Status.Instance().NowTime);
            }
        }

        public bool CheckPLCResult()
        {
            if (IsAlivePLC())
            {
                if (IsPLCResultCompleted())
                {
                    Logger.Write(eLogType.SEQ, "Complete Sending Inspection Result", Status.Instance().NowTime);
                    return true;
                }
                else
                {
                    Logger.Write(eLogType.ERROR, "Failed, PLC Not Received Inspection Result", Status.Instance().NowTime);
                    return false;
                }
            }
            else
            {
                if (Settings.Instance().Operation.PlcType == ePLCType.None)
                {
                    Logger.Write(eLogType.SEQ, "PLC Type is None.", Status.Instance().NowTime);
                    return true;
                }
                Logger.Write(eLogType.ERROR, "PLC is Disconnected", Status.Instance().NowTime);
                return false;
            }
        }

        // Trigger
        public bool IsGlassIn()
        {
            if (Settings.Instance().Operation.UseTestMode)
            {
                // 기존 Thread Sleep 줘서 롱런 테스트 했던 코드
                //Thread.Sleep(_glassInSleepTime);
                //_isGlassInCheck = true;
                //return true;

                if (Status.Instance().TestSensor)
                {
                    Status.Instance().IsGlassInCheck = true;
                    return true;
                }
                else
                {
                    Status.Instance().IsGlassInCheck = false;
                    return false;
                }
            }
            else
            {
                if (Settings.Instance().Operation.InspectionTriggerType == eInspectionTriggerType.SENSOR)
                {
                    if (Machine.Instance().Dio.IsIOBit(DIO.IN_Glass_InOut) == false)
                    {
                        Status.Instance().IsGlassInCheck = false;
                        return false;
                    }
                }
                // Use PLC Trigger : PLC Clear / Wait PLC Signal
                else if (Settings.Instance().Operation.InspectionTriggerType == eInspectionTriggerType.PLC)
                {
                    if (Status.Instance().Plc.GlassIn() == false)
                    {
                        Status.Instance().IsGlassInCheck = false;
                        return false;
                    }
                }
                else
                {
                    // Logger.Write(eLogType.ERROR, "Not Selected Trigger", DateTime.Now);
                    Status.Instance().IsGlassInCheck = false;
                    return false;
                }
            }
            Status.Instance().IsGlassInCheck = true;

            if (IsAlivePLC())
                ClearPLCResult();

            return true;
        }

        public bool IsGlassOut()
        {
            if (Settings.Instance().Operation.UseTestMode)
            {
                // 기존 Thread Sleep 줘서 롱런 테스트 했던 코드
                //Thread.Sleep(_glassOutSleepTime);
                //_isGlassInCheck = false;
                //return true;
                if (Status.Instance().TestSensor)
                {
                    Status.Instance().IsGlassInCheck = true;
                    return false;
                }
                else
                {
                    Status.Instance().IsGlassInCheck = false;
                    return true;
                }
            }
            else
            {
                if (Settings.Instance().Operation.InspectionTriggerType == eInspectionTriggerType.SENSOR)
                {
                    if (Machine.Instance().Dio.IsIOBit(DIO.IN_Glass_InOut) == true)
                    {
                        Status.Instance().IsGlassInCheck = true;
                        return false;
                    }
                }
                // Use PLC Trigger : PLC Clear / Wait PLC Signal
                else if (Settings.Instance().Operation.InspectionTriggerType == eInspectionTriggerType.PLC)
                {
                    if (IsAlivePLC())
                    {
                        //if (Machine.Instance().PLCManager.GetGlassInput() == true)
                        if(Status.Instance().Plc.GlassIn() == true)
                        {
                            Status.Instance().IsGlassInCheck = true;
                            return false;
                        }
                    }
                    else
                    {
                        Logger.Write(eLogType.ERROR, "PLC is Disconnected", Status.Instance().NowTime);
                        Status.Instance().IsGlassInCheck = true;
                        return false;
                    }
                }
                else
                {
                    Logger.Write(eLogType.ERROR, "Not Selected Trigger", DateTime.Now);
                    Status.Instance().IsGlassInCheck = true;
                    return false;
                }
                Status.Instance().IsGlassInCheck = false;
                return true;
            }
        }

        public double GetLineRate(double vel)
        {
            double fov = Settings.Instance().Operation.Fov;
            int width = 0;

            if (Settings.Instance().Operation.CamProp.Count == 0)
                width = 4096;
            else
                width = Settings.Instance().Operation.CamProp[0].Width;


            double lineRate = vel / (fov / (double)width);

            if (lineRate < 100)
                lineRate = 100;

            return lineRate;
        }

        public string GetGlassID(DateTime glassInTime)
        {
            string dateTime = glassInTime.ToString("yyyyMMdd_HHmmss");
            string glassID = "Test_" + dateTime;

            try
            {
                if (Settings.Instance().Operation.UseTestMode)
                    return glassID;

                if (IsAlivePLC() && Settings.Instance().Operation.PlcType != ePLCType.None)
                {

                    PLCAddressProperty property = Status.Instance().Plc.GetPLCPacketProperty(ePLCAddress.PLC_GLASS_ID);
                    if(property.UseAddress)
                    {
                        glassID = property.Value.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(eLogType.ERROR, ex);
            }
            return glassID;
        }

        public void StartDeleteData(string glassID)
        {
            if(DeleteThread == null)
            {
                Thread th = new Thread(DeleteData);
                th.Start();
            }
        }

        public eCVDirection GetCVDirection()
        {
            if (IsAlivePLC() && Settings.Instance().Operation.PlcType != ePLCType.None)
            {
                PLCAddressProperty property = Status.Instance().Plc.GetPLCPacketProperty(ePLCAddress.PLC_CV_DIRECTION);

                if (property.UseAddress)
                {
                    return (eCVDirection)Enum.Parse(typeof(eCVDirection), property.Value);
                }
            }
            return eCVDirection.CW;
        }

        private void DeleteData()
        {
            try
            {
                string imagePath = Settings.Instance().Operation.ImageFolderPath;
                string logPath = Path.Combine(Directory.GetCurrentDirectory(), "log");

                Utility.DeleteFilesInDirectory(imagePath, ".*", Settings.Instance().Operation.ImageSavePeriod);
                Utility.DeleteFilesInDirectory(logPath, ".*", Settings.Instance().Operation.LogSavePeriod);

                FormMain.Instance().Log(eLogType.SEQ, "Delete Data Done.", Status.Instance().NowTime);

                DeleteThread = null;
            }
            catch (Exception err)
            {
                Logger.WriteException(eLogType.ERROR, err);
                DeleteThread = null;
            }
        }

        public void Terminate()
        {
            LightManager.Terminate();
            Dio.Terminate();
            if(PLCManager != null)
                PLCManager.Terminate();
            Sequence.Terminate();
        }
    }
}
