using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Device.Edge;
using Insp;

namespace GlassInspectionSystem.Forms
{
    public partial class FormEdgeDetect : Form
    {
        public Action CloseEventDelegate;
        public FormEdgeDetect()
        {
            InitializeComponent();
        }

        private void FormEdgeDetect_Load(object sender, EventArgs e)
        {
            LoadParams();
        }

        private void LoadParams()
        {
            txtIgnoreLeftXOffset.Text = EdgeDetect.IgnoreLeftXOffsetForEdgeDetect.ToString();
            txtIgnoreRightXOffset.Text = EdgeDetect.IgnoreRightXOffsetForEdgeDetect.ToString();
            txtDistanceFromEdge.Text = EdgeDetect.DistanceFromEdge.ToString();
            txtIgnoreRealHeight.Text = EdgeDetect.IgnoreRealHeightForEdgeDetect.ToString();
            txtJudgeValue.Text = EdgeDetect.EdgeJudgeValue.ToString();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            EdgeDetect.IgnoreLeftXOffsetForEdgeDetect = Convert.ToInt32(txtIgnoreLeftXOffset.Text);
            EdgeDetect.IgnoreRightXOffsetForEdgeDetect = Convert.ToInt32(txtIgnoreRightXOffset.Text);
            EdgeDetect.DistanceFromEdge = Convert.ToInt32(txtDistanceFromEdge.Text);
            EdgeDetect.IgnoreRealHeightForEdgeDetect = Convert.ToInt32(txtIgnoreRealHeight.Text);
            EdgeDetect.EdgeJudgeValue = Convert.ToDouble(txtJudgeValue.Text);

            MessageBox.Show("Apply Completed");
        }

        private void FormEdgeDetect_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }
    }
}
