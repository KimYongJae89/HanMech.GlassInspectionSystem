using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMechDBLib;
using System.IO;
using System.Drawing.Imaging;
using GlassInspectionSystem;

namespace GlassViewer.Controls
{
    enum eDefectSerachType
    {
        None,
        All,
        Broken,
        Crack,
        Chipping,
    }

    public partial class CtrlDataList : UserControl
    {
        private eDefectSerachType _defectSearchType = eDefectSerachType.None;
        private HMechDBLibaray _hmechDBLib = new HMechDBLibaray();
        private GlassViewer.Forms.FormGlassViewSettings _glassViewSettings = new Forms.FormGlassViewSettings();
        private string _path = string.Empty;
        private string _imagePath = string.Empty;
        private List<ResultTable> _resultList = new List<ResultTable>();
        private List<DefectTable> _defectList = new List<DefectTable>();
        //테스트
        private List<DailyTable> _dailyList = new List<DailyTable>();

        public CtrlDataList()
        {
            InitializeComponent();
        }

        public void UpdateResultList(List<ResultTable> resultCollectionList)
        {
            gvResult.Rows.Clear();
            _resultList.Clear();

            foreach (ResultTable item in resultCollectionList)
            {
                string[] row = { item.GlassID, item.Result, item.ImagePath, item.Updated.ToString() };//GridView에 추가할 Data만 배열에 집어넣음

                _resultList.Add(item);
                gvResult.Rows.Add(row);
            }
        }

        public void UpdateDefectList(List<DefectTable> defectCollectionList)
        {
            gvDefect.Rows.Clear();
            _defectList.Clear();

            foreach (DefectTable item in defectCollectionList)
            {
                string[] row = { item.CamNo.ToString(), item.DftType, item.Updated.ToString(), item.RealPosX.ToString(), item.RealPosY.ToString(), item.BoundingPosX.ToString(),
                    item.BoundingPosY.ToString(), item.BoundingWidth.ToString(), item.BoundingHeight.ToString(), item.Score.ToString("F3"), item.InspectionType.ToString() };

                _defectList.Add(item);
                gvDefect.Rows.Add(row);
            }
        }

        public void UpdateDailyList(List<DailyTable> dailyTableList, DataGridView gvDaily)
        {
            gvDaily.Rows.Clear();
            _dailyList.Clear();

            foreach (DailyTable item in dailyTableList)
            {
                string[] row = { item.Updated.ToString(), item.OKCount.ToString(), item.NGCount.ToString(), item.WarningCount.ToString() };

                _dailyList.Add(item);
                gvDaily.Rows.Add(row);
            }
        }

        public void UpdateResultGridView()
        {
            if(gvResult != null)
                Status.Instance().GetDataGridView = gvResult;//gridView에 결과값을 집어넣어 표시해줌
        }

        public void ClearResultSelection()
        {
            if(gvResult != null)
                gvResult.ClearSelection();
        }

        public void ClearDefectSelection()
        {
            if (gvDefect != null)
                gvDefect.ClearSelection();
        }

        public void ClearResultGridView()
        {
            if (gvResult != null)
            {
                gvResult.Rows.Clear();
                gvResult.Refresh();
            }
        }

        public void ClearDefectGridView()
        {
            if (gvDefect != null)
            {
                gvDefect.Rows.Clear();
                gvDefect.Refresh();
            }
        }

        private void gvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;

            if (selectedRowIndex < 0)
                return;

            int id = _resultList[selectedRowIndex].Id;

            CreateDefectTable(id);//체크박스 조건에 맞게 DefectGridView를 생성(All, Broken, Crack, Chipping . . . )

            //thumbnailImage를 띄우는 부분
            _imagePath = _resultList[selectedRowIndex].ImagePath;//해당 열의 ImagePath를 얻음
            Status.Instance().ImagePath = _imagePath;
            Status.Instance().ThumbnailImageRatio = Convert.ToDouble(_resultList[selectedRowIndex].ThumbnailRatio);
            Status.Instance().TotalCamCount = Convert.ToInt32(_resultList[selectedRowIndex].TotalCamCount);

            _path = FormMain.Instance().ThumbnailBoxControl.GetThumbnailImagePath(_path);//빈 string문자열을 집어넣어 ThumbnailPath를 얻음

            if (File.Exists(_path))//파일 존재여부
            {
                FormMain.Instance().ThumbnailBoxControl.IsNewOpenImage = true;
                FormMain.Instance().ThumbnailBoxControl.UpdateThumbnailImage(_path);
            }
            else
            {
                MessageBox.Show("Thumbnail image file does not exist.");
                FormMain.Instance().ThumbnailBoxControl.ClearImage();
                Status.Instance().TotalCamCount = 0;
                ClearDefectGridView();
            }
        }

        private void gvDefect_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;

            if (selectedRowIndex < 0)
                return;

            FormMain.Instance().ThumbnailBoxControl.ClearImage();
            //FormMain.Instance().ThumbnailBoxControl.UpdateThumbnailImage(FormMain.Instance().ThumbnailBoxControl.GetThumbnailImagePath(_path));//썸네일이미지 띄우기

            int defectViewSize = Convert.ToInt32(Settings.Instance().DefectViewSize);
            double thumbnailImageRatio = Status.Instance().ThumbnailImageRatio;
            double camNo = _defectList[selectedRowIndex].CamNo;
            string dftType = _defectList[selectedRowIndex].DftType;

            RectangleF defectRect = new RectangleF((float)_defectList[selectedRowIndex].BoundingPosX, (float)_defectList[selectedRowIndex].BoundingPosY,
                (float)_defectList[selectedRowIndex].BoundingWidth, (float)_defectList[selectedRowIndex].BoundingHeight);//defectList의 Bounding값을 가져와 Rectangle 생성

            _path = FormMain.Instance().ThumbnailBoxControl.GetCamNoImagePath(_path, camNo);//CamNo에 맞는 ImagePath를 얻음

            FormMain.Instance().ThumbnailBoxControl.UpdateDefectImage(_path, camNo, defectRect, defectViewSize, thumbnailImageRatio, dftType, _defectList[selectedRowIndex].MergeTopOffset);//DefectImage + ThumbnailImage 띄우기
        }

        public void CreateDefectTable(int id)
        {
            _defectSearchType = (eDefectSerachType)Enum.Parse(typeof(eDefectSerachType), Status.Instance().SearchDefectType.ToString(), true);//검색할 DefectType을 정함
            List<DefectTable> defectCollectionList = new List<DefectTable>();

            defectCollectionList = Status.Instance().DBHelper.SearchingDefectTypeByDefectTable(_defectSearchType.ToString(), id);

            UpdateDefectList(defectCollectionList);//업데이트 된 gvDefect를 띄움

            ClearDefectSelection();//gvDefect로딩 시 첫 열 선택 해제
        }
    }
}
