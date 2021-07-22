using SierraCSharpRestClient.Extensions;

namespace SierraCSharpRestClient.Models
{
    public class BaseGenericEnumerator<T> where T: new()
    {
        public int total { get; set; }
        public int start { get; set; }
        public T[] entries { get; set; }
    }

    
}