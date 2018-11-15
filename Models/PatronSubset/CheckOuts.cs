using System;
using System.Collections.Generic;

namespace SierraCSharpRestClient.Models.PatronSubset
{
    public class CheckOuts

    {
        public int total { get; set; }
        public int start { get; set; }
        public List<CheckOut> entries { get; set; }
    }

}