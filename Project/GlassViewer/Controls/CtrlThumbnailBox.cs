using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GlassInspectionSystem;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace GlassViewer.Controls
{
    public partial class CtrlThumbnailBox : UserControl
    {
        public static List<String> extensionList = new List<string> { ".jpeg", ".jpg", ".png", ".bmp" };
        public DoubleBufferPicture DoubleBufferPbx = null;
        public bool IsNewOpenImage = false;

        private GlassViewer.Forms.FormGlassViewSettings _glassViewSettings = new Forms.FormGlassViewSettings();
        private GlassViewer.Forms.FormLineChart _lineChart = new Forms.FormLineChart();
        private string _imagePath = string.Empty;
        private string _combinePath = string.Empty;

        private Bitmap _originalBmp = null;
        private Bitmap _displayBmp = null;
        private System.Drawing.Point _imgPoint = new System.Drawing.Point();
        private System.Drawing.Point _originalImgPoint = new System.Drawing.Point();
        private System.Drawing.Point _mouseDownPoint = new System.Drawing.Point();
        private int _pbxWidth = 0;
        private int _pbxHeight = 0;
        private float _imageX = 0;
        private float _imageY = 0;

        public CtrlThumbnailBox()
        {
            InitializeComponent();
        }

        private void CtrlThumbnailBox_Load(object sender, EventArgs e)
        {
            DoubleBufferPbx = new DoubleBufferPicture();
            pbxThumbnailImage.Controls.Add(DoubleBufferPbx);
            DoubleBufferPbx.Dock = DockStyle.Fill;
            DoubleBufferPbx.Paint += new PaintEventHandler(PbxPaintEvent);
            DoubleBufferPbx.MouseMove += new MouseEventHandler(PbxMouseMoveEvent);
            DoubleBufferPbx.MouseDown += new MouseEventHandler(PbxMouseDownEvent);
            DoubleBufferPbx.MouseUp += new MouseEventHandler(PbxMouseUpEvent);
            DoubleBufferPbx.MouseWheel += new MouseEventHandler(PbxMouseWheelEvent);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Status.Instance().Forms.OpenFormGlassViewSettings();
        }

        public string GetThumbnailImagePath(string path)
        {
            _imagePath = Status.Instance().ImagePath;//DB에 저장되어 있는 Image 경로

            if (_imagePath != null)
            {
                foreach (string extensnion in extensionList)
                {
                    _combinePath = ( Path.Combine(Settings.Instance().ImageFolder, _imagePath, "Thumbnail" + extensnion) );
                    FileInfo fileInfo = new FileInfo(_combinePath);

                    if (fileInfo.Exists)
                        return _combinePath;
                }
            }
            return null;
        }

        public string GetCamNoImagePath(string path, double camNo)
        {

            _imagePath = Status.Instance().ImagePath;

            if (_imagePath != null)
            {
                foreach (string extensnion in extensionList)
                {
                    _combinePath = ( Path.Combine(Settings.Instance().ImageFolder, _imagePath, "Cam_" + camNo + extensnion) );
                    FileInfo fileInfo = new FileInfo(_combinePath);

                    if (fileInfo.Exists)
                        return _combinePath;
                }
            }
            return null;
        }

        public delegate void InvokeUpdateThumbnailImageDele(string path);
        public void UpdateThumbnailImage(string path)
        {
            if (this.InvokeRequired)
            {
                InvokeUpdateThumbnailImageDele callback = UpdateThumbnailImage;
                BeginInvoke(callback, path);
                return;
            }

            if (path == string.Empty)
                return;

            _originalBmp = new Bitmap(path);
            _displayBmp = _originalBmp.Clone() as Bitmap;
            double ratio = 1;

            if (_originalBmp.Width > _originalBmp.Height)
            {
                ratio = (double)pnlThumbnail.Width / (double)_originalBmp.Width;
            }
            else
            {
                ratio = (double)pnlThumbnail.Height / (double)_originalBmp.Height;
            }

            if (IsNewOpenImage)
            {
                _imgPoint = new System.Drawing.Point();

                CalculateRatio(_originalBmp, ratio);
            }

            if (DoubleBufferPbx != null)
                DoubleBufferPbx.Invalidate();
        }

        public void CalculateRatio(Bitmap bmp, double ratio)
        {
            pbxThumbnailImage.Width = Convert.ToInt32(bmp.Width * ratio);
            pbxThumbnailImage.Height = Convert.ToInt32(bmp.Height * ratio);
            _imgPoint = new System.Drawing.Point((pnlThumbnail.Width - pbxThumbnailImage.Width) / 2, (pnlThumbnail.Height - pbxThumbnailImage.Height) / 2);
            pbxThumbnailImage.Location = _imgPoint;
            _originalImgPoint = _imgPoint;

            _pbxWidth = pbxThumbnailImage.Width;
            _pbxHeight = pbxThumbnailImage.Height;
        }

        private void PbxPaintEvent(object sender, PaintEventArgs e)
        {
            Display(e.Graphics);
        }

        private void Display(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            DrawImage(g);
        }

        private void DrawImage(Graphics g)
        {
            if (_originalBmp == null)
                return;

            Bitmap newBmp = new Bitmap(pbxThumbnailImage.Width, pbxThumbnailImage.Height);
            Rectangle drawRect = new Rectangle(0, 0, newBmp.Width, newBmp.Height);

            g.DrawImage(_displayBmp, drawRect);

            IsNewOpenImage = false;

            if (newBmp != null)
            {
                newBmp.Dispose();
                newBmp = null;
            }
        }

        private void PbxMouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && IsNewOpenImage == false)
            {
                int valueX = e.X - _mouseDownPoint.X;
                int valueY = e.Y - _mouseDownPoint.Y;

                _imgPoint = new System.Drawing.Point(pbxThumbnailImage.Location.X + valueX, pbxThumbnailImage.Location.Y + valueY);
                pbxThumbnailImage.Location = _imgPoint;
            }

            UpdateLocation();

            if (DoubleBufferPbx != null)
                DoubleBufferPbx.Invalidate();
        }

        private void UpdateLocation()
        {
            if (_originalBmp == null)
                return;

            System.Drawing.Point currentPoint = new System.Drawing.Point(MousePosition.X, MousePosition.Y);
            System.Drawing.Point mousePoint = pbxThumbnailImage.PointToClient(currentPoint);

            _imageX = (_originalBmp.Width * mousePoint.X) / pbxThumbnailImage.Width;
            _imageY = (_originalBmp.Height * mousePoint.Y) / pbxThumbnailImage.Height;

            if (_imageX < 0 || _imageY < 0)
                return;

            Color color = _originalBmp.GetPixel((int)_imageX, (int)_imageY);

            DisplayLocation(_imageX, lblX);
            DisplayLocation(_imageY, lblY);
            DisplayLocation(color.R, lblGrayLevel);
        }

        private delegate void DisplayLocationDele(float location, Label lbl);
        public void DisplayLocation(float location, Label lbl)
        {
            if (this.InvokeRequired)
            {
                DisplayLocationDele callback = DisplayLocation;
                BeginInvoke(callback, location, lbl);
                return;
            }

            lbl.Text = location.ToString();
            lbl.Update();
        }

        private void PbxMouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseDownPoint = e.Location;
            }

            if (DoubleBufferPbx != null)
                DoubleBufferPbx.Invalidate();
        }

        private void PbxMouseUpEvent(object sender, MouseEventArgs e)
        {
            //
        }

        private void PbxMouseWheelEvent(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys != Keys.Control)
                return;

            double ratio = 1;
            double oldRatio = ratio;
            int lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;

            if (lines > 0)
            {
                ratio *= 1.1;
            }
            else if (lines < 0)
            {
                ratio *= 0.9;
            }

            int oldWidth = pbxThumbnailImage.Width;
            int oldHeight = pbxThumbnailImage.Height;

            int width = Convert.ToInt32(pbxThumbnailImage.Width * ratio);
            int height = Convert.ToInt32(pbxThumbnailImage.Height * ratio);
            int verticalScroll = pnlThumbnail.VerticalScroll.Value;
            pbxThumbnailImage.Width = width;
            pbxThumbnailImage.Height = height;

            int x = e.X - pbxThumbnailImage.Location.X;
            int y = e.Y - pbxThumbnailImage.Location.Y;
            int oldImageX = (int)(x / oldRatio);
            int oldImageY = (int)(y / oldRatio);
            int newImageX = (int)(x / ratio);
            int newImageY = (int)(y / ratio);
            int newPointX = newImageX - oldImageX + pbxThumbnailImage.Location.X;
            int newPointY = newImageY - oldImageY + pbxThumbnailImage.Location.Y;

            System.Drawing.Point newImgPoint = new System.Drawing.Point(newPointX, newPointY);
            pbxThumbnailImage.Location = newImgPoint;

            if (DoubleBufferPbx != null)
                DoubleBufferPbx.Invalidate();
        }

        public void UpdateDefectImage(string path, double camNo, RectangleF defectRect, int defectViewSize, double thumbnailImageRatio, string dftType, int mergeTopOffset)
        {
            Bitmap defectBmp = new Bitmap(path);//DefectImage 경로를 넣어서 Bitmap 생성
            _displayBmp = _originalBmp.Clone() as Bitmap;

            //defectRect = new RectangleF(defectRect.X, defectRect.Y, defectRect.Width, defectRect.Height);
            // 21.04.20 Defect 실제 크기보다 크게 보여주기 위해 수정
            defectRect = new RectangleF(defectRect.X - (defectViewSize / 2), defectRect.Y - (defectViewSize / 2), defectViewSize, defectViewSize);

            float X = Convert.ToSingle(((float)defectRect.X + (Convert.ToInt32(camNo) * defectBmp.Width)) / thumbnailImageRatio);
            float Y = Convert.ToSingle((float)(defectRect.Y + mergeTopOffset) / thumbnailImageRatio);
            float Width = Convert.ToSingle((float)defectRect.Width / thumbnailImageRatio);
            float Height = Convert.ToSingle((float)defectRect.Height / thumbnailImageRatio);

            // 21.04.13 예외처리 추가
            if ((float)defectRect.X + (float)defectRect.Width > defectBmp.Width)
            {
                defectRect.Width = Math.Abs((float)defectBmp.Width - (float)defectRect.X - 1);
            }

            if ((float)defectRect.Y + (float)defectRect.Height > defectBmp.Height)
            {
                defectRect.Height = Math.Abs((float)defectBmp.Height - (float)defectRect.Y - 1);
            }

            if (X < 0)
                X = 0;
            if (Y < 0)
                Y = 0;
            if (Width < 1)
                Width = 1;
            if (Height < 1)
                Height = 1;

            Bitmap cropBmp = defectBmp.Clone(defectRect, defectBmp.PixelFormat);//defect영역만큼의 cropBmp 생성
            //float newPointX = Convert.ToSingle((float)X - (((float)Width / 2) * (float)defectImageRatio));
            //float newPointY = Convert.ToSingle((float)Y - (((float)Height / 2) * (float)defectImageRatio));
            float newPointX = Convert.ToSingle((float)X - (((float)Width / 2)));
            float newPointY = Convert.ToSingle((float)Y - (((float)Height / 2)));

            // 21.04.20 Defect 실제 크기보다 크게 보여주기 위해 수정
            //defectRect = new RectangleF(newPointX, newPointY, Width * defectImageRatio, Height * defectImageRatio);
            defectRect = new RectangleF(newPointX - (defectViewSize / 2), newPointY - (defectViewSize / 2), Width + defectViewSize, Height + defectViewSize);

            RectangleF[] defectRects = { defectRect };
            string boundingXY = dftType + " (" + defectRect.X + "," + defectRect.Y + ")";
            Font font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.Red);

            using (Graphics g = Graphics.FromImage(_displayBmp))
            {
                g.DrawImage(cropBmp, defectRect);

                g.DrawRectangles(new Pen(Color.Yellow, 2), defectRects);

                float boundingXYWidth = g.MeasureString(boundingXY, font).Width;
                float boundingXYHeight = g.MeasureString(boundingXY, font).Height;

                if (defectRect.X + boundingXYWidth > _originalBmp.Width)
                {
                    PointF boundingXYPointF = new PointF(defectRect.X - Math.Abs(_originalBmp.Width - (boundingXYWidth + defectRect.X)), defectRect.Y - boundingXYHeight);
                    g.DrawString(boundingXY, font, brush, boundingXYPointF);
                }
                else
                {
                    PointF boundingXYPointF = new PointF(defectRect.X, defectRect.Y - boundingXYHeight);
                    g.DrawString(boundingXY, font, brush, boundingXYPointF);
                }
            }

            if (DoubleBufferPbx != null)
                DoubleBufferPbx.Invalidate();
        }

        public void ClearImage()
        {
            if (pbxThumbnailImage.Image != null)
            {
                Bitmap oldBmp = pbxThumbnailImage.Image as Bitmap;
                oldBmp.Dispose();
                oldBmp = null;
                pbxThumbnailImage.Image = null;
            }
        }

        private void pbxThumbnailImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int totalCamCount = Status.Instance().TotalCamCount;
            string filePath = string.Empty;
            int interval = 0;

            if (totalCamCount != 0)
                interval = pbxThumbnailImage.Width / totalCamCount; //image의 간격 설정

            filePath = GetFilePathFromPoint(interval, totalCamCount, e); //더블클릭한 위치에 맞는 FilePath를 가져옴

            if (filePath != string.Empty && totalCamCount != 0)
                Process.Start(filePath); //해당 CamImage 실행
        }

        private string GetFilePathFromPoint(int interval, int totalCamCount, MouseEventArgs e)
        {
            string filePath = string.Empty;
            int camNo = 0;

            //마우스 클릭한 위치에 따라 camNo를 구하는 for문
            for(int camNoIndex = 0; camNoIndex < totalCamCount; camNoIndex++)
            {
                if (e.Location.X <= interval * (camNoIndex + 1))
                {
                    camNo = camNoIndex;
                    break;
                }
            }

            filePath = GetCamNoImagePath(filePath, camNo); //camNo에 맞는 filePath 불러오기

            return filePath;
        }
        
        private void btnViewLineChart_Click(object sender, EventArgs e)
        {
            Status.Instance().Forms.OpenFormLineChart();
        }

        private void btnFitSize_Click(object sender, EventArgs e)
        {
            if (_originalBmp == null)
                return;

            pbxThumbnailImage.Width = _pbxWidth;
            pbxThumbnailImage.Height = _pbxHeight;
            pbxThumbnailImage.Location = _originalImgPoint;
        }
    }
}
