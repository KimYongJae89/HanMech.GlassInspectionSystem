using GlassInspectionSystem.Controls;
using OpenCvSharp;
using RuleAlgorithm;
using RuleAlgorithm.Broken;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using enumType;
using RuleAlgorithm.Utility;
using System.IO;
using Insp;
using RuleAlgorithm.Contour;
using HMechUtility;
using GlassInspectionSystem.Class;
using Device.Camera;
using System.Threading;
using Device.Edge;
using OpenCvSharp.Extensions;

namespace GlassInspectionSystem.Forms
{
    public enum eInspType
    {
        None,
        Broken,
        Contour,
        //Processing
        Canny,
    }

    public partial class FormRuleProcessImage : Form
    {
        public Action CloseEventDelegate;
        public CtrlRuleImageDisplay RuleImageDisplayControl;

        private delegate void EnableExcuteButtonDele(bool isEnable);
        private delegate void AddDefectLogDele(ListBox lbx, string text);

        private eInspType _inspType = eInspType.Broken;
        private eEdgeType _inspDirectionType = eEdgeType.None;

        private Thread _inspThread = null;
        private Bitmap _originalBmp = null;
        private Bitmap _binarizationBmp = null;
        private List<Rectangle> _finallyDefectList = new List<Rectangle>();
        private List<ContourData> _contourDataList = new List<ContourData>();
        private Rectangle _contourInspectionArea = new Rectangle();
        private Rectangle _selectedDefectRect = new Rectangle();

        private int _offset = 0;
        private int _elementIndex = 0;
        private bool _isDrawInspArea = false;
        private bool _isOriginalImage = true;
        private bool _isSelectBrokenDefect = false;
        private bool _isSelectContourDefect = false;

        public FormRuleProcessImage()
        {
            InitializeComponent();
        }

        private void FormRuleProcessImage_Load(object sender, EventArgs e)
        {
            RuleImageDisplayControl = new CtrlRuleImageDisplay();
            pnlDisplayImage.Controls.Add(RuleImageDisplayControl);
            RuleImageDisplayControl.Dock = DockStyle.Fill;

            InitInspValues();
        }

        private void FormRuleProcessImage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }

        private void InitInspValues()
        {
            // Direction
            txtOffset.Text = "0";

            foreach (eEdgeType type in Enum.GetValues(typeof(eEdgeType)))
            {
                if (type == eEdgeType.None)
                    continue;

                cbxDirection.Items.Add(type.ToString());
            }

            cbxDirection.SelectedIndex = 0;

            foreach (eDirection type in Enum.GetValues(typeof(eDirection)))
            {
                if (type == eDirection.None)
                    continue;

                cbxProcessingFilterType.Items.Add(type.ToString());
            }

            cbxProcessingFilterType.SelectedIndex = 0;

            // Broken Params
            txtBrokenValue.Text = "1.5";
            txtBrokenAvgCnt.Text = "4";
            txtBrokenTwoDerivativeValue.Text = "7";
            txtBrokenThres1.Text = "30.0";
            txtBrokenThres2.Text = "200.0";
            // Contour Params
            txtContourMinSize.Text = "10.0"; // 노이즈의 최소 크기
            txtContourInspectionArea.Text = "50"; // 검출영역
            txtContourInspectionOffset.Text = "30"; // 엣지부터의 오프셋
            txtContourTwoDerivativeValue.Text = "7";
            // Processing Params 
            nupdnTwoDerivativeValue.Text = "7";
            //Canny
            txtCannyThres1.Text = "30.0";
            txtCannyThres2.Text = "200.0";
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();

            if (dig.ShowDialog() == DialogResult.OK)
            {
                ClearDefectLog();

                RuleImageDisplayControl.IsNewOpenImage = true;

                txtImagePath.Text = dig.FileName;
                ImageLoad(txtImagePath.Text);
            }
        }

        private void ImageLoad(string path)
        {
            FileInfo info = new FileInfo(path);

            if (info.Exists == false)
            {
                MessageBox.Show("File is not exists.");
                return;
            }

            if (_originalBmp != null)
            {
                _originalBmp.Dispose();
                _originalBmp = null;
            }

            _originalBmp = new Bitmap(path);

            RuleImageDisplayControl.DisplayImage(_originalBmp);
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            Excute();
        }

