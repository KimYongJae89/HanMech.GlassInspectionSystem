using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMechLogLib;
using System.Reflection;

namespace GlassInspectionSystem.Controls
{
    public partial class CtrlDrawBox : UserControl
    {
        private bool _isConnected = true;
        private bool _isPanning = false;
        private Point _startingPoint = Point.Empty;
        private Point _movingPoint = Point.Empty;
        private object _objLock = new object();

        public HMechUtility.Controls.DoubleBufferPanel DoubleBuffering = null;
        private bool _isDraw = false;
        private Bitmap _viewBitmap = null;
        private double _imageRatio = 0;
        private int _camNo = -1;
        public int CamNo
        {
            get { return _camNo; }
            set { _camNo = value; }
        }

        public CtrlDrawBox()
        {
            InitializeComponent();
        }

        private void CtrlDrawBox_Load(object sender, EventArgs e)
        {
            AddDoubleBuffering();
        }

        private void AddDoubleBuffering()
        {
            DoubleBuffering = new HMechUtility.Controls.DoubleBufferPanel();
            DoubleBuffering.Dock = DockStyle.Fill;
            this.pnImage.Controls.Add(DoubleBuffering);
            DoubleBuffering.Paint += DoubleBuffering_Paint;
            DoubleBuffering.MouseMove += DoubleBuffering_MouseMove;
        }

        private void DoubleBuffering_Paint(object sender, PaintEventArgs e)
        {
            if (_isDraw)
                DrawImage(e.Graphics);
        }

        private void DoubleBuffering_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (_viewBitmap != null)
                {
                    Point point = pnImage.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y + sbScroll.Value));

                    if (CurrentPointDelegate != null)
                        CurrentPointDelegate(this._camNo, this._imageRatio, point);

                    if (DoubleBuffering != null)
                        DoubleBuffering.Invalidate();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void DrawImage(Graphics g)
        {
            try
            {
                g.Clear(SystemColors.Control);

                g.DrawImage(_viewBitmap, new Point(0, -sbScroll.Value));
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void InitializeScroll(Bitmap bmp)
        {
            sbScroll.Value = 0;
            
            if (bmp.Height > pnImage.Height)
            {
                sbScroll.Visible = true;
                sbScroll.SmallChange = 1;
                sbScroll.LargeChange = 1;
                sbScroll.Maximum = bmp.Height - (pnImage.Height - 1);
            }
            else
            {
                sbScroll.Visible = false;
                sbScroll.Maximum = pnImage.Height;
            }
        }
                                                                    
        public Action<int, double, Point> CurrentPointDelegate;
        private delegate void UpdateImageDele(Bitmap bmp, double ratio);
        
        public void UpdateImage(Bitmap bmp, double ratio)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateImageDele callBack = UpdateImage;
                    BeginInvoke(callBack, bmp, ratio);
                    return;
                }
                _imageRatio = ratio;
                _viewBitmap = bmp;
                _isDraw = true;

                InitializeScroll(bmp);

                if (DoubleBuffering != null)
                    DoubleBuffering.Invalidate();
            }
            catch (Exception err)
            {
                Logger.WriteException(eLogType.ERROR, err);
            }
        }

        public int GetDisplayBoxWidth()
        {
            return this.pnImage.Width;
        }

        public void SetConnected(bool isConnected)
        {
            if (isConnected != _isConnected)
            {
                _isConnected = isConnected;
                if (_isConnected)
                    lblCameraConnected.BackColor = Color.MediumSeaGreen;
                else
                    lblCameraConnected.BackColor = Color.Red;
                lblCameraConnected.Invalidate();
            }
        }

        private void sbScroll_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                if (DoubleBuffering != null)
                    DoubleBuffering.Invalidate();
            }
        }
    }
}