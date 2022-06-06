using System;
using System.Text;

namespace SierraCSharpRestClient.Helpers
{
    public static class DateHelpers
    {
       public static string FormatSierraDateRange( DateTime startDate, DateTime endDate)
       {
           

            var sb = new StringBuilder();
            if (endDate != null)
            {
                sb.Append("[");
                sb.Append(startDate.ToString("s"));
                sb.Append(",");
                sb.Append(endDate.ToString("s"));
                sb.Append("]");
                return sb.ToString();
            }
            return startDate.ToString("s");
        }
    }
}
