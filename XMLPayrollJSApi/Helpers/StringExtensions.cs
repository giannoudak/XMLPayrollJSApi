using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XMLPayrollJSApi.Helpers
{
    public static class StringExtensions
    {
        public static string Right(this string str, int length)
        {
            if (String.IsNullOrEmpty(str))
            {
                return null;
            }

            return str.Substring(str.Length - length, length);
        }
    }
}