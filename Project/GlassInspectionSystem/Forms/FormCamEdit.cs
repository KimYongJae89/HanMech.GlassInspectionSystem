using GlassInspectionSystem.Controls;
using Device.Camera;
using GlassInspectionSystem.Params;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlassInspectionSystem.Forms
{
    public partial class FormCamEdit : Form
    {
        public Action CloseEventDelegate;
        private List<CtrlCamEdit> _CamEditControlList = new List<CtrlCamEdit>();
        private int _camCount = 8;
        public bool _isExistConfig = false;
        public bool IsExistConfig
        {
            get { return _isExistConfig; }
            set { _isExistConfig = value; }
        }
        public FormCamEdit()
        {
            InitializeComponent();
        }

        private void FormCamEdit_Load(object sender, EventArgs e)
        {
            if (_isExistConfig == false)
            {
                Settings.Instance().Operation.CamProp.Clear();

                Settings.Instance().Operation.CamCount = _camCount;

                for (int i = 0; i < _camCount; i++)
                {
                    CameraProperty prop = new CameraProperty();
                    Settings.Instance().Operation.CamProp.Add(prop);
                }
            }

            tabMain.TabPages.Clear();
            for (int i = 0; i < _camCount; i++)
            {
                CtrlCamEdit ctrl = new CtrlCamEdit();
                ctrl.SetProperty(Settings.Instance().Operation.CamProp[i]);
                ctrl.Dock = DockStyle.Fill;
                string tabName = "Cam" + i.ToString();
                tabMain.TabPages.Add(tabName);
                tabMain.TabPages[i].Margin = new Padding(0);
                tabMain.TabPages[i].BackColor = SystemColors.Control;
                tabMain.TabPages[i].Controls.Add(ctrl);

                _CamEditControlList.Add(ctrl);
            }
        }
        
        public void SetCamCount(int camCount)
        {
            this._camCount = camCount;
        }

        private void FormCamEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Settings.Instance().Operation.CamProp.Count; i++)
            {
                Settings.Instance().Operation.CamProp[i].SetProperty(_CamEditControlList[i].GetProperty());
            }
            Settings.Instance().Save();
            this.DialogResult = DialogResult.OK;
        }

    }
}
