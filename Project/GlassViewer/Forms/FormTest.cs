using HMechDBLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlassViewer.Forms
{
    public partial class FormTest : Form
    {
        public Action CloseEventDelegate;

        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {

        }

        private void btnInsertResult_Click(object sender, EventArgs e)
        {
            ResultTable resultTable = new ResultTable();
            resultTable.GlassID = "123";
            resultTable.Result = "OK";
            resultTable.ImagePath = @"4\1\TestGlassID";
            resultTable.Updated = DateTime.Now;
            resultTable.DftCount = 0;
            resultTable.TotalCamCount = 5;
            resultTable.ThumbnailRatio = 8;
            Status.Instance().DBHelper.InsertResultTable(resultTable);
        }

        private void btnInsertDefect_Click(object sender, EventArgs e)
        {
            DefectTable defectTable = new DefectTable();
            defectTable.Pid = 113;
            defectTable.CamNo = 1;
            defectTable.DftType = "Broken";
            defectTable.Updated = DateTime.Now;
            defectTable.RealPosX = 1354;
            defectTable.RealPosY = 532;
            defectTable.BoundingPosX = 513;
            defectTable.BoundingPosY = 53;
            defectTable.BoundingWidth = 100;
            defectTable.BoundingHeight = 100;
            defectTable.Score = 0;
            Status.Instance().DBHelper.InsertDefectTable(defectTable);
        }

        private void btnInsertDaily_Click(object sender, EventArgs e)
        {
            DailyTable dailyTable = new DailyTable();
            dailyTable.Updated = DateTime.Now;
            dailyTable.OKCount = 10;
            dailyTable.NGCount = 20;
            dailyTable.WarningCount = 30;
            Status.Instance().DBHelper.InsertDailyTable(dailyTable);
        }

        private void btnDeleteResult_Click(object sender, EventArgs e)
        {
            Status.Instance().DBHelper.DeleteBeforeDateByResultTable(DateTime.Now.AddDays(1));
        }

        private void btnDeleteDefect_Click(object sender, EventArgs e)
        {
            Status.Instance().DBHelper.DeleteBeforeDateByDefectTable(DateTime.Now.AddDays(1));
        }

        private void btnDeleteDaily_Click(object sender, EventArgs e)
        {
            Status.Instance().DBHelper.DeleteBeforeDateByDailyTable(DateTime.Now.AddDays(1));
        }

        private void btnSearchingResultByDate_Click(object sender, EventArgs e)
        {
            List<ResultTable> resultTableList = Status.Instance().DBHelper.SearchingDateByResultTable(DateTime.Now.AddDays(-10), DateTime.Now);

            FormMain.Instance().DataListControl.UpdateResultList(resultTableList);
        }

        private void btnSearchingResultByGlassID_Click(object sender, EventArgs e)
        {
            string glassID = "";

            List<ResultTable> resultTableList = Status.Instance().DBHelper.SearchingGlassIDByResultTable(glassID);

            FormMain.Instance().DataListControl.UpdateResultList(resultTableList);
        }

        private void btnSearchingDefect_Click(object sender, EventArgs e)
        {
            List<DefectTable> defectTableList = Status.Instance().DBHelper.SearchingAllByDefectTable("All");

            FormMain.Instance().DataListControl.UpdateDefectList(defectTableList);
        }

        private void btnSearchingDaily_Click(object sender, EventArgs e)
        {
            List<DailyTable> dailyTableList = new List<DailyTable>();

            dailyTableList = Status.Instance().DBHelper.SearchingDateByDailyTable(DateTime.Now.AddDays(-6), DateTime.Now);

            FormMain.Instance().DataListControl.UpdateDailyList(dailyTableList, gvDaily);
        }

        private void FormTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }
    }
}
