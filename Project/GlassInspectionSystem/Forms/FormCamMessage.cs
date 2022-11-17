using GlassInspectionSystem.Class;
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
    public partial class FormCamMessage : Form
    {
        public FormCamMessage()
        {
            InitializeComponent();
        }

        private void FormCamMessage_Load(object sender, EventArgs e)
        {
            txtCamCount.Text = "0";
        }

        private void txtCamCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int camCount = Convert.ToInt32(txtCamCount.Text);

            if(camCount == 0 || camCount > 8)
            {
                MessageBox.Show("CamCount is from 1 to 8.");
                return;
            }
            Status.Instance().Forms.OpenCamEdit(camCount, false);
            this.Close();
        }
    }
}
