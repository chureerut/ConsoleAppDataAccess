using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Common.Helpers
{
    public static class DateHelper
    {
        public static string FormatDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }
    }
}
