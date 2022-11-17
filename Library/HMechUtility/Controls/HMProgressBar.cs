using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMechUtility.ProgressBarUtility;
using System.Runtime.InteropServices;
using System.Globalization;

namespace HMechUtility.Controls
{
    public partial class HMProgressBar : ProgressBar
    {
        #region Property
        private int _Fade = 150;
        public int Fade
        {
            get
            {
                return _Fade;
            }
            set
            {
                if (value < 0 || value > 255)
                {
                    object[] str = new object[] { value };
                    throw new ArgumentOutOfRangeException("value", string.Format(System.Globalization.CultureInfo.CurrentCulture, "A value of '{0}' is not valid for 'Fade'. 'Fade' must be between 0 and 255.", str));
                }

                _Fade = value;

                // Clean up previous brush
                if (_FadeBrush != null)
                {
                    _FadeBrush.Dispose();
                }

                _FadeBrush = new SolidBrush(Color.FromArgb(value, Color.White));

                Invalidate();
            }
        }
        
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        private SolidBrush _FadeBrush;
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }
        #endregion

        public HMProgressBar()
        {
            base.ForeColor = SystemColors.ControlText;
            _FadeBrush = new SolidBrush(Color.FromArgb(Fade, Color.White));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_FadeBrush != null)
                {
                    _FadeBrush.Dispose();
                    _FadeBrush = null;
                }
            }

            base.Dispose(disposing);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myParams = base.CreateParams;

                // Make the control use double buffering
                myParams.ExStyle |= NativeMethods.WS_EX_COMPOSITED;

                return myParams;
            }
        }

        protected override void WndProc(ref Message m)
        {
            int message = m.Msg;

            if (message == NativeMethods.WM_PAINT)
            {
                WmPaint(ref m);
                return;
            }

            if (message == NativeMethods.WM_PRINTCLIENT)
            {
                WmPrintClient(ref m);
                return;
            }

            base.WndProc(ref m);
        }

        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            builder.Append(GetType().FullName);
            builder.Append(", Minimum: ");
            builder.Append(Minimum.ToString(CultureInfo.CurrentCulture));
            builder.Append(", Maximum: ");
            builder.Append(Maximum.ToString(CultureInfo.CurrentCulture));
            builder.Append(", Value: ");
            builder.Append(Value.ToString(CultureInfo.CurrentCulture));

            return builder.ToString();
        }

        private void PaintPrivate(IntPtr device)
        {
            // Create a Graphics object for the device context
            using (Graphics graphics = Graphics.FromHdc(device))
            {
                Rectangle rect = ClientRectangle;

                if (_FadeBrush != null)
                {
                    // Paint a translucent white layer on top, to fade the colors a bit
                    graphics.FillRectangle(_FadeBrush, rect);
                }

                TextRenderer.DrawText(graphics, Text, Font, rect, ForeColor);
            }
        }

        private void WmPaint(ref Message m)
        {
            // Create a wrapper for the Handle
            HandleRef myHandle = new HandleRef(this, Handle);

            // Prepare the window for painting and retrieve a device context
            NativeMethods.PAINTSTRUCT pAINTSTRUCT = new NativeMethods.PAINTSTRUCT();
            IntPtr hDC = UnsafeNativeMethods.BeginPaint(myHandle, ref pAINTSTRUCT);

            try
            {
                // Apply hDC to message
                m.WParam = hDC;

                // Let Windows paint
                base.WndProc(ref m);

                // Custom painting
                PaintPrivate(hDC);
            }
            finally
            {
                // Release the device context that BeginPaint retrieved
                UnsafeNativeMethods.EndPaint(myHandle, ref pAINTSTRUCT);
            }
        }

        private void WmPrintClient(ref Message m)
        {
            // Retrieve the device context
            IntPtr hDC = m.WParam;

            // Let Windows paint
            base.WndProc(ref m);

            // Custom painting
            PaintPrivate(hDC);
        }
    }
}
