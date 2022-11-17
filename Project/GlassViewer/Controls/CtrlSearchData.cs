using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using HMechDBLib;

namespace GlassViewer.Controls
{
    enum eTabStatus
    {
        None,
        ByDate,
        ByGlassID,
    }

    public partial class CtrlSearchData : UserControl
    {
        private eDefectSerachType _defectSearchType = eDefectSerachType.None;
        private eTabStatus _tabStatus = eTabStatus.None;
        private DataGridView _dataGridView = new DataGridView();
        private GlassViewer.Forms.FormTest _formTest = new Forms.FormTest();
        private bool _isDrawRatioRect = false;

        public CtrlSearchData()
        {
            InitializeComponent();
        }

        public void SettingStartDate()
        {
            dtpkrFromDate.Text = DateTime.Parse(dtpkrToDate.Text).AddMonths(-1).ToString();
        }

        private void CtrlSearchData_Load(object sender, EventArgs e)
        {
            _tabStatus = eTabStatus.ByDate;
            Status.Instance().SearchDefectType = eDefectSerachType.All.ToString();//처음 Defect검색을 모든 타입으로 지정(Broken, Crack, Chipping . . . ) 
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FormMain.Instance().ThumbnailBoxControl.ClearImage();//이미지 초기화
            FormMain.Instance().DataListControl.ClearDefectGridView();//gvDefect 초기화
            Status.Instance().TotalCamCount = 0;

            switch (_tabStatus)
            {
                case eTabStatus.ByDate:
                    SearchingDate();
                    FormMain.Instance().DataListControl.ClearResultSelection();//gvResult로딩 시 첫 열 선택 해제
                    break;
                case eTabStatus.ByGlassID:
                    SearchingGlassID();
                    FormMain.Instance().DataListControl.ClearResultSelection();
                    break;
                default:
                    break;
            }
            
            FormMain.Instance().SearchResultRatioControl.UpdateData(_isDrawRatioRect);
        }

        private void SearchingDate()
        {
            try
            {
                List<ResultTable> resultCollectionList = new List<ResultTable>();
                DateTime startDate = dtpkrFromDate.Value.Date;
                DateTime endDate = dtpkrToDate.Value.Date;

                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 00, 00, 00);//년,월,일,시,분,초 까지만 표시
                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);//년,월,일,시,분,초 까지만 표시
                TimeSpan timeSpan = endDate - startDate;

                if (timeSpan.Days < 0 || timeSpan.Days == 0 && startDate > endDate)
                {
                    MessageBox.Show("Set start date less than end date.");
                    FormMain.Instance().DataListControl.ClearResultGridView();
                    _isDrawRatioRect = false;

                    return;
                }
                else
                {
                    // Date 기준으로 TableList 생성
                    resultCollectionList.AddRange(Status.Instance().DBHelper.SearchingDateByResultTable(startDate, endDate));

                    // CheckBox 에 맞게 필터링
                    List<ResultTable> defectTableList = CheckDefectType(resultCollectionList, Status.Instance().SearchDefectType.ToString());

                    FormMain.Instance().DataListControl.UpdateResultList(defectTableList);//gvResult에 DB의 Data를 집어넣음

                    _isDrawRatioRect = true;
                }

                FormMain.Instance().DataListControl.UpdateResultGridView();//업데이트 된 gvResult를 띄움
                _dataGridView = Status.Instance().GetDataGridView;//업데이트 된 DataGridView를 빈 dataGridView에 넣음

                FormMain.Instance().SearchResultRatioControl.ResultConstantCount(_dataGridView);//OK, NG, WARNING Count를 셈
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private List<ResultTable> CheckDefectType(List<ResultTable> resultList, string defectType)
        {
            List<ResultTable> resultTableList = new List<ResultTable>();
            List<DefectTable> defectTableList = new List<DefectTable>();

            if (defectType == eDefectSerachType.All.ToString())
                return resultList;
            
            foreach (ResultTable table in resultList)
            {
                if (table.Result != eResultConstant.OK.ToString())
                {
                    List<DefectTable> defectList = new List<DefectTable>();
                    // 해당하는 defectType만 가져옴
                    defectList.AddRange(Status.Instance().DBHelper.SearchingDefectTypeByDefectTable(defectType, table.Id));

                    if (defectList.Count > 0)
                    {
                        resultTableList.Add(table.TableCopy());
                    }
                }
            }

            return resultTableList;
        }

