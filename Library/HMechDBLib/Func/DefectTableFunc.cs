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
        /// DefectTable에 등록
        /// </summary>
        /// <param name="defectTable">Defect Table</param>
        public void InsertDefectTable(DefectTable defectTable)
        {
            string queryMessage = QueryMessage.InsertDefectTable;
            SqlCommand com = new SqlCommand(queryMessage);

            using (_sqlConnection = new SqlConnection(_dbConnectionString))
            {
                _sqlConnection.Open();

                com.Connection = _sqlConnection;

                com.Parameters.AddWithValue("@PID", defectTable.Pid);
                com.Parameters.AddWithValue("@CamNo", defectTable.CamNo);
                com.Parameters.AddWithValue("@DftType", defectTable.DftType);
                com.Parameters.AddWithValue("@Updated", defectTable.Updated);
                com.Parameters.AddWithValue("@RealPosX", defectTable.RealPosX);
                com.Parameters.AddWithValue("@RealPosY", defectTable.RealPosY);
                com.Parameters.AddWithValue("@BoundingPosX", defectTable.BoundingPosX);
                com.Parameters.AddWithValue("@BoundingPosY", defectTable.BoundingPosY);
                com.Parameters.AddWithValue("@BoundingWidth", defectTable.BoundingWidth);
                com.Parameters.AddWithValue("@BoundingHeight", defectTable.BoundingHeight);
                com.Parameters.AddWithValue("@Score", defectTable.Score);
                com.Parameters.AddWithValue("@InspectionType", defectTable.InspectionType);
                com.Parameters.AddWithValue("@MergeTopOffset", defectTable.MergeTopOffset);

                com.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// DafectTable에서 All로 검색
        /// </summary>
        /// <param name="allDefect"></param>
        /// <returns></returns>
        public List<DefectTable> SearchingAllByDefectTable(string allDefect)
        {
            string queryMessage = QueryMessage.SearchingAllByDefectTable;
            SqlCommand com = new SqlCommand(queryMessage);

            com.Parameters.AddWithValue("@AllDefect", allDefect);

            return GetDefectTableList(com);
        }

        /// <summary>
        /// DafectTable에서 Type별 검색
        /// </summary>
        /// <param name="defectType">Defect Type</param>
        /// <returns></returns>
        public List<DefectTable> SearchingDefectTypeByDefectTable(string defectType, int id)
        {
            if (defectType == "All")
            {
                string queryMessage = QueryMessage.SearchingAllByDefectTable;
                SqlCommand com = new SqlCommand(queryMessage);
                com.Parameters.AddWithValue("@PID", id);
                return GetDefectTableList(com);
            }
            else
            {
                string queryMessage = QueryMessage.SearchingDefectTypeByDefectTable;
                SqlCommand com = new SqlCommand(queryMessage);
                com.Parameters.AddWithValue("@DefectType", defectType);
                com.Parameters.AddWithValue("@PID", id);
                return GetDefectTableList(com);
            }
        }

        public List<DefectTable> SearchingPIDByDefectTable(int id)
        {
            string queryMessage = QueryMessage.SearchingAllByDefectTable;
            SqlCommand com = new SqlCommand(queryMessage);
            com.Parameters.AddWithValue("@PID", id);
            return GetDefectTableList(com);
        }

        /// <summary>
        /// date 전날 DefectTable 모두 삭제
        /// </summary>
        /// <param name="date">date</param>
        /// <returns></returns>
        public void DeleteBeforeDateByDefectTable(DateTime date)
        {
            string queryMessage = QueryMessage.DeleteBeforeDateByDefectTable;
            SqlCommand com = new SqlCommand(queryMessage);

            using (_sqlConnection = new SqlConnection(_dbConnectionString))
            {
                _sqlConnection.Open();

                com.Connection = _sqlConnection;

                com.Parameters.AddWithValue("@Date", date);
                com.ExecuteNonQuery();
            }
        }

        private List<DefectTable> GetDefectTableList(SqlCommand sqlCommand)
        {
            DataTable dataTable = new DataTable();
            DefectTable defectTable = null;
            List<DefectTable> defectTableList = new List<DefectTable>();

            using (_sqlConnection = new SqlConnection(_dbConnectionString))
            {
                _sqlConnection.Open();

                sqlCommand.Connection = _sqlConnection;

                _sqlDataReader = sqlCommand.ExecuteReader();

                if (_sqlDataReader.HasRows)
                {
                    while (_sqlDataReader.Read())
                    {
                        defectTable = GetDefectTable((IDataRecord)_sqlDataReader);

                        defectTableList.Add(defectTable);
                    }
                }

                return defectTableList;
            }
        }

        private DefectTable GetDefectTable(IDataRecord record)
        {
            DefectTable defectTable = new DefectTable();

            defectTable.Pid = Convert.ToInt32(record[1].ToString());
            defectTable.CamNo = Convert.ToInt32(record[2].ToString());
            defectTable.DftType = record[3].ToString();
            defectTable.Updated = Convert.ToDateTime(record[4].ToString());
            defectTable.RealPosX = Convert.ToSingle(record[5].ToString());
            defectTable.RealPosY = Convert.ToSingle(record[6].ToString());
            defectTable.BoundingPosX = Convert.ToSingle(record[7].ToString());
            defectTable.BoundingPosY = Convert.ToSingle(record[8].ToString());
            defectTable.BoundingWidth = Convert.ToSingle(record[9].ToString());
            defectTable.BoundingHeight = Convert.ToSingle(record[10].ToString());
            defectTable.Score = Convert.ToSingle(record[11].ToString());
            defectTable.InspectionType = record[12].ToString();
            defectTable.MergeTopOffset = Convert.ToInt32(record[13].ToString());

            return defectTable;
        }

    }
}
