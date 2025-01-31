using System.Reflection;
using System.Text.RegularExpressions;

namespace ConsoleAppDataAccess.dataaccess
{
    public class qrysql
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static string Insert_Name()
        {
            string query = string.Format(@"", "");
            query = Regex.Replace(query, @"[^0-9A-Za-zก-๙ ()/.,\-:'_@]", "");
            return query;
        }

        public static string Query_Name()
        {
            string query = string.Format(@"select Invoicno,Insurename,Suminsure,Totalpremium from GSB_outstandingdebt");
            return query;
        }

    }
}
