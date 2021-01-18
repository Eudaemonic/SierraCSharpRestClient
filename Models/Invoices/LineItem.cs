using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SierraCSharpRestClient.Models.Invoices
{
    public class LineItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("invoice")]
        public Uri Invoice { get; set; }

        [JsonProperty("order")]
        public Uri Order { get; set; }

        [JsonProperty("paidAmount")]
        public decimal PaidAmount { get; set; }

        [JsonProperty("lienAmount")]
        public decimal LienAmount { get; set; }

        [JsonProperty("lienFlag")]
        public long LienFlag { get; set; }

        [JsonProperty("fund")]
        public string Fund { get; set; }

        [JsonProperty("subFund")]
        public long SubFund { get; set; }

        [JsonProperty("noOfCopies")]
        public long NoOfCopies { get; set; }

        [JsonProperty("orderStatus")]
        public string OrderStatus { get; set; }

        [JsonProperty("lineItemNote")]
        public string LineItemNote { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("multiFlag")]
        public string MultiFlag { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }
    }


    public class LineItems
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("entries")]
        public List<LineItem> Entries { get; set; }


    }
}
