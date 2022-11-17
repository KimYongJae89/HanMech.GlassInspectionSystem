using GlassInspectionSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlassViewer.Forms
{
    public partial class FormGlassViewSettings : Form
    {
        public Action CloseEventDelegate;

        public FormGlassViewSettings()
        {
            InitializeComponent();
        }

        private void FormGlassViewSettings_Load(object sender, EventArgs e)
        {
            Settings.Instance().Load();

            txtImageFolderPath.Text = Settings.Instance().ImageFolder;
            txtDefectViewSize.Text = Settings.Instance().DefectViewSize;

            this.MaximizeBox = false;//최대화 버튼 막기
        }

        private void btnSettingPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtImageFolderPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            Settings.Instance().ImageFolder = txtImageFolderPath.Text;

            if (Convert.ToInt32(txtDefectViewSize.Text) <= 1000)
            {
                Settings.Instance().DefectViewSize = txtDefectViewSize.Text;
            }
            else
            {
                MessageBox.Show("Set to 1000x or less.");
                return;
            }

            Settings.Instance().Save();//경로 저장
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("Save Completed");

            this.Close();
        }

        private void FormGlassViewSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }

        private void txtDefectImageRatio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자와 BackSpace만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
