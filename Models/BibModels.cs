using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SierraCSharpRestClient.Models
{
    public class BibModels
    {
        public class Bib
        {
            public string id { get; set; }
            public bool available { get; set; }
            public string title { get; set; }
            public string author { get; set; }
            public int? publishYear { get; set; }
        }

        public class BibSearchResultEntry
        {
            public double relevance { get; set; }
            public Bib bib { get; set; }
        }

        public class BibSearchResultSet
        {
            public int count { get; set; }
            public int total { get; set; }
            public int start { get; set; }
            public List<BibSearchResultEntry> entries { get; set; }
        }


    }
}
