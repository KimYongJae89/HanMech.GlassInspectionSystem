using Device.Camera;
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
    public partial class FormForkDetect : Form
    {
        private bool _isLoading = false;

        private List<CameraProperty> _camProp = null;
        private int _prevSelectCamNo = 0;

        public Action CloseEventDelegate;

        public FormForkDetect()
        {
            InitializeComponent();
        }

        private void FormForkDetect_Load(object sender, EventArgs e)
        {
            _isLoading = true;

            if (_camProp == null)
                return;
            if (_camProp.Count == 0)
                return;

            for (int i = 0; i < Settings.Instance().Operation.CamCount; i++)
            {
                cbxCamNo.Items.Add(i.ToString());
                cbxCamNo.SelectedIndex = 0;
            }

            _isLoading = false;

            
            ckbForkExist.Checked = _camProp[0].IsExistFork;
            txtIgnoreLeftXOffset.Text = _camProp[0].IgnoreLeftXFromFork.ToString();
            txtIgnoreRightXOffset.Text = _camProp[0].IgnoreRightXFromFork.ToString();
            txtThreshold1.Text = _camProp[0].Threshold1.ToString();
            txtThreshold2.Text = _camProp[0].Threshold2.ToString();
        }

        public void SetParam(List<CameraProperty> camPropList)
        {
            _camProp = camPropList.Select(item => item.Copy() as CameraProperty).ToList();
        }
        private void cbxCamNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            UpdateData(_prevSelectCamNo);
            UpdateUI(cbxCamNo.SelectedIndex);

            _prevSelectCamNo = cbxCamNo.SelectedIndex;
        }

        private void UpdateUI(int camNo)
        {
            ckbForkExist.Checked = _camProp[camNo].IsExistFork;
            txtIgnoreLeftXOffset.Text = _camProp[camNo].IgnoreLeftXFromFork.ToString();
            txtIgnoreRightXOffset.Text = _camProp[camNo].IgnoreRightXFromFork.ToString();
            txtThreshold1.Text = _camProp[camNo].Threshold1.ToString();
            txtThreshold2.Text = _camProp[camNo].Threshold2.ToString();
        }

        private void UpdateData(int camNo)
        {
            _camProp[camNo].IsExistFork = ckbForkExist.Checked;
            _camProp[camNo].IgnoreLeftXFromFork = Convert.ToInt32(txtIgnoreLeftXOffset.Text);
            _camProp[camNo].IgnoreRightXFromFork = Convert.ToInt32(txtIgnoreRightXOffset.Text);
            _camProp[camNo].Threshold1 = Convert.ToInt32(txtThreshold1.Text);
            _camProp[camNo].Threshold2 = Convert.ToInt32(txtThreshold2.Text);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            UpdateData(cbxCamNo.SelectedIndex);
            Settings.Instance().Operation.CamProp = _camProp.Select(item => item.Copy() as CameraProperty).ToList();
            MessageBox.Show("Apply Completed");
        }

        private void FormForkDetect_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }
    }
}
