using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IBM.Data.Informix;

namespace ConsoleAppDataAccess.dataaccess
{    
    public class informix
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string connIfx = ConfigurationManager.AppSettings.Get("connIfx");
        public static DataTable InformixExecuteReader(string query)
        {
            query = Regex.Replace(query, @"\s+", " ");
            log.Debug(query);
            try
            {
                using (IfxConnection conn = new IfxConnection(connIfx))
                {
                    conn.Open();
                    using (IfxTransaction trans = conn.BeginTransaction(IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            using (IfxCommand cmd = new IfxCommand(query, conn, trans))
                            {
                                cmd.CommandTimeout = 5000;

                                using (IfxDataReader dr = cmd.ExecuteReader())
                                {
                                    DataTable dt = new DataTable();
                                    dt.Load(dr); // Load data from DataReader into DataTable directly
                                    log.Debug($"Found {dt.Rows.Count} records.");

                                    trans.Commit();
                                    return dt;
                                }
                            }
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
            catch (IfxException ex)
            {
                log.Error($"Informix Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                throw;
            }
        }
        public static T InformixExecuteScalar<T>(string query)
        {
            query = Regex.Replace(query, @"\s+", " ");
            log.Debug(query);
            try
            {
                using (IfxConnection conn = new IfxConnection(connIfx))
                {
                    conn.Open();
                    using (IfxTransaction trans = conn.BeginTransaction(IsolationLevel.ReadUncommitted))
                    {
                        using (IfxCommand cmd = new IfxCommand(query, conn, trans))
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
            catch (IfxException ex)
            {
                log.Error($"Informix Error: {ex.Message}");
                return default(T);
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                return default(T);
            }
        }
        public static bool InformixExecuteNonQuery(string query)
        {
            query = Regex.Replace(query, @"\s+", " ");
            log.Debug(query);

            try
            {
                using (IfxConnection conn = new IfxConnection(connIfx))
                {
                    conn.Open();
                    using (IfxTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                        try
                        {
                            using (IfxCommand cmd = new IfxCommand(query, conn, trans))
                            {
                                cmd.CommandTimeout = 5000;
                                cmd.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            trans.Commit();
                            log.Info("Transaction committed successfully.");
                            return true; // Return success
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
            catch (IfxException ex)
            {
                log.Error($"Informix Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                return false;
            }
        }

    }
}
