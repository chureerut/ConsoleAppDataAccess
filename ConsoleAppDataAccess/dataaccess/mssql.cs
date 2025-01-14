using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ConsoleAppDataAccess.dataaccess
{
    public class mssql
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string connSql = ConfigurationManager.AppSettings.Get("connSql");

        public static DataTable MSSQLExecuteReader(string query)
        {
            query = Regex.Replace(query, @"\s+", " ");
            log.Debug(query);
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connSql))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                            {
                                cmd.CommandTimeout = 5000;

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        dataTable.Load(reader);
                                    }
                                }
                            }
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            log.Error($"Transaction Error: {ex.Message}");

                            // Attempt to rollback the transaction
                            try
                            {
                                trans.Rollback();
                                log.Info("Transaction rolled back.");
                            }
                            catch (Exception rollbackEx)
                            {
                                log.Error($"Rollback Error: {rollbackEx.Message}");
                            }

                            throw;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                log.Error($"SQL Error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                return null;
            }
            return dataTable;
        }
        public static T MSSQLExecuteScalar<T>(string query)
        {
            query = Regex.Replace(query, @"\s+", " ");
            log.Debug(query);
            try
            {
                using (SqlConnection conn = new SqlConnection(connSql))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadUncommitted))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                        {
                            cmd.CommandTimeout = 5000;
                            try
                            {
                                object result = cmd.ExecuteScalar();
                                trans.Commit();
                                return (result != null && result != DBNull.Value) ? (T)Convert.ChangeType(result, typeof(T)) : default(T);
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                log.Error($"Transaction Error: {ex.Message}");
                                throw;
                            }
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                log.Error($"SQL Error: {ex.Message}");
                return default(T);
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                return default(T);
            }

        }
        public static bool MSSQLExecuteNonQuery(string query)
        {
            query = Regex.Replace(query, @"\s+", " ");
            log.Debug(query);

            try
            {
                using (SqlConnection conn = new SqlConnection(connSql))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                            {
                                cmd.CommandTimeout = 5000;
                                cmd.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            trans.Commit();
                            log.Info("Transaction committed successfully.");
                            return true; //success
                        }
                        catch (Exception ex)
                        {
                            log.Error($"Transaction Error: {ex.Message}");

                            // Attempt to rollback the transaction
                            try
                            {
                                trans.Rollback();
                                log.Info("Transaction rolled back.");
                            }
                            catch (Exception rollbackEx)
                            {
                                log.Error($"Rollback Error: {rollbackEx.Message}");
                            }

                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                return false;
            }
        }
        public static bool MSSQLExecuteNonQueryInsert()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connSql))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                        try
                        {
                            string insertSql = "INSERT INTO GSB_outstandingdebt (Policydate, Startdate, Expiredate) VALUES (@Policydate, @Startdate, @Expiredate)";
                            SqlCommand cmd = new SqlCommand(insertSql, conn, trans);
                            cmd.Parameters.AddWithValue("@Policydate", "22/04/2020");
                            cmd.Parameters.AddWithValue("@Startdate", "22/04/2020");
                            cmd.Parameters.AddWithValue("@Expiredate", "22/04/2020");
                            cmd.CommandTimeout = 5000;
                            cmd.ExecuteNonQuery();

                            // Commit the transaction
                            trans.Commit();
                            log.Info("Transaction committed successfully.");
                            return true; //success
                        }
                        catch (Exception ex)
                        {
                            log.Error($"Transaction Error: {ex.Message}");

                            // Attempt to rollback the transaction
                            try
                            {
                                trans.Rollback();
                                log.Info("Transaction rolled back.");
                            }
                            catch (Exception rollbackEx)
                            {
                                log.Error($"Rollback Error: {rollbackEx.Message}");
                            }

                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                return false;
            }
        }
        public static bool MSSQLExecuteNonQueryUpdate()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connSql))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                        try
                        {
                            string updateSql = "UPDATE GSB_outstandingdebt SET Policydate = @Policydate WHERE Policyno = @Policyno";
                            SqlCommand cmd = new SqlCommand(updateSql, conn, trans);
                            cmd.Parameters.AddWithValue("@Policydate", "24/04/2020");
                            cmd.Parameters.AddWithValue("@Policyno", "12001-003-200024860");
                            cmd.CommandTimeout = 5000;
                            cmd.ExecuteNonQuery();

                            // Commit the transaction
                            trans.Commit();
                            log.Info("Transaction committed successfully.");
                            return true; //success
                        }
                        catch (Exception ex)
                        {
                            log.Error($"Transaction Error: {ex.Message}");

                            // Attempt to rollback the transaction
                            try
                            {
                                trans.Rollback();
                                log.Info("Transaction rolled back.");
                            }
                            catch (Exception rollbackEx)
                            {
                                log.Error($"Rollback Error: {rollbackEx.Message}");
                            }

                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                return false;
            }
        }

    }


}