        private void SearchingGlassID()
        {
            try
            {
                List<ResultTable> resultCollectionList = new List<ResultTable>();
                string glassId = txtSearch.Text;

                if (txtSearch.Text == "")
                    resultCollectionList = Status.Instance().DBHelper.SearchingAllByResultTable();
                else
                    resultCollectionList = Status.Instance().DBHelper.SearchingGlassIDByResultTable(glassId);

                FormMain.Instance().DataListControl.UpdateResultList(resultCollectionList);

                FormMain.Instance().DataListControl.UpdateResultGridView();
                _dataGridView = Status.Instance().GetDataGridView;

                FormMain.Instance().SearchResultRatioControl.ResultConstantCount(_dataGridView);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void tabSearching_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tabName = tabSearching.TabPages[tabSearching.SelectedIndex].Text;//해당 TabPage의 이름을 tabName에 저장

            switch(tabName)
            {
                case "By Date":
                    _tabStatus = eTabStatus.ByDate;
                    break;
                case "By GlassID":
                    _tabStatus = eTabStatus.ByGlassID;
                    break;
                default:
                    _tabStatus = eTabStatus.None;
                    break;
            }
        }

        private void ckbAll_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbAll.Checked)
            {
                Status.Instance().SearchDefectType = eDefectSerachType.All.ToString();
                CheckBoxUnabled();
            }
            else
            {
                CheckBoxEnabled();
                Status.Instance().SearchDefectType = eDefectSerachType.None.ToString();
            }
        }

        private void ckbBroken_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbBroken.Checked)
            {
                Status.Instance().SearchDefectType = eDefectSerachType.Broken.ToString();
                CheckBoxUnabled();
            }
            else
            {
                CheckBoxEnabled();
                Status.Instance().SearchDefectType = eDefectSerachType.None.ToString();
            }
        }

        private void ckbCrack_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCrack.Checked)
            {
                Status.Instance().SearchDefectType = eDefectSerachType.Crack.ToString();
                CheckBoxUnabled();
            }
            else
            {
                CheckBoxEnabled();
                Status.Instance().SearchDefectType = eDefectSerachType.None.ToString();
            }
        }

        private void ckbChipping_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbChipping.Checked)
            {
                Status.Instance().SearchDefectType = eDefectSerachType.Chipping.ToString();
                CheckBoxUnabled();
            }
            else
            {
                CheckBoxEnabled();
                Status.Instance().SearchDefectType = eDefectSerachType.None.ToString();
            }
        }

        private void CheckBoxEnabled()
        {           
            ckbAll.Enabled = true;
            ckbBroken.Enabled = true;
            ckbCrack.Enabled = true;
            ckbChipping.Enabled = true;
        }

        private void CheckBoxUnabled()
        {
            _defectSearchType = (eDefectSerachType)Enum.Parse(typeof(eDefectSerachType), Status.Instance().SearchDefectType.ToString(), true);//검색할 DefectType을 정함

            switch (_defectSearchType)
            {
                case eDefectSerachType.All:
                    ckbBroken.Enabled = false;
                    ckbChipping.Enabled = false;
                    ckbCrack.Enabled = false;
                    break;
                case eDefectSerachType.Broken:
                    ckbAll.Enabled = false;
                    ckbCrack.Enabled = false;
                    ckbChipping.Enabled = false;
                    break;
                case eDefectSerachType.Crack:
                    ckbAll.Enabled = false;
                    ckbBroken.Enabled = false;
                    ckbChipping.Enabled = false;
                    break;
                case eDefectSerachType.Chipping:
                    ckbAll.Enabled = false;
                    ckbBroken.Enabled = false;
                    ckbCrack.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Status.Instance().Forms.OpenFormFormTest();
        }
    }
}
