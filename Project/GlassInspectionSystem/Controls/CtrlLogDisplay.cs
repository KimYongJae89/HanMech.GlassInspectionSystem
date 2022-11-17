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
using GlassInspectionSystem.Class;
using System.Reflection;

namespace GlassInspectionSystem.Controls
{
    public partial class CtrlLogDisplay : UserControl
    {
        public CtrlLogDisplay()
        {
            InitializeComponent();
        }

        public void ClearLog()
        {
            lbxLogMessage.Items.Clear();
        }

        private delegate void AddLogDele(string message);

        public void AddLog(string message)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    AddLogDele callBack = AddLog;
                    BeginInvoke(callBack, message);
                    return;
                }
                if(lbxLogMessage.Items.Count >= 2000)
                    lbxLogMessage.Items.Clear();

                string content = "[ " + Logger.GetTimeString(Status.Instance().NowTime) + " ] ";
                content += message;

                lbxLogMessage.Items.Add(content);
                lbxLogMessage.SelectedIndex = lbxLogMessage.Items.Count - 1;
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void lbxLogMessage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int index = lbxLogMessage.SelectedIndex;
                if (index < 0)
                    return;
                string message = lbxLogMessage.SelectedItem as string;

                txtLogMessage.Text = message;
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }
    }
}