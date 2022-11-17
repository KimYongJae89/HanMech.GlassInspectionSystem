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

namespace GlassInspectionSystem.Controls
{
    public partial class CtrlGlassMap : UserControl
    {
        public CtrlGlassMap()
        {
            InitializeComponent();
        }

        private void lblDailyInformation_Paint(object sender, PaintEventArgs e)
        {
            //base.OnPaint(e);
            //int borderWidth = 1;
            //Color borderColor = Color.DarkGray;

            //ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor,
            // borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,
            // ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid);
        }

        private delegate void ThumbnailImageDele(Bitmap thumbnailImage);
        public void ThumbnailImageUpdate(Bitmap thumbnailImage)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    ThumbnailImageDele callBack = ThumbnailImageUpdate;
                    BeginInvoke(callBack, thumbnailImage);
                    return;
                }

                if (pbxMapImage.Image != null)
                {
                    Bitmap bmpOld = pbxMapImage.Image as Bitmap;
                    bmpOld.Dispose();
                    pbxMapImage.Image = null;
                }
                pbxMapImage.Image = (Bitmap)thumbnailImage.Clone();
            }
            catch (Exception err)
            {
                Logger.WriteException(eLogType.ERROR, err);
            }
        }

        public void SaveThumbnailImage(string path)
        {
            if (pbxMapImage.Image != null)
            {
                Bitmap bmp = pbxMapImage.Image as Bitmap;
                bmp.Save(path);
            }
        }
    }
}
