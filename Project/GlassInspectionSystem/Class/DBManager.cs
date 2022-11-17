using Device.Edge;
using HMechDBLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassInspectionSystem.Class
{
    public class DBManager
    {
        private HMechDBLibaray _db = new HMechDBLibaray();
        private string _connectedString = "Data Source = (local); Initial Catalog = GIS.AI; Integrated Security = SSPI;";
        //private string _connectedString = "Data Source = DESKTOP-4C9RIN0\\LOCALHOST; Initial Catalog = GIS.AI; Integrated Security = SSPI;";

        private static DBManager _instance = null;
        public static DBManager Instance()
        {
            if (_instance == null)
            {
                _instance = new DBManager();
            }

            return _instance;
        }

        public void Initialize()
        {
            bool ret = _db.Initialize(_connectedString);
            if (!ret)
            {
                System.Windows.Forms.MessageBox.Show("DB is not existed or connectstring is wrong.");
            }
        }

        public void AddResult(DateTime glassInTime, InspResult inspResult)
        {
            ResultTable result = new ResultTable();
            result.GlassID = inspResult.GlassID;
            result.Result = inspResult.InspResultType.ToString();
            result.ImagePath = inspResult.DBImagePath;
            result.Updated = glassInTime;
            result.DftCount = inspResult.FinallyDefectList.Count;
            result.TotalCamCount = Settings.Instance().Operation.CamCount;
            result.ThumbnailRatio = Settings.Instance().Operation.ThumbnailRatio;

            _db.InsertResultTable(result);
        }

        public int GetCurrentPid()
        {
            return Convert.ToInt32(_db.GetCurrentPID());
        }

        public void AddDefectInformation(DateTime glassInTime, InspResult inspResult,List<EdgeElement>[] edgeListArray)
        {
            // Result Table에 먼저 등록해줘야 올바른 Pid를 가져올 수 있음
            // DB 에 등록시 Pid 가져오기
            if (inspResult.FinallyDefectList.Count() == 0)
                return;

            int standardIndex = CornerHelper.GetMaxTopEdgeIndex(edgeListArray);

            int pid = GetCurrentPid();
            
            foreach (Defect defect in inspResult.FinallyDefectList)
            {
                DefectTable result = new DefectTable();
                result.Pid = pid;
                result.CamNo = defect.CamNo;
                //result.DftType = defect.DefectType.ToString();
                result.DftType = defect.DefectName;
                result.Updated = glassInTime;
                result.RealPosX = defect.RealPosX;
                result.RealPosY = defect.RealPosY;
                result.BoundingPosX = defect.BoundingPosX;
                result.BoundingPosY = defect.BoundingPosY;
                result.BoundingWidth = defect.BoundingWidth;
                result.BoundingHeight = defect.BoundingHeight;
                result.Score = defect.Confidence;
                result.InspectionType = defect.InspectionType.ToString();

                int topIndex = 0;
                EdgeElement topElement = CornerHelper.GetTopEdgeElement(edgeListArray[defect.CamNo], defect.CamNo);
                if(topElement == null)
                {
                    topIndex = 0;
                }
                else
                {
                    topIndex = (topElement.SubNo * topElement.OrgImageHeight) + topElement.Index;
                }

                result.MergeTopOffset = standardIndex - topIndex;

                _db.InsertDefectTable(result);
            }
        }

        public void AddTodayDailyInformation()
        {
            //24시 지나는 순간 00:00:00  이전 날짜로 저장해야한다.
            DailyTable dailyTable = new DailyTable();
            dailyTable.Updated = DateTime.Now.AddDays(-1);
            dailyTable.OKCount = Status.Instance().OKCount;
            dailyTable.NGCount = Status.Instance().NGCount;
            dailyTable.WarningCount = Status.Instance().WarningCount;

            _db.InsertDailyInformation(dailyTable);
        }

        public DailyTable GetTodayResult()
        {
            DailyTable dailyTable = _db.SearchingDateCountByResultTable(DateTime.Now);
            Status.Instance().OKCount = dailyTable.OKCount;
            Status.Instance().NGCount = dailyTable.NGCount;
            Status.Instance().WarningCount = dailyTable.WarningCount;

            return dailyTable;
        }

        public void DeleteDB(DateTime glassInTime)
        {
            DateTime deleteStandard = glassInTime.AddMonths(-6);
            _db.DeleteBeforeDateByResultTable(deleteStandard);
            _db.DeleteBeforeDateByDefectTable(deleteStandard);
            _db.DeleteBeforeDateByDailyTable(deleteStandard);
        }
    }
}