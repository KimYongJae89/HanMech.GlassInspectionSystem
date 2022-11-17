using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMechDBLib
{
    public partial class HMechDBLibaray
    {
        /// <summary>
        /// ResultTable에 등록
        /// </summary>
        /// <param name="resultTable">Result Table</param>
        public void InsertResultTable(ResultTable resultTable)
        {
            string queryMessage = QueryMessage.InsertResultTable;
            SqlCommand com = new SqlCommand(queryMessage);

            using (_sqlConnection = new SqlConnection(_dbConnectionString))
            {
                _sqlConnection.Open();

                com.Connection = _sqlConnection;

                com.Parameters.AddWithValue("@GlassID", resultTable.GlassID);
                com.Parameters.AddWithValue("@Result", resultTable.Result);
                com.Parameters.AddWithValue("@ImagePath", resultTable.ImagePath);
                com.Parameters.AddWithValue("@Updated", resultTable.Updated);
                com.Parameters.AddWithValue("@DftCount", resultTable.DftCount);
                com.Parameters.AddWithValue("@TotalCamCount", resultTable.TotalCamCount);
                com.Parameters.AddWithValue("@ThumbnailRatio", resultTable.ThumbnailRatio);
             
                com.ExecuteNonQuery();
            }
        }

        public List<ResultTable> SearchingAllByResultTable()
        {
            string queryMessage = QueryMessage.SearchingAllByResultTable;
            SqlCommand com = new SqlCommand(queryMessage);

            return GetResultTableList(com);
        }

        /// <summary>
        /// Glass ID로 ResultTable 검색 
        /// </summary>
        /// <param name="glassID">glass ID</param>
        /// <returns></returns>
        public List<ResultTable> SearchingGlassIDByResultTable(string glassID)
        {
            string queryMessage = QueryMessage.SearchingGlassIDByResultTable;
            SqlCommand com = new SqlCommand(queryMessage);

            com.Parameters.AddWithValue("@GlassID", glassID);

            return GetResultTableList(com);
        }

        /// <summary>
        /// 날짜로 ResultTable 검색
        /// </summary>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <returns></returns>
        public List<ResultTable> SearchingDateByResultTable(DateTime startDate, DateTime endDate)
        {
            string queryMessage = QueryMessage.SearchingDateByResultTable;
            SqlCommand com = new SqlCommand(queryMessage);

            com.Parameters.AddWithValue("@FromDate", startDate);
            com.Parameters.AddWithValue("@ToDate", endDate);

            return GetResultTableList(com);
        }

        public UInt32 GetCurrentPID()
        {
            UInt32 pid = 0;

            string queryMessage = QueryMessage.GetCurrentPID;
            SqlCommand com = new SqlCommand(queryMessage);

            using (_sqlConnection = new SqlConnection(_dbConnectionString))
            {
                _sqlConnection.Open();

                com.Connection = _sqlConnection;

                _sqlDataReader = com.ExecuteReader();

                if (_sqlDataReader.HasRows)
                {
                    if (_sqlDataReader.Read())
                    {
                        if (_sqlDataReader["PID"] != DBNull.Value)
                            pid = Convert.ToUInt32(_sqlDataReader["PID"]);
                    }
                }
            }

            return pid;
        }

        /// <summary>
        /// date 전날 ResultTable 모두 삭제
        /// </summary>
        /// <param name="date">date</param>
        /// <returns></returns>
        public void DeleteBeforeDateByResultTable(DateTime date)
        {
            string queryMessage = QueryMessage.DeleteBeforeDateByResultTable;
            SqlCommand com = new SqlCommand(queryMessage);

            using (_sqlConnection = new SqlConnection(_dbConnectionString))
            {
                _sqlConnection.Open();

                com.Connection = _sqlConnection;

                com.Parameters.AddWithValue("@Date", date);
                com.ExecuteNonQuery();
            }
        }

        private List<ResultTable> GetResultTableList(SqlCommand sqlCommand)
        {
            List<ResultTable> resultTableList = new List<ResultTable>();

            using (_sqlConnection = new SqlConnection(_dbConnectionString))
            {
                _sqlConnection.Open();

                sqlCommand.Connection = _sqlConnection;

                _sqlDataReader = sqlCommand.ExecuteReader();

                 if (_sqlDataReader.HasRows)
                {
                    while (_sqlDataReader.Read())
                    {
                        ResultTable resultTable = GetResultTable((IDataRecord)_sqlDataReader);

                        //_sqlDataReader를 다 읽을 때 까지 resultCollectionList에 resultCollection을 추가(ID, GlassID, Result, . . .)
                        resultTableList.Add(resultTable);
                    }
                }

                return resultTableList;
            }
        }

        private ResultTable GetResultTable(IDataRecord record)
        {
            ResultTable resultTable = new ResultTable();

            resultTable.Id = Convert.ToInt32(record[0].ToString());
            resultTable.GlassID = record[1].ToString();
            resultTable.Result = record[2].ToString();
            resultTable.ImagePath = record[3].ToString();
            resultTable.Updated = Convert.ToDateTime(record[4].ToString());
            resultTable.DftCount = Convert.ToInt32(record[5].ToString());
            resultTable.TotalCamCount = Convert.ToInt32(record[6].ToString());
            resultTable.ThumbnailRatio = Convert.ToInt32(record[7].ToString());

            return resultTable;
        }
    }
}
