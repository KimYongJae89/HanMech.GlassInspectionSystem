using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlassInspectionSystem.Class;
using System.Reflection;

namespace GlassInspectionSystem.Controls
{
    public partial class CtrlCommunicationStatus : UserControl
    {
        public CtrlCommunicationStatus()
        {
            InitializeComponent();
        }

        private delegate void UpdateStatusDele();

        public void UpdateStatus()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateStatusDele callback = UpdateStatus;
                    BeginInvoke(callback);
                    return;
                }
                lblCurrentTime.Text = string.Format("{0:yyy.MM.dd(ddd)   HH:mm:ss }", Status.Instance().NowTime);
                lblTrigger.Text = Status.Instance().IsGlassInCheck ? "ON" : "OFF";

                int connectedCamCount = Machine.Instance().CameraManager.GetConnectedCount();
                int camCount = Settings.Instance().Operation.CamCount;
                lblNumOfCam.Text = connectedCamCount.ToString() + " of " + camCount.ToString();

                if (connectedCamCount == camCount)
                    lblNumOfCam.BackColor = Color.White;
                else
                    lblNumOfCam.BackColor = Color.Red;

                bool isPlcConnected = Machine.Instance().PLCManager.IsConnected();
                if (isPlcConnected)
                {
                    lblPlcConnection.Text = "Connected";
                    lblPlcConnection.BackColor = Color.White;
                }
                else
                {
                    lblPlcConnection.Text = "Disconnected";
                    lblPlcConnection.BackColor = Color.Red;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }
    }
}