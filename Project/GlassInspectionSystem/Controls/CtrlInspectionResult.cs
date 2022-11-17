using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlassInspectionSystem.Class;
using Device.PLC;
using HMechLogLib;

namespace GlassInspectionSystem.Controls
{
    public partial class CtrlInspectionResult : UserControl
    {
        public CtrlInspectionResult()
        {
            InitializeComponent();
        }

        private void lblInspectionResult_Paint(object sender, PaintEventArgs e)
        {
            //base.OnPaint(e);
            //int borderWidth = 1;
            //Color borderColor = Color.DarkGray;

            //ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor,
            // borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,
            // ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid);
        }

        private void lblInspectionResultText_Paint(object sender, PaintEventArgs e)
        {
            //base.OnPaint(e);
            //int borderWidth = 1;
            //Color borderColor = Color.DarkGray;

            //ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor,
            // borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,
            // ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid);
        }
        private delegate void UpdateResultDele(InspResult inspResult);
        public void UpdateResult(InspResult inspResult)
        {
            try
            {
                if(this.InvokeRequired)
                {
                    UpdateResultDele callback = UpdateResult;
                    BeginInvoke(callback, inspResult);
                    return;
                }

                lblGlassID.Text = inspResult.GlassID;
                lblTactTime.Text = inspResult.TactTime.ToString("F3");
                if(inspResult.InspResultType == eResultConstant.NG)
                {
                    lblInspectionResult.Text = "NG";
                    lblInspectionResult.BackColor = Color.Red;
                }
                else
                {
                    lblInspectionResult.Text = "OK";
                    lblInspectionResult.BackColor = Color.MediumSeaGreen;
                }
            }
            catch (Exception err)
            {
                Logger.WriteException(eLogType.ERROR, err);
            }
        }
    }
}
