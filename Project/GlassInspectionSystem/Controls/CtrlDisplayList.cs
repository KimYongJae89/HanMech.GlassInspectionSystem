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
using System.Threading;
using System.Reflection;
using enumType;
using GlassInspectionSystem.Class;

namespace GlassInspectionSystem.Controls
{
    public partial class CtrlDisplayList : UserControl
    {
        private List<CtrlDrawBox> _displayList = new List<CtrlDrawBox>();

        public CtrlDisplayList()
        {
            InitializeComponent();
        }

        private void CtrlDisplayList_Load(object sender, EventArgs e)
        {
            CamStatusTimer.Start();
        }

        public void MakeDisplay()
        {
            try
            {
                int camCount = Settings.Instance().Operation.CamCount;
                int controlWidth = this.pnlDisplayList.Width / camCount;
                Point point = new Point(0, 0);
                for (int i = 0; i < camCount; i++)
                {
                    CtrlDrawBox display = new CtrlDrawBox();
                    display.CamNo = i;
                    display.Size = new Size(controlWidth, this.pnlDisplayList.Height);
                    display.Location = point;

                    display.CurrentPointDelegate = UpdateCoordinateTranslation;

                    this.pnlDisplayList.Controls.Add(display);
                    _displayList.Add(display);

                    point.X += controlWidth;
                }
            }
            catch (Exception err)
            {
                Logger.WriteException(eLogType.ERROR, err);
            }
        }

        public void ResizeDisplayList()
        {
            try
            {
                int camCount = Settings.Instance().Operation.CamCount;
                int controlWidth = this.pnlDisplayList.Width / camCount;
                Point point = new Point(0, 0);

                foreach (CtrlDrawBox drawBox in this.pnlDisplayList.Controls)
                {
                    drawBox.Size = new Size(controlWidth, this.Height);
                    drawBox.Location = point;
                    point.X += controlWidth;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        public void DisplayImageUpdate(Bitmap[] mergeImageArray, double ratio)
        {
            try
            {
                for (int i = 0; i < _displayList.Count; i++)
                {
                    _displayList[i].UpdateImage(mergeImageArray[i], ratio);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        public int GetDisplayBoxWidth(int index)
        {
            return _displayList[index].GetDisplayBoxWidth();
        }

        public int GetDisplayCount()
        {
            return _displayList.Count;
        }

        private void CamStatusTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _displayList.Count; i++)
                {
                    if (Machine.Instance().CameraManager.IsOpen(i))
                        _displayList[i].SetConnected(true);
                    else
                        _displayList[i].SetConnected(false);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private delegate void UpdateCoordinateTranslationDelegate(int camno, double ratio, Point point);
        public void UpdateCoordinateTranslation(int camNo, double ratio, Point point)
        {
            if (this.InvokeRequired)
            {
                UpdateCoordinateTranslationDelegate callBack = UpdateCoordinateTranslation;
                BeginInvoke(callBack, camNo, ratio, point);
                return;
            }

            if (ratio == 0)
                return;

            string message = null;
            int width = Settings.Instance().Operation.CamProp[camNo].Width;
            double fov = Settings.Instance().Operation.Fov;
            double resolution = (double)fov / (double)width;

            PointF calcMousePoint = new PointF(point.X * (float)ratio, point.Y * (float)ratio);
            Point cornerPoint = Status.Instance().cornerPoint;

            double realDistanceX = 0;
            double realDistanceY = 0;
            PointF calcPoint = new PointF();

            int leftSideCamNo = camNo;
            int rightSideCamNo = Settings.Instance().Operation.CamCount - 1 - camNo;
            int interval = 0;



            double camInterval = 0;
            if (Settings.Instance().Operation.TwoEdge)
                camInterval = Settings.Instance().Operation.CameraInterval / resolution;
            else
                camInterval = 0;



            switch (Status.Instance().CornerDirection)
            {
                case eOriginDirection.LeftTop:
                    interval = width * leftSideCamNo + (int)(camInterval * leftSideCamNo );
                    //interval = (width + camInterval) * leftSideCamNo;
                    calcMousePoint.X += (float)interval;
                    calcPoint = new PointF(calcMousePoint.X - cornerPoint.X, calcMousePoint.Y - cornerPoint.Y);
                    break;
                case eOriginDirection.LeftBottom:
                    interval = width * leftSideCamNo + (int)( camInterval * leftSideCamNo );
                    calcMousePoint.X += (float)interval;
                    calcPoint = new PointF(calcMousePoint.X - cornerPoint.X, cornerPoint.Y - calcMousePoint.Y);
                    break;
                case eOriginDirection.RightTop:
                    interval = width * rightSideCamNo + (int)( camInterval * rightSideCamNo );
                    calcMousePoint.X -= (float)interval;
                    calcPoint = new PointF(cornerPoint.X - calcMousePoint.X, calcMousePoint.Y - cornerPoint.Y);
                    break;
                case eOriginDirection.RightBottom:
                    interval = width * rightSideCamNo + (int)( camInterval * rightSideCamNo );
                    calcMousePoint.X -= (float)interval;
                    calcPoint = new PointF(cornerPoint.X - calcMousePoint.X, cornerPoint.Y - calcMousePoint.Y);
                    break;
                default:
                    break;
            }

            realDistanceX = (double)calcPoint.X * resolution;
            realDistanceY = (double)calcPoint.Y * resolution;

            if (realDistanceX < 0 || realDistanceY < 0)
            {
                realDistanceX = 0;
                realDistanceY = 0;
            }

            message = string.Format("Origin : " + Status.Instance().CornerDirection.ToString() + " Corner [ Real Point ( {0:0}pixel , {1:0}pixel )   Real Position ( {2:0.00}mm , {3:0.00}mm) ]", calcPoint.X, calcPoint.Y, realDistanceX, realDistanceY);

            if (message != "")
                StatusLabelMeesage.Text = message;
        }

        public void TwoEdge()
        {
            
        }
    }
}