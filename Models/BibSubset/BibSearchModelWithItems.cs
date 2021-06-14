using Newtonsoft.Json;
using SierraCSharpRestClient.Models.Items;
using System.Collections.Generic;

namespace SierraCSharpRestClient.Models.BibSubset
{

    public partial class BibWithItems
    {
        public double relevance { get; set; }
        public SimpleBib bib { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ItemResult items { get; set; }
    }


    public class BibSearchModelWithItems
    {
        public int count { get; set; }
        public int total { get; set; }
        public int start { get; set; }
        public List<BibWithItems> entries { get; set; }
    }
}
