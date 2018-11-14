using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SierraCSharpRestClient
{
    public static class ExtensionsString
    {
        public static string ToArraryString(this ResponseField[] array)
        {
            return string.Join(",", array);
        }
    }
}
