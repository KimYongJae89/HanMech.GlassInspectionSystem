using HMechLogLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace HMechDBLib
{
    public partial class HMechDBLibaray
    {
        private string _dbConnectionString = string.Empty;
        private SqlConnection _sqlConnection = null;//커넥션 객체 생성(접속할 때 필요)
        private SqlCommand _sqlCommand = new SqlCommand();
        private SqlDataReader _sqlDataReader = null;//행의 앞으로만 이동 가능한 스트림을 읽음  

        public bool Initialize(string strConnection)
        {
            try
            { 
                this._dbConnectionString = strConnection;
                using (_sqlConnection = new SqlConnection(_dbConnectionString))
                {
                    _sqlConnection.Open();
                    return true;
                }
            }
            catch (Exception err)
            {
                Logger.WriteException(eLogType.ERROR, err);
                return false;
            }
        }
    }
}
