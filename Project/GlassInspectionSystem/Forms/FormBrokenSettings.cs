using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GlassInspectionSystem.Class;
using Insp;
using RuleAlgorithm.Broken;

namespace GlassInspectionSystem.Forms
{
    public partial class FormBrokenSettings : Form
    {
        private bool _isForkDetect = false;

        private BrokenParams _leftParam = null;
        private BrokenParams _rightParam = null;
        private BrokenParams _topParam = null;
        private BrokenParams _bottomParam = null;

        private string _selectedText = "Left";
        public Action CloseEventDelegate;

        public FormBrokenSettings()
        {
            InitializeComponent();
        }

        private void FormBrokenSettings_Load(object sender, EventArgs e)
        {
            if(_isForkDetect)
            {
                lblLeft.Enabled = false;
                lblRight.Enabled = false;
                lblTop.Enabled = false;
                lblBottom.Enabled = true;

                _selectedText = "Bottom";

                lblText.Text = "Use Edge Broken Settings(";
                for (int i = 0; i < Settings.Instance().Operation.CamProp.Count; i++)
                {
                    if (Settings.Instance().Operation.CamProp[i].IsExistFork)
                    {
                        if (i == Settings.Instance().Operation.CamProp.Count - 1)
                            lblText.Text += (i.ToString() + ")");
                        else
                            lblText.Text += (i.ToString() + " / ");
                    }
                }
            }
            else
            {
                lblLeft.Enabled = true;
                lblRight.Enabled = true;
                lblTop.Enabled = true;
                lblBottom.Enabled = true;

                _selectedText = "Left";

                lblText.Text = "Use Edge Broken Settings";
            }
         

            LoadParams();
        }

        public void SetParams(BrokenParameters brokenParams, bool isForkDetect)
        {
            _leftParam = brokenParams.LeftParams.Copy();
            _rightParam = brokenParams.RightParams.Copy();
            _topParam = brokenParams.TopParams.Copy();
            _bottomParam = brokenParams.BottomParams.Copy();

            _isForkDetect = isForkDetect;
        }

        private void LoadParams()
        {
            BrokenParams param = GetEdgeParams();

            UpdateButtom();

            txtBrokenValue.Text = param.BrokenVal.ToString();
            txtOutSidePixelFromEdge.Text = param.OutSidePixelFromEdge.ToString();
            txtInSidePixelFromEdge.Text = param.InSidePixelFromEdge.ToString();
            txtAvgCnt.Text = param.AvgCnt.ToString();
            txtTwoDerivativeValue.Text = param.TwoDerivativeValue.ToString();
            txtThreshold1.Text = param.Threshold1.ToString();
            txtThreshold2.Text = param.Threshold2.ToString();
        }

        private BrokenParams GetEdgeParams()
        {
            BrokenParams param = null;
            switch (_selectedText)
            {
                case "Left":
                    param = _leftParam;
                    break;
                case "Right":
                    param = _rightParam;
                    break;
                case "Top":
                    param = _topParam;
                    break;
                case "Bottom":
                    param = _bottomParam;
                    break;
                default:
                    break;
            }
            return param;
        }

        private void UpdateButtom()
        {
            lblLeft.BorderStyle = BorderStyle.FixedSingle;
            lblRight.BorderStyle = BorderStyle.FixedSingle;
            lblTop.BorderStyle = BorderStyle.FixedSingle;
            lblBottom.BorderStyle = BorderStyle.FixedSingle;

            switch (_selectedText)
            {
                case "Left":
                    lblLeft.BorderStyle = BorderStyle.Fixed3D;
                    break;
                case "Right":
                    lblRight.BorderStyle = BorderStyle.Fixed3D;
                    break;
                case "Top":
                    lblTop.BorderStyle = BorderStyle.Fixed3D;
                    break;
                case "Bottom":
                    lblBottom.BorderStyle = BorderStyle.Fixed3D;
                    break;
                default:
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int avg = Convert.ToInt32(txtAvgCnt.Text);
            if (avg % 2 != 0)
            {
                MessageBox.Show("Enter Only 2 of multiple.");
                return;
            }

            SetParams(_selectedText);
            CopyParams();
            Settings.Instance().AlgorithmSettings.Save();
            MessageBox.Show("Save Compeleted");
        }

        private void FormBrokenSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }

        private void lblBroken_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Label label = sender as System.Windows.Forms.Label;

            int avg = Convert.ToInt32(txtAvgCnt.Text);
            if (avg % 2 != 0)
            {
                MessageBox.Show("Enter Only 2 of multiple.");
                txtAvgCnt.Focus();
                return;
            }

            if (label != null)
            {
                SetParams(_selectedText);

                _selectedText = label.Text;

                UpdateButtom();
                LoadParams();
            }
        }

        private void SetParams(string text)
        {
            BrokenParams broken = new BrokenParams();
            broken.OutSidePixelFromEdge = Convert.ToInt32(txtOutSidePixelFromEdge.Text);
            broken.InSidePixelFromEdge = Convert.ToInt32(txtInSidePixelFromEdge.Text);
            broken.BrokenVal = Convert.ToSingle(txtBrokenValue.Text);
            broken.AvgCnt = Convert.ToInt32(txtAvgCnt.Text);
            broken.TwoDerivativeValue = Convert.ToInt32(txtTwoDerivativeValue.Text);
            broken.Threshold1 = Convert.ToSingle(txtThreshold1.Text);
            broken.Threshold2 = Convert.ToSingle(txtThreshold2.Text);

            switch (text)
            {
                case "Left":
                    broken.Type = RuleAlgorithm.Utility.eEdgeType.Left;
                    _leftParam = broken.Copy();
                    break;

                case "Right":
                    broken.Type = RuleAlgorithm.Utility.eEdgeType.Right;
                    _rightParam = broken.Copy();
                    break;

                case "Top":
                    broken.Type = RuleAlgorithm.Utility.eEdgeType.Top;
                    _topParam = broken.Copy();
                    break;

                case "Bottom":
                    broken.Type = RuleAlgorithm.Utility.eEdgeType.Bottom;
                    _bottomParam = broken.Copy();
                    break;

                default:
                    break;
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            //if(!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            //{
            //    e.Handled = true;
            //}
        }

        private void CopyParams()
        {
            BrokenParameters param = new BrokenParameters();
            param.LeftParams = _leftParam.Copy();
            param.RightParams = _rightParam.Copy();
            param.TopParams = _topParam.Copy();
            param.BottomParams = _bottomParam.Copy();

            if (_isForkDetect)
            {
                Settings.Instance().AlgorithmSettings.Fork.BrokenParams = param.Copy();
            }
            else
            {
                Settings.Instance().AlgorithmSettings.Edge.BrokenParams = param.Copy();
            }
        }

        private void txtAvgCnt_Leave(object sender, EventArgs e)
        {
            int avg = Convert.ToInt32(txtAvgCnt.Text);
            if (avg % 2 != 0)
            {
                MessageBox.Show("Enter Only 2 of multiple.");
                txtAvgCnt.Focus();
                return;
            }
        }
    }
}
