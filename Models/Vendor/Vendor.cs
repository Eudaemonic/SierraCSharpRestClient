using Newtonsoft.Json;
using System.Collections.Generic;

namespace SierraCSharpRestClient.Models.Vendor
{

    public partial class VendorFull
    {
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public long? Total { get; set; }

        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public long? Start { get; set; }

        [JsonProperty("entries", NullValueHandling = NullValueHandling.Ignore)]
        public List<Entry> Entries { get; set; }
    }

    public partial class Entry
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("accountingUnit", NullValueHandling = NullValueHandling.Ignore)]
        public long? AccountingUnit { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("vendorName", NullValueHandling = NullValueHandling.Ignore)]
        public string VendorName { get; set; }

        [JsonProperty("address1", NullValueHandling = NullValueHandling.Ignore)]
        public string Address1 { get; set; }

        [JsonProperty("discount", NullValueHandling = NullValueHandling.Ignore)]
        public long? Discount { get; set; }

        [JsonProperty("fixedFields", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, FixedField> FixedFields { get; set; }

        [JsonProperty("varFields", NullValueHandling = NullValueHandling.Ignore)]
        public List<VarField> VarFields { get; set; }
    }

    public partial class FixedField
    {
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }

    public partial class VarField
    {
        [JsonProperty("fieldTag", NullValueHandling = NullValueHandling.Ignore)]
        public string FieldTag { get; set; }

        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }
    }
}
