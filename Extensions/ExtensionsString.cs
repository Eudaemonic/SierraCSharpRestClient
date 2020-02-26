using System;
using System.Linq;

namespace SierraCSharpRestClient.Extensions
{
    public static class ExtensionsString
    {
        public static string ToArrayString(this ResponseField[] array)
        {
            return string.Join(",", array);
        }

        public static string GetIdFromLink(this string link)
        {
            return link.Contains('/') ? link.Substring(link.LastIndexOf("/", StringComparison.Ordinal) + 1, 7) : string.Empty;
        }

        public static int GetIdAsIntFromLink(this string link)
        {
            return Convert.ToInt32(link.Contains('/') ? link.Substring(link.LastIndexOf("/", StringComparison.Ordinal) + 1, 7) : string.Empty);
        }
    }
}