        private void Excute()
        {
            if (_originalBmp == null)
            {
                MessageBox.Show("image does not exist.");
                return;
            }

            ClearDefectLog();
            SetActiveParams();

            _inspThread = new Thread(ThreadFunc);
            _inspThread.Start();
        }

        private void ClearDefectLog()
        {
            lbxBrokenLog.Items.Clear();
            lbxContourLog.Items.Clear();
        }

        private void SetActiveParams()
        {
            _isSelectBrokenDefect = false;
            _isSelectContourDefect = false;
            _selectedDefectRect = new Rectangle();

            _inspDirectionType = (eEdgeType)Enum.Parse(typeof(eEdgeType), cbxDirection.SelectedItem as string);
            _offset = Convert.ToInt32(txtOffset.Text);
        }

        private void ThreadFunc()
        {
            EnableExcuteButton(false);

            // Offset 적용한 이미지
            Bitmap inspImage = GetInspImage();
            // TwoDerivativeValue 에 맞게 이미지 세팅
            SetFilterImage(_originalBmp);

            List<Rectangle> defectList = Inspection(inspImage);

            CalcOffset(defectList);
            
            AddDefectInfo(_finallyDefectList);

            DisplayImage(_finallyDefectList);

            EnableExcuteButton(true);

            Thread.Sleep(10);
        }

        public void EnableExcuteButton(bool isEnable)
        {
            if (this.InvokeRequired)
            {
                EnableExcuteButtonDele dele = new EnableExcuteButtonDele(EnableExcuteButton);
                this.Invoke(dele, isEnable);
                return;
            }

            btnExcute.Enabled = isEnable;
        }

        private Bitmap GetInspImage()
        {
            if (ckbOffset.Checked)
            {
                return CalcOffsetImage(_originalBmp, _inspDirectionType, _offset);
            }
            else
            {
                return _originalBmp.Clone() as Bitmap;
            }
        }

        private Bitmap CalcOffsetImage(Bitmap orgImage, eEdgeType type, int offset)
        {
            Rectangle cropRect = new Rectangle();

            if (type == eEdgeType.Left)
            {
                cropRect = new Rectangle(offset, 0, orgImage.Width - offset, orgImage.Height);
            }
            else if (type == eEdgeType.Right)
            {
                cropRect = new Rectangle(0, 0, orgImage.Width - offset, orgImage.Height);
            }
            else if (type == eEdgeType.Top)
            {
                cropRect = new Rectangle(0, offset, orgImage.Width, orgImage.Height - offset);
            }
            else if (type == eEdgeType.Bottom)
            {
                cropRect = new Rectangle(0, 0, orgImage.Width, orgImage.Height - offset);
            }

            return orgImage.Clone(cropRect, orgImage.PixelFormat);
        }

        private void SetFilterImage(Bitmap bmp)
        {
            int twoDerivativeValue = GetTwoDerivativeValueFromType(_inspType);

            switch (_inspDirectionType)
            {
                case eEdgeType.Left:

                case eEdgeType.Right:
                    _binarizationBmp = HanMechImageHelper.ProcessTwoDerivative(bmp, eDirection.Vertical, twoDerivativeValue);
                    break;

                case eEdgeType.Top:

                case eEdgeType.Bottom:
                    _binarizationBmp = HanMechImageHelper.ProcessTwoDerivative(bmp, eDirection.Horizon, twoDerivativeValue);
                    break;

                case eEdgeType.None:

                default:
                    _binarizationBmp = HanMechImageHelper.ProcessTwoDerivative(bmp, eDirection.All, twoDerivativeValue);
                    break;
            }
        }

        private int GetTwoDerivativeValueFromType(eInspType inspType)
        {
            if (_inspType == eInspType.Broken)
            {
                return Convert.ToInt32(txtBrokenTwoDerivativeValue.Text);
            }
            else if (_inspType == eInspType.Contour)
            {
                return Convert.ToInt32(txtContourTwoDerivativeValue.Text);
            }
            else
            {
                return Convert.ToInt32(nupdnTwoDerivativeValue.Value);
            }
        }

