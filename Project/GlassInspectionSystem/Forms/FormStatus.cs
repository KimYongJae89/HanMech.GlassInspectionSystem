using Device.Camera;
using Device.PLC;
using GlassInspectionSystem.Class;
using HMechLogLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GlassInspectionSystem.Forms
{
    public partial class FormStatus : Form
    {
        public Action CloseEventDelegate;
        private System.Threading.Timer _timer = null;
        public FormStatus()
        {
            InitializeComponent();
        }

       
        private void FormStatus_Load(object sender, EventArgs e)
        {
            foreach (eResultConstant resultType in Enum.GetValues(typeof(eResultConstant)))
                cbxPCJudge.Items.Add(resultType.ToString());
            cbxPCJudge.SelectedIndex = 0;

            _timer = new System.Threading.Timer(UpdateUI, null, 1000, 500);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private delegate void UpdateUIDele(object obj);
        private void UpdateUI(object obj)
        {
            if (this.InvokeRequired)
            {
                UpdateUIDele callback = UpdateUI;
                BeginInvoke(callback, obj);
                return;
            }
            CamStatus();
            PLCStatus();
        }

        private void CamStatus()
        {
            // Camera Status
            try
            {
                gvCamInfoList.Rows.Clear();
                if (Machine.Instance().CameraManager.GetObject() != null)
                {
                    for (int i = 0; i < Settings.Instance().Operation.CamCount; i++)
                    {
                        string _camStatus = "FAIL";
                        if (Machine.Instance().CameraManager.IsOpen(i))
                            _camStatus = "OK";
                        else
                            _camStatus = "FAIL";

                        gvCamInfoList.Rows.Add(new object[] {i, Settings.Instance().Operation.CamProp[i].SerialNumber, Settings.Instance().Operation.CamProp[i].CamAddress, _camStatus});

                        if (Machine.Instance().CameraManager.IsOpen(i))
                            gvCamInfoList.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        else
                            gvCamInfoList.Rows[i].Cells[3].Style.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(eLogType.ERROR, ex);
                Logger.Write(eLogType.ERROR, "Camera is Disconnected!", DateTime.Now);
                MessageBox.Show("Camera is Disconnected!");
            }
        }
        private void PLCStatus()
        {
            // PLC Status
            try
            {
                if (Machine.Instance().PLCManager != null)
                {
                    if (Machine.Instance().PLCManager.IsConnected())
                    {
                        //Read
                        txtReadPlcHeartBit.Text = Status.Instance().Plc.GetPacketValue(ePLCAddress.PLC_HEARTBEAT);
                        txtReadPlcDateTime.Text = Status.Instance().Plc.GetPacketValue(ePLCAddress.PLC_DATETIME);
                        txtReadPlcCVDirection.Text = Status.Instance().Plc.GetPacketValue(ePLCAddress.PLC_CV_DIRECTION);
                        txtReadPlcRealVelocity.Text = Status.Instance().Plc.GetPacketValue(ePLCAddress.PLC_REAL_VELOCITY);
                        txtReadPlcTargetVelocity.Text = Status.Instance().Plc.GetPacketValue(ePLCAddress.PLC_TARGET_VELOCITY);
                        txtReadPlcSlowVelocity.Text = Status.Instance().Plc.GetPacketValue(ePLCAddress.PLC_SLOW_VELOCITY);
                        txtReadPlcGlassInput.Text = Status.Instance().Plc.GetPacketValue(ePLCAddress.PLC_GLASS_INPUT);
                        txtReadPlcGlassID.Text = Status.Instance().Plc.GetPacketValue(ePLCAddress.PLC_GLASS_ID);
                        txtReadPlcGlassType.Text = Status.Instance().Plc.GetPacketValue(ePLCAddress.PLC_GLASS_TYPE);
                        txtReadPcHeartBit.Text = Status.Instance().Plc.GetPacketValue(ePLCAddress.PC_HEARTBEAT);
                        txtReadPcJudge.Text = Status.Instance().Plc.GetPacketValue(ePLCAddress.PC_JUDGE);
                        txtReadPCDefectType.Text = Status.Instance().Plc.GetPacketValue(ePLCAddress.PC_DEFECT_TYPE);
                        txtReadPcInspComplete.Text = Status.Instance().Plc.GetPacketValue(ePLCAddress.PC_INSPECTION_COMPLETE);

                        //Write
                        txtWritePcHeartBeat.Text = Machine.Instance().PLCManager.PCHeartBeat ? "1" : "0";

                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private Color GetColorFromString(string value)
        {
            value = value.Trim();
            if (value == "")
                return Color.Red;
            else
                return Color.LightGreen;
        }

        private Color GetColorFromInteger(int value)
        {
            if (value == 0)
                return Color.Red;
            else
                return Color.LightGreen;
        }

        private Color GetColorFromBoolean(bool value)
        {
            if (value == false)
                return Color.Red;
            else
                return Color.LightGreen;
        }

        private void FormStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }

        private void btnPCInspectionComplete_Click(object sender, EventArgs e)
        {
            Machine.Instance().PLCManager.InspetionComplete();
        }

        private void btnPCJudge_Click(object sender, EventArgs e)
        {
            eResultConstant resultType = (eResultConstant)Enum.Parse(typeof(eResultConstant), cbxPCJudge.SelectedItem as string);
            switch (resultType)
            {
                case eResultConstant.NONE:
                    break;
                case eResultConstant.OK:
                    Machine.Instance().PLCManager.WriteCommandJudge(eResultConstant.OK);
                    break;
                case eResultConstant.NG:
                    Machine.Instance().PLCManager.WriteCommandJudge(eResultConstant.NG);
                    break;
                case eResultConstant.WARNING:
                    Machine.Instance().PLCManager.WriteCommandJudge(eResultConstant.WARNING);
                    break;
                default:
                    break;
            }
        }

        private void btnPCBroken_Click(object sender, EventArgs e)
        {
            Machine.Instance().PLCManager.WriteCommandDefectType(enumType.eDefectType.Broken);
        }

        private void btnPCChipping_Click(object sender, EventArgs e)
        {
            Machine.Instance().PLCManager.WriteCommandDefectType(enumType.eDefectType.Chipping);
        }

        private void btnPCCrack_Click(object sender, EventArgs e)
        {
            Machine.Instance().PLCManager.WriteCommandDefectType(enumType.eDefectType.Crack);
        }

        private void btnPCResultClear_Click(object sender, EventArgs e)
        {
            Machine.Instance().PLCManager.ClearResultData();
        }

        private void FormStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
        }
    }
}
