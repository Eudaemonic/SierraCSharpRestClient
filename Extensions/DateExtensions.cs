using System;
using System.Globalization;

namespace SierraCSharpRestClient.Extensions
{
    public static partial class DateExtensions
    {

            public static string ToSierraExpirationDateString(this DateTime dateTime)
            {
                return dateTime.ToString("yyyy-MM-dd");
            }

            public static DateTime ConvertSierraStringToDate(this string value)
            {
                return DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }

       
        }
    
}