        private List<Rectangle> Inspection(Bitmap bmp)
        {
            List<Rectangle> defectList = new List<Rectangle>();

            if (_inspType == eInspType.Broken)
            {
                defectList.AddRange(BrokenInspection(bmp, _inspDirectionType));
            }
            else if (_inspType == eInspType.Contour)
            {
                defectList.AddRange(ContourInspection(bmp, _inspDirectionType));
            }
            else if (_inspType == eInspType.Canny)
            {
                return defectList;
            }

            return defectList;
        }

        private void CalcOffset(List<Rectangle> defectList)
        {
            if (_inspType == eInspType.Broken)
            {
                _finallyDefectList = CalcBrokenOffsetList(defectList);
            }
            else if (_inspType == eInspType.Contour)
            {
                _finallyDefectList = CalcContourOffsetList(defectList);
            }
            else if (_inspType == eInspType.Canny)
            {
                return;
            }
        }

        private List<Rectangle> BrokenInspection(Bitmap bmp, eEdgeType type)
        {
            BrokenParams param = new BrokenParams();
            param.BrokenVal = Convert.ToDouble(txtBrokenValue.Text);
            param.AvgCnt = Convert.ToInt32(txtBrokenAvgCnt.Text);
            param.TwoDerivativeValue = Convert.ToInt32(txtBrokenTwoDerivativeValue.Text);
            param.Threshold1 = Convert.ToSingle(txtBrokenThres1.Text);
            param.Threshold2 = Convert.ToSingle(txtBrokenThres2.Text);
            //Threshold 값 넣기
            BrokenAlgorithms algo = new BrokenAlgorithms();
            algo.SetParam(param);

            List<Rectangle> defectList = algo.Run(bmp, type);

            return defectList;
        }

        private List<Rectangle> ContourInspection(Bitmap bmp, eEdgeType type)
        {
            // Channel 예외처리
            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmp);
            if (mat.Channels() != 1)
            {
                Cv2.CvtColor(mat, mat, ColorConversionCodes.BGR2GRAY);
            }

            EdgeElement element = SearchEdge(mat, type);

            // 엣지 못찾았을 때 
            if (element.Index == -1)
            {
                MessageBox.Show("Couldn't find the edge");

                if (mat != null)
                    mat.Dispose();

                _contourInspectionArea = new Rectangle();

                return new List<Rectangle>();
            }

            _elementIndex = element.Index;

            // 영역에 맞게 이미지 자르기
            Bitmap cropBmp = CropImage(bmp, type, element, Convert.ToInt16(txtContourInspectionOffset.Text), Convert.ToInt16(txtContourInspectionArea.Text));
            GetInspectionArea(type);

            // Set Params
            ContourParams param = new ContourParams();
            param.TwoDerivativeValue = Convert.ToInt32(txtContourTwoDerivativeValue.Text);
            param.MinSize = Convert.ToDouble(txtContourMinSize.Text);

            ContourAlgorithms algo = new ContourAlgorithms();
            algo.SetParam(param);

            _contourDataList = algo.Run(cropBmp, type);

