using System.Data;
using System.Text;

namespace ClassLibrary.Common
{
    public class CommonUtils
    {
        public static string ConvertPassword(string password)
        {
            string s = "";
            if (!string.IsNullOrEmpty(password))
            {
                byte[] ASCIIValues = Encoding.ASCII.GetBytes(password);
                foreach (byte b in ASCIIValues)
                {
                    int x = (int)b - 5;
                    char c = System.Convert.ToChar(x);
                    s = s + c;
                }
            }
            return s;
        }

        public static string SetParamWS(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return " ";
            }
            return value.TrimEnd();
        }

        public static bool IsNullOrEmpty(string value)
        {
            if (!string.IsNullOrEmpty(value) && value != "null")
            {
                return false;
            }
            return true;
        }

        public static string ObjToString(object value)
        {
            if (value != null) return value.ToString();
            else return "";
        }

        public static bool HasRow(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0) return true;
            else return false;
        }

        public static bool HasRow(DataSet ds, string tbName)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[tbName].Rows.Count > 0) return true;
            return false;
        }

        public static bool HasRow(DataSet ds, int index)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[index].Rows.Count > 0) return true;
            return false;
        }

        public static bool HasRow(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) return true;
            return false;
        }
    }
}
