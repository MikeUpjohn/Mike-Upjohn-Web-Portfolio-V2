using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikeUpjohnWebPortfolioV2.Code
{
    public static class UsefulFunctions
    {
        public static string SafeURL(string url)
        {
            url = url.Trim();
            url = url.Replace(" ", "-");
            url = url.Replace("\"", "-");
            url = url.Replace("%", "-");
            url = url.Replace("&", "-");

            return url.ToLower();
        }

        public static string FormatDateToShortDateString(DateTime date)
        {
            return date.ToString("ddd dd MMM, yyyy");
        }

        public static string FormatDateToLongDateString(DateTime date)
        {
            return date.ToString("dddd dd MMMM, yyyy");
        }
    }
}
