using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SierraCSharpRestClient
{
  
        /// <summary> Enum Extension Methods </summary>
        /// <typeparam name="T"> type of Enum </typeparam>
        public class Enum<T> where T : struct, IConvertible
        {
            public static T[] GetEnumArray()
            {
                T[] array = (T[])Enum.GetValues(typeof(T));
                return array;
            }
        }

}
