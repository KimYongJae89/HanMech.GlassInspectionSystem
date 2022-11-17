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
using HMechDBLib;
using HMechLogLib;
using System.Reflection;

namespace GlassInspectionSystem.Controls
{
    public partial class CtrlDailyInformation : UserControl
    {
        private string _toDay = "";
        public CtrlDailyInformation()
        {
            InitializeComponent();
        }

        private void CtrlDailyInformation_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                _toDay = string.Format("{0:M/d/yyyy}", DateTime.Now);
                timerDayChange.Start();

                DailyTable dailyTable = DBManager.Instance().GetTodayResult();
                int dailyCount = dailyTable.OKCount + dailyTable.NGCount + dailyTable.WarningCount;
                int ngCount = dailyTable.NGCount;

                lblDailyCount.Text = dailyCount.ToString();
                lblDailyNgCount.Text = ngCount.ToString();
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private delegate void UpdateDailyCountDele();
        public void UpdateDailyCount()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateDailyCountDele callBack = UpdateDailyCount;
                    BeginInvoke(callBack);
                    return;
                }
                DailyTable dailyTable = DBManager.Instance().GetTodayResult();
                int dailyCount = Convert.ToInt32(lblDailyCount.Text) + 1;

                lblDailyCount.Text = (dailyTable.OKCount + dailyTable.NGCount + dailyTable.WarningCount).ToString();
                lblDailyNgCount.Text = dailyTable.NGCount.ToString();
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                Logger.WriteException(eLogType.ERROR, err);
            }
        }

        private void timerDayChange_Tick(object sender, EventArgs e)
        {
            try
            {
                string time = string.Format("{0:M/d/yyyy}", DateTime.Now);

                if(this._toDay != time)
                {
                    this._toDay = time;
                    DBManager.Instance().AddTodayDailyInformation();
                    // DB 삭제
                    DBManager.Instance().DeleteDB(DateTime.Now);

                    UpdateDailyCount();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }
    }
}
