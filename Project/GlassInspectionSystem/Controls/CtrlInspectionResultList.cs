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
using HMechLogLib;

namespace GlassInspectionSystem.Controls
{
    public partial class CtrlInspectionResultList : UserControl
    {
        public CtrlInspectionResultList()
        {
            InitializeComponent();
        }

        private void InspectionResultListControl_Load(object sender, EventArgs e)
        {
            LoadResult();
        }

        private void LoadResult()
        {
            // 당일 모든 데이터 가져오기
        }
        private delegate void UpdateDele(InspResult inspResult);
        public void UpdateResult(InspResult inspResult)
        {
            try
            {
                if(this.InvokeRequired)
                {
                    UpdateDele callback = UpdateResult;
                    BeginInvoke(callback, inspResult);
                    return;
                }
                string no = gvInspectionResultList.Rows.Count.ToString();
                string glassID = inspResult.GlassID;
                string result = inspResult.InspResultType.ToString();
                string dateTime = Status.Instance().NowTime.ToString();

                string[] row = { no, glassID, result, dateTime };

                gvInspectionResultList.Rows.Add(row);
            }
            catch (Exception err)
            {
                Logger.WriteException(eLogType.ERROR, err);
            }
        }
    }
}
