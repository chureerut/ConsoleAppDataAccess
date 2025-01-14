using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace ConsoleAppDataAccess.commonlibrary
{
    public class CommonUtils
    {
        // Set the current culture to "en-US"
        public static void SetCurrentCultureToEnUS()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }

        // Convert string to int
        public static int? ConvertStringToInt(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return null;
        }

        // Convert string to double
        public static double? ConvertStringToDouble(string value)
        {
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            return null;
        }

        // Convert string to DateTime
        public static DateTime? ConvertStringToDateTime(string value, string format = "MM/dd/yyyy", CultureInfo culture = null)
        {
            if (culture == null)
            {
                culture = CultureInfo.InvariantCulture;
            }

            if (DateTime.TryParseExact(value, format, culture, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            return null;
        }

        // Convert string to bool
        public static bool? ConvertStringToBool(string value)
        {
            if (bool.TryParse(value, out bool result))
            {
                return result;
            }
            return null;
        }

        // Convert int to string
        public static string ConvertIntToString(int value)
        {
            return value.ToString();
        }

        // Convert double to string
        public static string ConvertDoubleToString(double value)
        {
            return value.ToString();
        }

        // Convert DateTime to string
        public static string ConvertDateTimeToString(DateTime value, string format = "MM/dd/yyyy", CultureInfo culture = null)
        {
            //culture ??= CultureInfo.InvariantCulture;
            //return value.ToString(format, culture);
            if (culture == null)
            {
                culture = CultureInfo.InvariantCulture;
            }
            return value.ToString(format, culture);
        }

        // Convert bool to string
        public static string ConvertBoolToString(bool value)
        {
            return value.ToString();
        }

        // Convert object to string (with a fallback for null values)
        public static string ConvertObjectToString(object value, string nullValue = "N/A")
        {
            return value?.ToString() ?? nullValue;
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

        public static bool HasTable(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0) return true;
            return false;
        }

        public static bool HasTable(DataSet ds, string tbName)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[tbName] != null) return true;
            return false;
        }

        public static bool HasTable(DataSet ds, int index)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[index] != null) return true;
            return false;
        }

        // Check if DataTable is null or empty
        public static bool IsDataTableNullOrEmpty(DataTable table)
        {
            return table == null || table.Rows.Count == 0;
        }

        // Check if DataRow is null or contains only null values
        public static bool IsDataRowNullOrEmpty(DataRow row)
        {
            if (row == null)
            {
                return true;
            }

            foreach (var item in row.ItemArray)
            {
                if (item != DBNull.Value && item != null)
                {
                    return false;
                }
            }
            return true;
        }


        // Convert DataTable to List of dictionaries
        public static List<Dictionary<string, object>> ConvertDataTableToList(DataTable table)
        {
            var result = new List<Dictionary<string, object>>();

            if (IsDataTableNullOrEmpty(table))
            {
                return result;
            }

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn column in table.Columns)
                {
                    dict[column.ColumnName] = row[column];
                }
                result.Add(dict);
            }

            return result;
        }

        private static string ConvertToThaiDate(string dateString)
        {
            // แปลงสตริงให้เป็น DateTime
            DateTime dateValue = DateTime.ParseExact(dateString, "dd/M/yyyy", new CultureInfo("en-GB"));

            // เดือนในภาษาไทย
            string[] thaiMonths = { "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม" };

            int day = dateValue.Day;
            int month = dateValue.Month;
            int year = dateValue.Year + 543;

            string formateDay = day + " " + thaiMonths[month - 1] + " " + year;
            return formateDay;
        }

        public static string JoinString(IEnumerable<string> list)
        {
            return string.Join(",", from s in list
                                    where !string.IsNullOrEmpty(s)
                                    select string.Format("'{0}'", s));
        }

        public static string JoinInt(IEnumerable<int> list)
        {
            return string.Join(",", from s in list
                                    select string.Format("{0}", s));
        }

        // Check if a list is null or empty
        public static bool IsListNullOrEmpty<T>(List<T> list)
        {
            return list == null || list.Count == 0;
        }

        // Check if an array is null or empty
        public static bool IsArrayNullOrEmpty<T>(T[] array)
        {
            return array == null || array.Length == 0;
        }

        // Convert array to list
        public static List<T> ConvertArrayToList<T>(T[] array)
        {
            if (array == null)
                return new List<T>();

            return array.ToList();
        }

        // Convert list to array
        public static T[] ConvertListToArray<T>(List<T> list)
        {
            if (list == null)
                return new T[0];

            return list.ToArray();
        }

        // Shuffle elements in a list
        public static void ShuffleList<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        // Convert object to JSON string
        public static string ConvertObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string ConvertTableToJson(DataTable table)
        {
            return JsonConvert.SerializeObject(table, Formatting.Indented);
        }

        // Convert JSON string to object
        public static T ConvertJsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        // Convert bytes to base64 string
        public static string ConvertBytesToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        // Convert base64 string to bytes
        public static byte[] ConvertBase64ToBytes(string base64String)
        {
            return Convert.FromBase64String(base64String);
        }

        public static string FormatStringToDecimal(string strValue, int decimalPlaces)
        {
            if (decimal.TryParse(strValue, out decimal number))
            {
                // Format the decimal with the specified number of decimal places
                return number.ToString($"0.{new string('0', decimalPlaces)}");
            }
            else
            {
                throw new ArgumentException("Input string is not a valid decimal number.");
            }
        }

        public static string FormatStringToDecimalComma(string strValue, int decimalPlaces)
        {
            if (decimal.TryParse(strValue, out decimal number))
            {
                // Format the decimal with the specified number of decimal places and with thousands separators
                return number.ToString($"#,##0.{new string('0', decimalPlaces)}");
            }
            else
            {
                throw new ArgumentException("Input string is not a valid decimal number.");
            }
        }

        private static readonly string[] Units = { "", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า" };
        private static readonly string[] Tens = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
        public static string ConvertToThaiBahtText(decimal number)
        {
            if (number == 0)
                return "ศูนย์บาทถ้วน";

            var bahts = Math.Floor(number);
            var satangs = (number - bahts) * 100;

            string bahtText = ConvertWholeNumberToWords((long)bahts) + "บาท";
            string satangText = satangs > 0 ? ConvertWholeNumberToWords((long)satangs) + "สตางค์" : "ถ้วน";

            return bahtText + satangText;
        }
        private static string ConvertWholeNumberToWords(long number)
        {
            if (number == 0)
                return "";

            string words = "";

            if (number >= 1000000)
            {
                words += ConvertWholeNumberToWords(number / 1000000) + Tens[6];
                number %= 1000000;
            }

            int unitIndex = 0;

            while (number > 0)
            {
                int digit = (int)(number % 10);
                if (unitIndex == 1 && digit == 1)
                {
                    words = "สิบ" + words;
                }
                else if (unitIndex == 1 && digit == 2)
                {
                    words = "ยี่สิบ" + words;
                }
                else if (digit != 0)
                {
                    words = Units[digit] + Tens[unitIndex] + words;
                }
                number /= 10;
                unitIndex++;
            }

            return words;
        }


    }
}
