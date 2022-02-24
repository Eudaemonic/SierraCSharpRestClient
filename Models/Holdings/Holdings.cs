using Newtonsoft.Json;
using System.Collections.Generic;

namespace SierraCSharpRestClient.Models.Holdings
{
    public partial class Holdings
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("entries")]
        public List<Entry> Entries { get; set; }
    }

    public partial class Entry
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("varFields")]
        public List<VarField> VarFields { get; set; }
    }

    public partial class VarField
    {
        [JsonProperty("fieldTag")]
        public string FieldTag { get; set; }

        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty("marcTag", NullValueHandling = NullValueHandling.Ignore)]
        public string MarcTag { get; set; }

        [JsonProperty("ind1", NullValueHandling = NullValueHandling.Ignore)]
        public string Ind1 { get; set; }

        [JsonProperty("ind2", NullValueHandling = NullValueHandling.Ignore)]
        public string Ind2 { get; set; }

        [JsonProperty("subfields", NullValueHandling = NullValueHandling.Ignore)]
        public List<Subfield> Subfields { get; set; }
    }

    public partial class Subfield
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}


