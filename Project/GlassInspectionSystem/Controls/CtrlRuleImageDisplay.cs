using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using System.IO;
using System.Drawing.Drawing2D;
using GlassInspectionSystem.Forms;
using RuleAlgorithm.Broken;
using RuleAlgorithm.Utility;

namespace GlassInspectionSystem.Controls
{
    public partial class CtrlRuleImageDisplay : UserControl
    {
        public DoubleBufferPicture DoubleBufferPbx = new DoubleBufferPicture();
        public bool IsNewOpenImage = false;

        private Bitmap _displayBmp = null;
        private System.Drawing.Point _imgPoint = new System.Drawing.Point();
        private System.Drawing.Point _originalImgPoint = new System.Drawing.Point();
        private System.Drawing.Point _mouseDownPoint = new System.Drawing.Point();
        private int _pbxWidth = 0;
        private int _pbxHeight = 0;
        private float _imageX = 0;
        private float _imageY = 0;

        public CtrlRuleImageDisplay()
        {
            InitializeComponent();
        }

        private void CtrlRuleImageDisplay_Load(object sender, EventArgs e)
        {
            DoubleBufferPbx = new DoubleBufferPicture();
            pbxDisplayImage.Controls.Add(DoubleBufferPbx);
            DoubleBufferPbx.Dock = DockStyle.Fill;
            DoubleBufferPbx.Paint += new PaintEventHandler(PbxPaintEvent);
            DoubleBufferPbx.MouseMove += new MouseEventHandler(PbxMouseMoveEvent);
            DoubleBufferPbx.MouseDown += new MouseEventHandler(PbxMouseDownEvent);
            DoubleBufferPbx.MouseUp += new MouseEventHandler(PbxMouseUpEvent);
            DoubleBufferPbx.MouseWheel += new MouseEventHandler(PbxMouseWheelEvent);
        }

        public delegate void InvokeDisplayImageDele(Bitmap bmp);
        public void DisplayImage(Bitmap bmp)
        {
            if (this.InvokeRequired)
            {
                InvokeDisplayImageDele callback = DisplayImage;
                BeginInvoke(callback, bmp);
                return;
            }

            if (bmp == null)
                return;

            _displayBmp = bmp.Clone() as Bitmap;
            double ratio = 1;

            if (bmp.Width > bmp.Height)
            {
                ratio = (double)pnlDisplay.Width / (double)bmp.Width;
            }
            else
            {
                ratio = (double)pnlDisplay.Height / (double)bmp.Height;
            }

            if (IsNewOpenImage)
            {
                _imgPoint = new System.Drawing.Point();

                CalculateRatio(bmp, ratio);
                //IsNewOpenImage = false;
            }

            if (DoubleBufferPbx != null)
                DoubleBufferPbx.Invalidate();
        }

        public void CalculateRatio(Bitmap bmp, double ratio)
        {
            pbxDisplayImage.Width = Convert.ToInt32(bmp.Width * ratio);
            pbxDisplayImage.Height = Convert.ToInt32(bmp.Height * ratio);
            _imgPoint = new System.Drawing.Point((pnlDisplay.Width - pbxDisplayImage.Width) / 2, (pnlDisplay.Height - pbxDisplayImage.Height) / 2);
            pbxDisplayImage.Location = _imgPoint;
            _originalImgPoint = _imgPoint;

            _pbxWidth = pbxDisplayImage.Width;
            _pbxHeight = pbxDisplayImage.Height;
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
            if (_displayBmp == null)
                return;

            Bitmap newBmp = new Bitmap(pbxDisplayImage.Width, pbxDisplayImage.Height);
            Rectangle drawRect = new Rectangle(0, 0, newBmp.Width, newBmp.Height);

            //g.Clear(SystemColors.MenuText);
            g.DrawImage(_displayBmp, drawRect);

            //pbxDisplayImage.Image = newBmp.Clone() as Bitmap;

            IsNewOpenImage = false;

            if (newBmp != null)
            {
                newBmp.Dispose();
                newBmp = null;
            }
        }

        private void PbxMouseMoveEvent(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && IsNewOpenImage == false)
            if (e.Button == MouseButtons.Left && IsNewOpenImage == false)
            {
                int valueX = e.X - _mouseDownPoint.X;
                int valueY = e.Y - _mouseDownPoint.Y;

                _imgPoint = new System.Drawing.Point(pbxDisplayImage.Location.X + valueX, pbxDisplayImage.Location.Y + valueY);
                //System.Drawing.Point newImgPoint = new System.Drawing.Point(pbxDisplayImage.Location.X + valueX, pbxDisplayImage.Location.Y + valueY);
                //pbxDisplayImage.Location = newImgPoint;
                pbxDisplayImage.Location = _imgPoint;
            }

            UpdateLocation();

            if (DoubleBufferPbx != null)
                DoubleBufferPbx.Invalidate();
        }

        private void UpdateLocation()
        {
            System.Drawing.Point currentPoint = new System.Drawing.Point(MousePosition.X, MousePosition.Y);
            System.Drawing.Point mousePoint = pbxDisplayImage.PointToClient(currentPoint);

            _imageX = (_displayBmp.Width * mousePoint.X) / pbxDisplayImage.Width;
            _imageY = (_displayBmp.Height * mousePoint.Y) / pbxDisplayImage.Height;

            if (_imageX < 0 || _imageX > pbxDisplayImage.Width - 1)
                return;
            if (_imageY < 0 || _imageY > pbxDisplayImage.Height - 1)
                return;

            Color color = _displayBmp.GetPixel((int)_imageX, (int)_imageY);

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

            int oldWidth = pbxDisplayImage.Width;
            int oldHeight = pbxDisplayImage.Height;

            int width = Convert.ToInt32(pbxDisplayImage.Width * ratio);
            int height = Convert.ToInt32(pbxDisplayImage.Height * ratio);
            int verticalScroll = pnlDisplay.VerticalScroll.Value;
            pbxDisplayImage.Width = width;
            pbxDisplayImage.Height = height;

            int x = e.X - pbxDisplayImage.Location.X;
            int y = e.Y - pbxDisplayImage.Location.Y;
            int oldImageX = (int)(x / oldRatio);
            int oldImageY = (int)(y / oldRatio);
            int newImageX = (int)(x / ratio);
            int newImageY = (int)(y / ratio);
            int newPointX = newImageX - oldImageX + pbxDisplayImage.Location.X;
            int newPointY = newImageY - oldImageY + pbxDisplayImage.Location.Y;

            //_imgPoint = new System.Drawing.Point(newPointX, newPointY);
            System.Drawing.Point newImgPoint = new System.Drawing.Point(newPointX, newPointY);
            pbxDisplayImage.Location = newImgPoint;

            if (DoubleBufferPbx != null)
                DoubleBufferPbx.Invalidate();
        }

        public void DisplayFitSize()
        {
            if (_displayBmp == null)
                return;

            pbxDisplayImage.Width = _pbxWidth;
            pbxDisplayImage.Height = _pbxHeight;
            //pbxDisplayImage.Location = _imgPoint;
            pbxDisplayImage.Location = _originalImgPoint;
        }

        public void DisplayOrizinalSize()
        {
            if (_displayBmp == null)
                return;

            pbxDisplayImage.Width = _displayBmp.Width;
            pbxDisplayImage.Height = _displayBmp.Height;
            pbxDisplayImage.Location = new System.Drawing.Point(0, 0);
        }
    }
}
