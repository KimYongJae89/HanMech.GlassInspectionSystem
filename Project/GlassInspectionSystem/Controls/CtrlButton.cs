using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlassInspectionSystem.Forms;
using GlassInspectionSystem.Class;
using enumType;
using HMechLogLib;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace GlassInspectionSystem.Controls
{
    public partial class CtrlButton : UserControl
    {
        public CtrlButton()
        {
            InitializeComponent();
        }

        private void CtrlButton_Load(object sender, EventArgs e)
        {
            try
            {
                EnableButton(Status.Instance().ProgramMode);
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            try
            {
                Status.Instance().Forms.OpenSettings();
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void ctnStatus_Click(object sender, EventArgs e)
        {
            try
            {
                Status.Instance().Forms.OpenStatus();
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void btnInspection_Click(object sender, EventArgs e)
        {
            try
            {
                FormMain.Instance().LogDisplayControl.AddLog("Click Inspection Button.");
                Logger.Write(eLogType.SEQ, "Click Inspection Button.", Status.Instance().NowTime);
                Status.Instance().ProgramMode = eProgramMode.Inspection;
                Machine.Instance().Sequence.StartSequence();
                EnableButton(Status.Instance().ProgramMode);
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                FormMain.Instance().LogDisplayControl.AddLog("Click Stop Buttom.");
                Logger.Write(eLogType.SEQ, "Click Stop Buttom.", Status.Instance().NowTime);

                Status.Instance().ProgramMode = eProgramMode.Stop;
                Machine.Instance().Sequence.SeqStep = eSeqStep.SEQ_STOP;
                EnableButton(Status.Instance().ProgramMode);
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void EnableButton(eProgramMode type)
        {
            try
            {
                switch (type)
                {
                    case eProgramMode.Inspection:
                        btnInspection.Enabled = false;
                        btnStop.Enabled = true;
                        break;
                    case eProgramMode.Stop:
                        btnInspection.Enabled = true;
                        btnStop.Enabled = false;
                        break;
                    case eProgramMode.Test:
                        btnInspection.Enabled = true;
                        btnStop.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            string runTimePath = Directory.GetCurrentDirectory();
            Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "GlassViewer.exe"));
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
