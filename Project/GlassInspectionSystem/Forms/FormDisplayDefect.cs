using GlassInspectionSystem.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlassInspectionSystem.Forms
{
    public partial class FormDisplayDefect : Form
    {
        public Action CloseEventDelegate;
        private Bitmap _displayImage = null;
        //private CtrlRuleImageDisplay _displayControl = null;
        public FormDisplayDefect()
        {
            InitializeComponent();
        }

        private void FormDisplayDefect_Load(object sender, EventArgs e)
        {
            //_displayControl = new CtrlRuleImageDisplay();
            //pnlDisplay.Controls.Add(_displayControl);
            //_displayControl.Dock = DockStyle.Fill;
        }

        private void FormDisplayDefect_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }

        public void UpdateDisplayImage(string filePath, int CamNo, Rectangle defectRoi)
        {
            string glassID = Path.GetFileName(filePath);
            string ngFilePath = Path.Combine(filePath, "..", "NG", glassID);
            string camFileName = "Cam_" + CamNo.ToString();

            Point defectCenterPoint = new Point(defectRoi.X + (defectRoi.Width / 2), defectRoi.Y + (defectRoi.Height / 2));

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(ngFilePath);

            if (di.Exists == false)
            {
                string message = string.Format("Path is not exist. Path : {0}", ngFilePath);
                MessageBox.Show(message);
                return;
            }

            foreach (System.IO.FileInfo file in di.GetFiles())
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FullName);

                if(fileName == camFileName)
                {
                    Bitmap mergeImage = new Bitmap(file.FullName);

                    int size = 500;

                    int newX = defectCenterPoint.X - (size / 2);
                    int newY = defectCenterPoint.Y - (size / 2);
                    int width = size;
                    int height = size;

                    if (newX < 0)
                        newX = 0;
                    if (newY < 0)
                        newY = 0;
                    if (newX + width > mergeImage.Width)
                        width = mergeImage.Width - newX;
                    if (newY + height > mergeImage.Height)
                        height =  mergeImage.Height - newY;

                    Rectangle newDefectRoi = new Rectangle(newX, newY, width, height);
                    if(pbxDisplay.Image != null)
                    {
                        pbxDisplay.Image.Dispose();
                        pbxDisplay.Image = null;
                    }
                    pbxDisplay.Image = mergeImage.Clone(newDefectRoi, mergeImage.PixelFormat);
                    this.Size = new Size(width, height);
                    mergeImage.Dispose();
                    break;
                }
            }
            this.Activate();
        }
    }
}
