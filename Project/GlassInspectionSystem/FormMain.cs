using enumType;
using GlassInspectionSystem.Class;
using GlassInspectionSystem.Controls;
using HMechLogLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace GlassInspectionSystem
{
    public partial class FormMain : Form
    {
        public CtrlDisplayList DisplayListControl = null;

        public CtrlDailyInformation DailyInformationControl = null;
        public CtrlGlassMap GlassMapControl = null;

        public CtrlCompany CompanyControl = null;
        public CtrlCommunicationStatus CommuStatusControl = null;
        public CtrlButton ButtonControl = null;

        public CtrlLogDisplay LogDisplayControl = null;
        public CtrlInspectionResult InspectionResultControl = null;
        public CtrlInspectionResultList InspectionResultListControl = null;
        public CtrlDefectInformation DefectInformationControl = null;
        public CtrlSystemInformation SystemInformationControl = null;

        private static FormMain _instance = null;
        private System.Threading.Timer _mainTimer = null;
        public static FormMain Instance()
        {
            if (_instance == null)
            {
                _instance = new FormMain();
            }

            return _instance;
        }

        public FormMain()
        {
            InitializeComponent();
        }
        
        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                AddControls();
                _mainTimer = new System.Threading.Timer(UpdateUI, null, 1000, 1000);
                Logger.Write(eLogType.SEQ, "Start Program", Status.Instance().NowTime);
                LogDisplayControl.AddLog("Start Program");
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void AddControls()
        {
            try
            {
                this.MinimumSize = this.MaximumSize;
                DisplayListControl = new CtrlDisplayList();
                DisplayListControl.Dock = DockStyle.Fill;
                this.pnlDisplayList.Controls.Add(DisplayListControl);
                DisplayListControl.MakeDisplay();

                CompanyControl = new CtrlCompany();
                CompanyControl.Dock = DockStyle.Fill;
                this.pnlCompanyLog.Controls.Add(CompanyControl);

                CommuStatusControl = new CtrlCommunicationStatus();
                CommuStatusControl.Dock = DockStyle.Fill;
                this.pnlCommunicationStatus.Controls.Add(CommuStatusControl);

                ButtonControl = new CtrlButton();
                ButtonControl.Dock = DockStyle.Fill;
                this.pnlButton.Controls.Add(ButtonControl);

                DailyInformationControl = new CtrlDailyInformation();
                DailyInformationControl.Dock = DockStyle.Fill;
                this.pnlInspectionStatus.Controls.Add(DailyInformationControl);

                GlassMapControl = new CtrlGlassMap();
                GlassMapControl.Dock = DockStyle.Fill;
                this.pnlGlassMap.Controls.Add(GlassMapControl);

                LogDisplayControl = new CtrlLogDisplay();
                LogDisplayControl.Dock = DockStyle.Fill;
                this.pnlLogDisplay.Controls.Add(LogDisplayControl);

                InspectionResultControl = new CtrlInspectionResult();
                InspectionResultControl.Dock = DockStyle.Fill;
                this.pnlInspectionResult.Controls.Add(InspectionResultControl);

                InspectionResultListControl = new CtrlInspectionResultList();
                InspectionResultListControl.Dock = DockStyle.Fill;
                this.pnlGlassInspectionResult.Controls.Add(InspectionResultListControl);

                SystemInformationControl = new CtrlSystemInformation();
                SystemInformationControl.Dock = DockStyle.Fill;
                this.pnlSystemInfo.Controls.Add(SystemInformationControl);

                DefectInformationControl = new CtrlDefectInformation();
                DefectInformationControl.Dock = DockStyle.Fill;
                DefectInformationControl.UpdateDefectDisplayDele = Status.Instance().Forms.UpdateDefectDisplay;
                this.pnlDefectInformation.Controls.Add(DefectInformationControl);
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void UpdateUI(object obj)
        {
            try
            {
                if (this.CommuStatusControl != null)
                {
                    CommuStatusControl.UpdateStatus();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Status.Instance().ProgramMode == eProgramMode.Inspection)
                {
                    MessageBox.Show("Can not exit in Inspection Mode. Change to Stop Mode.");
                    e.Cancel = true;
                    return;
                }

                if (MessageBox.Show("Exit?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
                Logger.Write(eLogType.SEQ, "Program Closing", Status.Instance().NowTime);
                _mainTimer.Dispose();
                if (this.SystemInformationControl != null)
                {
                    this.SystemInformationControl.KillTimer();
                }

                Inspection.Instance().MechAI.Dispose();
                Machine.Instance().PLCManager.Terminate();
                Machine.Instance().CameraManager.Terminate();
                Machine.Instance().Sequence.Terminate();

                System.Threading.Thread.Sleep(500);
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        public void Log(eLogType type, string message, DateTime dateTime, bool isUIUpdate = false)
        {
            Logger.Write(type, message, dateTime);
            if (this.LogDisplayControl != null)
                this.LogDisplayControl.AddLog(message);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);
            
            switch (key)
            {
                case Keys.D: 
                    if ((keyData & Keys.Control) != 0)
                    {
                        LoadImage();
                        return true;
                    }
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LoadImage()
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Status.Instance().ProgramMode = eProgramMode.Inspection;
                Machine.Instance().Sequence.StartSequence();
                Machine.Instance().Sequence.SetSeqLoadImage(dialog.FileNames);

            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            //Size tt = SizeFromClientSize(this.Size);
            //return;
            this.Size = new Size(this.Size.Width, this.Size.Height);
            //this.Size = new Size(tt.Width, tt.Height);
            //Console.WriteLine(tt.ToString());
            //this.Size = new Size(1952, 1135);

            if (DisplayListControl == null)
                return;

            DisplayListControl.ResizeDisplayList();
        }
    }
}
