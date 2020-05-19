using System.Collections.Generic;

namespace SierraCSharpRestClient.Models.FinesSet
{



    public class Fines
    {
        public int total { get; set; }
        public List<Fine> entries { get; set; }
    }
}
