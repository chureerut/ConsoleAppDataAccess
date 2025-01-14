using ClassLibrary.Common;
using ClassLibrary.Common.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ClassLibrary.DataAccess
{

    public class SqlBaseService
    {
        private LoggerUtils log = new LoggerUtils(MethodBase.GetCurrentMethod().DeclaringType);
        private LoggerUtils logSql = new LoggerUtils("SQL");

        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnStrSql"];
            }

        }
        private List<SqlParameter> baseParamList = new List<SqlParameter>();
        public SqlBaseService AddCriteria(string keyName, object value)
        {
            this.baseParamList.Add(new SqlParameter(keyName, value));
            return this;
        }
        protected List<SqlParameter> GetBaseParams
        {
            get { return baseParamList; }
        }

        protected void ClearCriteria()
        {
            this.baseParamList.Clear();
        }
        public SqlConnection CreateConnection()
        {
            var conn = new SqlConnection(this.ConnectionString);
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            return conn;
        }

        public SqlCommand CreateCommand(SqlTransaction trans)
        {
            var cmd = trans.Connection.CreateCommand();
            cmd.Transaction = trans;
            return cmd;
        }
        public DataTable Load(string sql, SqlCommand cmd)
        {
            try
            {
                cmd.CommandText = sql;
                DataSet ds = new DataSet();
                new SqlDataAdapter(cmd).Fill(ds);
                if (CommonUtils.HasRow(ds))
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
            finally
            {
            }
            return null;
        }

        public DataTable Load(string sql, List<SqlParameter> paramList, SqlTransaction trans)
        {
            try
            {
                using (SqlCommand cmd = this.CreateCommand(trans))
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(paramList.ToArray());

                    DataSet ds = new DataSet();
                    new SqlDataAdapter(cmd).Fill(ds);

                    if (CommonUtils.HasRow(ds))
                    {
                        return ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
            finally
            {
            }
            return null;
        }
        public List<T> MSSQLExecuteScalar<T>(string query)
        {
            object result = new object();
            return (result != null && result != DBNull.Value) ? (List<T>)Convert.ChangeType(result, typeof(T)) : default(List<T>);

        }
    }
}
