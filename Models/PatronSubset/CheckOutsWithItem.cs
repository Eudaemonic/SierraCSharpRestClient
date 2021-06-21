using System;
using System.Collections.Generic;

namespace SierraCSharpRestClient.Models.PatronSubset
{
    public class CheckOutsWithItem

    {
        public int total { get; set; }
        public int start { get; set; }
        public List<CheckOutWithItem> entries { get; set; }
    }

}