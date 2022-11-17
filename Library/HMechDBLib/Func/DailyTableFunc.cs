using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMechDBLib
{
    public enum eResultConstant
    {
        None,
        OK,
        NG,
        Warning,
    }

    public partial class HMechDBLibaray
    {
        private eResultConstant _resultType = eResultConstant.None;

        /// <summary>
        /// DailyTable에 등록
        /// </summary>
        /// <param name="dailyTable">daily Table</param>
        /// <returns></returns>
        public bool InsertDailyTable(DailyTable dailyTable)
        {
            try
            {
                string queryMessage = QueryMessage.InsertDailyTable;
                SqlCommand com = new SqlCommand(queryMessage);

                using (_sqlConnection = new SqlConnection(_dbConnectionString))
                {
                    _sqlConnection.Open();

                    com.Connection = _sqlConnection;

                    com.Parameters.AddWithValue("@Updated", dailyTable.Updated);
                    com.Parameters.AddWithValue("@OKCount", dailyTable.OKCount);
                    com.Parameters.AddWithValue("@NGCount", dailyTable.NGCount);
                    com.Parameters.AddWithValue("@WarningCount", dailyTable.WarningCount);
                    com.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception err)
            {
                throw new System.ArgumentException(err.Message);
            }
        }

        /// <summary>
        /// 날짜로 DailyTable 검색
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<DailyTable> SearchingDateByDailyTable(DateTime startTime, DateTime endTime)
        {
            //startTime 00.00.00 end Time 23.59.59
            string start = startTime.Year + "-" + startTime.Month + "-" + startTime.Day + " 00:00:00";
            string end = endTime.Year + "-" + endTime.Month + "-" + endTime.Day + " 23:59:59";
            startTime = Convert.ToDateTime(start);
            endTime = Convert.ToDateTime(end);
            List<DailyTable> dailyTableList = new List<DailyTable>();

            string queryMessage = QueryMessage.SearchingDateByDailyTable;
            SqlCommand com = new SqlCommand(queryMessage);

            com.Parameters.AddWithValue("@StartTime", startTime);
            com.Parameters.AddWithValue("@EndTime", endTime);

            dailyTableList = GetDailyTableList(com, startTime);

            //차례대로 DailyTableList 생성(DailyTable에 없는 날짜는 0으로 처리)
            List<DailyTable> retDailyTableList = new List<DailyTable>();
            TimeSpan timeSpan = (endTime - startTime);

            for (int i = 0; i < timeSpan.Days; i++)
            {
                DateTime nowTime = startTime.AddDays(i);
                DailyTable searchDaily = SearchDailyData(dailyTableList, nowTime);

                if (searchDaily == null)
                {
                    DailyTable table = new DailyTable();
                    DailyTable searchResult = SearchingDateCountByResultTable(nowTime);

                    //DailyTable에 없는 날짜의 데이터가 ResultTable에 있는지 확인
                    if(searchResult.OKCount != 0 || searchResult.NGCount != 0 || searchResult.WarningCount != 0)
                    {
                        table.Updated = nowTime;
                        table.OKCount = searchResult.OKCount;
                        table.NGCount = searchResult.NGCount;
                        table.WarningCount = searchResult.WarningCount;
                    }
                    else
                    {
                        table.Updated = nowTime;
                        table.OKCount = 0;
                        table.NGCount = 0;
                        table.WarningCount = 0;
                    }

                    retDailyTableList.Add(table);
                }
                else
                {
                    retDailyTableList.Add(searchDaily);
                }
            }

            return retDailyTableList;
        }

        private DailyTable SearchDailyData(List<DailyTable> dailyTableList, DateTime searchDate)
        {
            DailyTable ret = null;

            foreach (DailyTable table in dailyTableList)
            {
                if(table.Updated == searchDate)
                {
                    ret = table.TableCopy();
                }
            }
            return ret;
        }

        /// <summary>
        /// time 날짜의 OK, NG, Warning 갯수 가져오기
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public DailyTable SearchingDateCountByResultTable(DateTime time)
        {
            string queryMessage = QueryMessage.SearchingDateCountByResultTable;
            SqlCommand com = new SqlCommand(queryMessage);

            //  time이란 날짜에 select * dbo.tblResult 에서 ok, ng, warning 갯수 가져오기
            string start = time.Year + "-" + time.Month + "-" + time.Day + " 00:00:00";
            string end = time.Year + "-" + time.Month + "-" + time.Day + " 23:59:59";
            DateTime startTime = Convert.ToDateTime(start);
            DateTime endTime = Convert.ToDateTime(end);
            DailyTable dailyCollection = new DailyTable();

            List<ResultTable> searchList = SearchingDateByResultTable(startTime, endTime);

            int okCount = 0;
            int ngCount = 0;
            int warningCount = 0;

            foreach (ResultTable result in searchList)
            {
                _resultType = (eResultConstant)Enum.Parse(typeof(eResultConstant), result.Result.ToString(), true);

                switch(_resultType)
                {
                    case eResultConstant.OK:
                        okCount++;
                        break;
                    case eResultConstant.NG:
                        ngCount++;
                        break;
                    case eResultConstant.Warning:
                        warningCount++;
                        break;
                    default:
                        break;
                }
            }

            dailyCollection.Updated = time;
            dailyCollection.OKCount = okCount;
            dailyCollection.NGCount = ngCount;
            dailyCollection.WarningCount = warningCount;

            return dailyCollection;
        }

        /// <summary>
        /// time 날짜의 OK, NG, Warning 개수를 DailyTable에 등록
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public void InsertDailyInformation(DailyTable dailyTable)
        { 
            string queryMessage = QueryMessage.InsertDailyInformation;
            SqlCommand com = new SqlCommand(queryMessage);

            using (_sqlConnection = new SqlConnection(_dbConnectionString))
            {
                _sqlConnection.Open();

                com.Connection = _sqlConnection;

                com.Parameters.AddWithValue("@Time", dailyTable.Updated);
                com.Parameters.AddWithValue("@OKCount", dailyTable.OKCount);
                com.Parameters.AddWithValue("@NGCount", dailyTable.NGCount);
                com.Parameters.AddWithValue("@WarningCount", dailyTable.WarningCount);
              
                com.ExecuteNonQuery();
            }
          
        }

        private List<DailyTable> GetDailyTableList(SqlCommand sqlCommand, DateTime startTime)
        {
            DateTime time = startTime;
            DailyTable dailyTable = null;
            List<DailyTable> dailyTableList = new List<DailyTable>();

            using (_sqlConnection = new SqlConnection(_dbConnectionString))
            {
                _sqlConnection.Open();

                sqlCommand.Connection = _sqlConnection;

                _sqlDataReader = sqlCommand.ExecuteReader();

                if (_sqlDataReader.HasRows)
                {
                    while (_sqlDataReader.Read())
                    {
                        dailyTable = GetDailyTable((IDataRecord)_sqlDataReader);

                        dailyTableList.Add(dailyTable);
                        time = time.AddDays(1);
                    }
                }

                return dailyTableList;
            }
        }

        /// <summary>
        /// date 전날 DailyTable 모두 삭제
        /// </summary>
        /// <param name="date">date</param>
        /// <returns></returns>
        public void DeleteBeforeDateByDailyTable(DateTime date)
        {
            string queryMessage = QueryMessage.DeleteBeforeDateByDailyTable;
            SqlCommand com = new SqlCommand(queryMessage);

            using (_sqlConnection = new SqlConnection(_dbConnectionString))
            {
                _sqlConnection.Open();

                com.Connection = _sqlConnection;

                com.Parameters.AddWithValue("@Date", date);
                com.ExecuteNonQuery();
            }
        }

        private DailyTable GetDailyTable(IDataRecord record)
        {
            DailyTable dailyCollection = new DailyTable();

            dailyCollection.Updated = Convert.ToDateTime(record[1].ToString());
            dailyCollection.OKCount = Convert.ToInt32(record[2].ToString());
            dailyCollection.NGCount = Convert.ToInt32(record[3].ToString());
            dailyCollection.WarningCount = Convert.ToInt32(record[4].ToString());

            return dailyCollection;
        }
    }
}
