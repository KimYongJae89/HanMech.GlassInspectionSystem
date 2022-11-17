﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlassViewer.Controls
{
    public class DoubleBufferPanel : Panel
    {
         public DoubleBufferPanel()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.SetStyle(ControlStyles.UserPaint, true);

            this.UpdateStyles();
        }
    }
}
