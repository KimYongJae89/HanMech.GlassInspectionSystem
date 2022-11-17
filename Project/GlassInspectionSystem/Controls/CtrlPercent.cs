using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlassInspectionSystem.Controls
{
    public partial class CtrlPercent : UserControl
    {
        public CtrlPercent()
        {
            InitializeComponent();
        }

        private string _headerText = "";
        public string HeaderText
        {
            get { return _headerText; }
            set
            {
                _headerText = value;
                //lbl.text = _headerText;
            }
        }

        private int _percent = 0;
        public int Percent
        {
            get { return _percent; }
            set
            {
                if (_percent == value)
                    return;
                _percent = value;
                //Control.set = _percent;
            }
        }

        private Font _stringStyle;
        public Font StringStyle
        {
            get { return _stringStyle; }
            set {
                    _stringStyle = value;
            }
        }


        public void SetFade()
        {

        }

        public void GetFade()
        {

        }
    }
}
