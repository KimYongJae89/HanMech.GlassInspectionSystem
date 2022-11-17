using Device.Edge;
using Insp;
using RuleAlgorithm.Contour;
using RuleAlgorithm.Utility;
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
    public partial class FormContourSettings : Form
    {
        private bool _isForkDetect = false;

        private ContourParams _leftParam = null;
        private ContourParams _rightParam = null;
        private ContourParams _topParam = null;
        private ContourParams _bottomParam = null;


        private string _selectedText = "Left";
        public Action CloseEventDelegate;

        public FormContourSettings()
        {
            InitializeComponent();
        }

        private void FormContourSettings_Load(object sender, EventArgs e)
        {
            if(_isForkDetect)
            {
                lblLeft.Enabled = false;
                lblRight.Enabled = false;
                lblTop.Enabled = false;
                lblBottom.Enabled = true;

                _selectedText = "Bottom";

                lblText.Text = "Use Fork Contour Settings(";
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

                lblText.Text = "Use Edge Contour Settings";
            }
           

            LoadParams();
        }

        public void SetParams(ContourParameters contourParams, bool isForkDetect)
        {
            _leftParam = contourParams.LeftParams.Copy();
            _rightParam = contourParams.RightParams.Copy();
            _topParam = contourParams.TopParams.Copy();
            _bottomParam = contourParams.BottomParams.Copy();

            _isForkDetect = isForkDetect;
        }

        private void LoadParams()
        {
            ContourParams param = GetContourParams();

            UpdateButtom();

            txtOffset.Text = param.Offset.ToString();
            txtInspectionArea.Text = param.InspectionArea.ToString();
            txtMinSize.Text = param.MinSize.ToString();
            txtTwoDerivativeValue.Text = param.TwoDerivativeValue.ToString();
        }

        private ContourParams GetContourParams()
        {
            ContourParams param = null;
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

        private void FormContourSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }

        private void lblBroken_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Label label = sender as System.Windows.Forms.Label;

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
            ContourParams contour = new ContourParams();

            contour.Offset = Convert.ToInt32(txtOffset.Text);
            contour.InspectionArea = Convert.ToInt32(txtInspectionArea.Text);
            contour.MinSize = Convert.ToInt32(txtMinSize.Text);
            contour.TwoDerivativeValue = Convert.ToInt32(txtTwoDerivativeValue.Text);
            switch (text)
            {
                case "Left":
                    contour.Type = eEdgeType.Left;
                    _leftParam = contour.Copy();
                    break;

                case "Right":
                    contour.Type = eEdgeType.Right;
                    _rightParam = contour.Copy();
                    break;

                case "Top":
                    contour.Type = eEdgeType.Top;
                    _topParam = contour.Copy();
                    break;

                case "Bottom":
                    contour.Type = eEdgeType.Bottom;
                    _bottomParam = contour.Copy();
                    break;

                default:
                    break;
            }
        }

        private void CopyParams()
        {
            ContourParameters param = new ContourParameters();
            param.LeftParams = _leftParam.Copy();
            param.RightParams = _rightParam.Copy();
            param.TopParams = _topParam.Copy();
            param.BottomParams = _bottomParam.Copy();

            if (_isForkDetect)
            {
                Settings.Instance().AlgorithmSettings.Fork.ContourParams = param.Copy();
            }
            else
            {
                Settings.Instance().AlgorithmSettings.Edge.ContourParams = param.Copy();
            }
        }

        private void txtInspectionArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetParams(_selectedText);
            CopyParams();
            Settings.Instance().AlgorithmSettings.Save();
            MessageBox.Show("Save Compeleted");
        }
    }
}