            return ConvertDefectList(_contourDataList);
        }

        private EdgeElement SearchEdge(Mat mat, eEdgeType type)
        {
            EdgeElement element = new EdgeElement();
            switch (type)
            {
                case eEdgeType.Left:
                    element = EdgeDetect.FindLeftEdgeIndex(mat, 0, 0);
                    break;

                case eEdgeType.Right:
                    element = EdgeDetect.FindRightEdgeIndex(mat, 0, 0);
                    break;

                case eEdgeType.Top:
                    element = EdgeDetect.FindTopEdgeIndex(mat, 0, 0, false);
                    break;

                case eEdgeType.Bottom:
                    element = EdgeDetect.FindBottomEdgeIndex(mat, 0, 0);
                    break;
            }

            return element;
        }

        private List<Rectangle> ConvertDefectList(List<ContourData> contourList)
        {
            List<Rectangle> convertRectList = new List<Rectangle>();

            foreach (ContourData data in contourList)
            {
                Rectangle defect = new Rectangle((int)data.BoundingX, (int)data.BoundingY, (int)data.BoundingWidth, (int)data.BoundingHeight);
                convertRectList.Add(defect);
            }

            return convertRectList;
        }

        private List<Rectangle> CalcBrokenOffsetList(List<Rectangle> defectList)
        {
            if (!ckbOffset.Checked)
                return defectList;

            List<Rectangle> offsetDefectList = new List<Rectangle>();
            foreach (Rectangle defect in defectList)
            {
                int x = defect.X;
                int y = defect.Y;
                int width = defect.Width;
                int height = defect.Height;

                if (_inspDirectionType == eEdgeType.Left)
                {
                    x = defect.X + _offset;
                }
                else if (_inspDirectionType == eEdgeType.Top)
                {
                    y = defect.Y + _offset;
                }

                offsetDefectList.Add(new Rectangle(x, y, width, height));
            }

            return offsetDefectList;
        }

        private List<Rectangle> CalcContourOffsetList(List<Rectangle> defectList)
        {
            int inspectionArea = Convert.ToInt16(txtContourInspectionArea.Text);
            int inspectionOffset = Convert.ToInt32(txtContourInspectionOffset.Text);

            List<Rectangle> offsetDefectList = new List<Rectangle>();
            foreach (Rectangle defect in defectList)
            {
                int x = defect.X;
                int y = defect.Y;
                int width = defect.Width;
                int height = defect.Height;

                if (_inspDirectionType == eEdgeType.Left)
                {
                    x = defect.X + _offset + _elementIndex + inspectionOffset;
                }
                else if (_inspDirectionType == eEdgeType.Right)
                {
                    x = defect.X + _elementIndex - inspectionOffset - inspectionArea;
                }
                else if (_inspDirectionType == eEdgeType.Top)
                {
                    y = defect.Y + _offset + _elementIndex + inspectionOffset;
                }
                else if (_inspDirectionType == eEdgeType.Bottom)
                {
                    y = defect.Y + _elementIndex - inspectionOffset - inspectionArea;
                }

                offsetDefectList.Add(new Rectangle(x, y, width, height));
            }

            return offsetDefectList;
        }

        private void AddDefectInfo(List<Rectangle> defectList)
        {
            for (int index = 0; index < defectList.Count; index++)
            {
                if (_inspType == eInspType.Broken)
                {
                    string defectInfo =
                        " [Num : " + index + "]," +
                        " [X : " + defectList[index].X + "]," +
                        " [Y : " + defectList[index].Y + "]," +
                        " [Width : " + defectList[index].Width + "]," +
                        " [Height : " + defectList[index].Height + "]";

                    AddDefectLog(lbxBrokenLog, defectInfo);
                }
                else if (_inspType == eInspType.Contour)
                {
                    string defectInfo =
                        " [Num : " + index + "]," +
                        " [X : " + defectList[index].X + "]," +
                        " [Y : " + defectList[index].Y + "]," +
                        " [Width : " + defectList[index].Width + "]," +
                        " [Height : " + defectList[index].Height + "]," +
                        " [CenterX : " + Math.Round(_contourDataList[index].CenterX, 3) + "]," +
                        " [CenterY : " + Math.Round(_contourDataList[index].CenterY, 3) + "]," +
                        " [Perimeter : " + Math.Round(_contourDataList[index].Perimeter, 3) + "]," +
                        " [ContourArea : " + _contourDataList[index].ContourArea + "]," +
                        " [HullSize : " + _contourDataList[index].HullSize + "]," +
                        " [LineAngle : " + Math.Round(_contourDataList[index].LineAngle, 3) + "]," +
                        " [BoundingRatio : " + _contourDataList[index].BoundingRatio + "]," +
                        " [BoundingSize : " + _contourDataList[index].BoundingSize + "],";

                    AddDefectLog(lbxContourLog, defectInfo);
                }
            }
        }

        private void DisplayImage(List<Rectangle> defectList)
        {
            Bitmap displayImage = null;

            if (_inspType == eInspType.Canny)
            {
                double thres1 = Convert.ToSingle(txtCannyThres1.Text);
                double thres2 = Convert.ToSingle(txtCannyThres2.Text);

                if (thres1 < 0 || thres1 > 255)
                    return;
                if (thres2 < 0 || thres2 > 255)
                    return;

                displayImage = GetCanny(thres1, thres2);
            }
            else if (_inspType == eInspType.Broken || _inspType == eInspType.Contour)
            {
                if (_isOriginalImage) // orignal
                {
                    displayImage = GetDisplayImage(_originalBmp, defectList);
                }
                else // filter
                {
                    displayImage = GetDisplayImage(_binarizationBmp, defectList);
                }
            }

            RuleImageDisplayControl.DisplayImage(displayImage);
        }

        private Bitmap GetDisplayImage(Bitmap bmp, List<Rectangle> defectList)
        {
            Bitmap displayBmp = null;

            try
            {
                displayBmp = new Bitmap(bmp.Width, bmp.Height);

                using (Graphics g = Graphics.FromImage(displayBmp))
                {
                    g.DrawImage(bmp, new PointF(0, 0));
                    // All Defect
                    foreach (Rectangle rect in defectList)
                    {
                        g.DrawRectangle(new Pen(Color.Red, 1), rect);
                    }
                    // Contour Inspection Area
                    if (_isDrawInspArea && _inspType == eInspType.Contour)
                    {
                        g.DrawRectangle(new Pen(Color.Yellow, 1), _contourInspectionArea);
                    }
                    // Selected Defect
                    if (_isSelectBrokenDefect || _isSelectContourDefect)
                    {
                        g.DrawRectangle(new Pen(Color.Blue, 2), _selectedDefectRect);
                    }
                }

                return displayBmp;
            }
            catch (Exception)
            {
                return displayBmp;
            }
        }

        private Bitmap CropImage(Bitmap bmp, eEdgeType type, EdgeElement element, int offset, int inspArea)
        {
            Bitmap cropBmp = null;
            Rectangle cropRect = new Rectangle();

            switch (type)
            {
                case eEdgeType.Left:
                    cropRect = new Rectangle(element.Index + offset, 0, inspArea, element.OrgImageHeight);
                    break;

                case eEdgeType.Right:
                    cropRect = new Rectangle(element.Index - offset - inspArea, 0, inspArea, element.OrgImageHeight);
                    break;

                case eEdgeType.Top:
                    cropRect = new Rectangle(0, element.Index + offset, element.OrgImageWidth, inspArea);
                    break;

                case eEdgeType.Bottom:
                    cropRect = new Rectangle(0, element.Index - offset - inspArea, element.OrgImageWidth, inspArea);
                    break;
            }

            // 예외처리
            if (cropRect.X > element.OrgImageWidth)
            {
                cropRect.X = element.OrgImageWidth - inspArea;
            }
            if (cropRect.Y > element.OrgImageHeight)
            {
                cropRect.Y = element.OrgImageHeight - inspArea;
            }

            _contourInspectionArea = cropRect;
            cropBmp = bmp.Clone(cropRect, bmp.PixelFormat);

            return cropBmp;
        }

        private void GetInspectionArea(eEdgeType type)
        {
            if (!ckbOffset.Checked)
                return;

            switch (type)
            {
                case eEdgeType.Left:
                    _contourInspectionArea.X += Convert.ToInt32(txtOffset.Text);
                    break;

                case eEdgeType.Right:
                    break;

                case eEdgeType.Top:
                    _contourInspectionArea.Y += Convert.ToInt32(txtOffset.Text);
                    break;

                case eEdgeType.Bottom:
                    break;
            }
        }

        private void AddDefectLog(ListBox lbx, string text)
        { 
            try
            {
                if (this.InvokeRequired)
                {
                    AddDefectLogDele callBack = AddDefectLog;
                    Invoke(callBack, lbx, text);
                    return;
                }

                lbx.Items.Add(text);
            }
            catch (Exception ex)
            {
            }
        }

        private void ckbOffset_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbOffset.Checked)
            {
                OffsetUse(txtOffset, true);
            }
            else
            {
                OffsetUse(txtOffset, false);
            }
        }

        private void OffsetUse(TextBox txt, bool isUse)
        {
            txt.Enabled = isUse;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_originalBmp == null)
                return;

            if (tabInspectionType.SelectedIndex == 0)
            {
                _inspType = eInspType.Broken;
                tabInspectionLogType.SelectedIndex = 0;
            }
            else if (tabInspectionType.SelectedIndex == 1)
            {
                _inspType = eInspType.Contour;
                tabInspectionLogType.SelectedIndex = 1;
            }
            else if (tabInspectionType.SelectedIndex == 2)
            {
                Bitmap displayImage = GetApplyFilterImage();
                RuleImageDisplayControl.DisplayImage(displayImage);

                return;
            }
            else if (tabInspectionType.SelectedIndex == 3)
            {
                _inspType = eInspType.Canny;
                double thres1 = Convert.ToSingle(txtCannyThres1.Text);
                double thres2 = Convert.ToSingle(txtCannyThres2.Text);

                if (thres1 < 0 || thres1 > 255)
                    return;
                if (thres2 < 0 || thres2 > 255)
                    return;

                Bitmap bmp = GetCanny(thres1, thres2);
                RuleImageDisplayControl.DisplayImage(bmp);

                return;
            }
            else
            {
                _inspType = eInspType.None;
                return;
            }

            Excute();
        }

        private void btnFitSize_Click(object sender, EventArgs e)
        {
            RuleImageDisplayControl.DisplayFitSize();
        }

        private void btnOrizinalSize_Click(object sender, EventArgs e)
        {
            RuleImageDisplayControl.DisplayOrizinalSize();
        }

        private void btnOriginalImage_Click(object sender, EventArgs e)
        {
            _isOriginalImage = true;

            if (_finallyDefectList == null)
                return;

            if (_inspType == eInspType.None || _inspType == eInspType.Canny)
            {
                //_finallyDefectList = new List<Rectangle>();
                RuleImageDisplayControl.DisplayImage(_originalBmp);
                return;
            }

            DisplayImage(_finallyDefectList);
        }

        private void btnFilterImage_Click(object sender, EventArgs e)
        {
            _isOriginalImage = false;

            if (_finallyDefectList == null)
                return;

            if (_inspType == eInspType.None)
                _finallyDefectList = new List<Rectangle>();

            DisplayImage(_finallyDefectList);
        }

        private void ckbDrawInspArea_CheckedChanged(object sender, EventArgs e)
        {
            if (_finallyDefectList == null)
                return;

            if (ckbDrawInspArea.Checked)
            {
                _isDrawInspArea = true;
            }
            else
            {
                _isDrawInspArea = false;
            }

            if (_originalBmp == null || _binarizationBmp == null)
                return;

            DisplayImage(_finallyDefectList);
        }

        private void nupdnTwoDerivativeValue_ValueChanged(object sender, EventArgs e)
        {
            int twoDerivateValue = Convert.ToInt32(nupdnTwoDerivativeValue.Value);

            if (twoDerivateValue > 50)
            {
                twoDerivateValue = 50;
            }
            else if (twoDerivateValue < 0)
            {
                twoDerivateValue = 0;
            }

            Bitmap displayImage = GetApplyFilterImage();
            RuleImageDisplayControl.DisplayImage(displayImage);
        }

        private void cbxProcessingFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap displayImage = GetApplyFilterImage();
            RuleImageDisplayControl.DisplayImage(displayImage);
        }

        private Bitmap GetApplyFilterImage()
        {
            int twoDerivateValue = Convert.ToInt32(nupdnTwoDerivativeValue.Value);
            eDirection filterType = (eDirection)Enum.Parse(typeof(eDirection), cbxProcessingFilterType.SelectedItem as string);
            Bitmap displayImage = HanMechImageHelper.ProcessTwoDerivative(_originalBmp, filterType, twoDerivateValue);

            return displayImage;
        }

        private Bitmap GetCanny(double thres1, double thres2)
        {
            Mat mat = BitmapConverter.ToMat(_originalBmp);

            if (mat.Channels() != 1)
            {
                Cv2.CvtColor(mat, mat, OpenCvSharp.ColorConversionCodes.BGR2GRAY);
            }

            Cv2.Canny(mat, mat, thres1, thres2);

            Bitmap retBmp = BitmapConverter.ToBitmap(mat);
            mat.Dispose();

            return retBmp;
        }

        private void lbxBrokenLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isSelectBrokenDefect = true;
            _isSelectContourDefect = false;

            DisplaySelectedDefect(lbxBrokenLog);
        }

        private void lbxContourLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isSelectBrokenDefect = false;
            _isSelectContourDefect = true;

            DisplaySelectedDefect(lbxContourLog);
        }

        private void DisplaySelectedDefect(ListBox lbx)
        {
            if (lbx.SelectedItem == null)
                return;

            int defectIndex = lbx.SelectedIndex;

            _selectedDefectRect = _finallyDefectList[defectIndex];

            DisplayImage(_finallyDefectList);
        }

        private void txtBrokenTwoDerivativeValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtContourTwoDerivativeValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtOffset_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtBrokenValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtContourInspectionArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtContourInspectionOffset_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
