using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SierraCSharpRestClient.Models.Invoices
{

    public class Invoice
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("accountingUnit")]
        public long AccountingUnit { get; set; }

        [JsonProperty("invDate")]
        public DateTimeOffset InvDate { get; set; }

        [JsonProperty("invNum")]
        public string InvNum { get; set; }

        [JsonProperty("vendors")]
        public Vendor[] Vendors { get; set; }

        [JsonProperty("paidDate")]
        public DateTimeOffset PaidDate { get; set; }

        [JsonProperty("invTotal")]
        public InvTotal InvTotal { get; set; }

        [JsonProperty("lineItems")]
        public Uri[] LineItems { get; set; }

        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }
    }

    public class InvTotal
    {
        [JsonProperty("subTotal")]
        public double SubTotal { get; set; }

        [JsonProperty("shipping")]
        public long Shipping { get; set; }

        [JsonProperty("tax")]
        public long Tax { get; set; }

        [JsonProperty("discountOrService")]
        public long DiscountOrService { get; set; }

        [JsonProperty("grandTotal")]
        public double GrandTotal { get; set; }
    }

    public class Vendor
    {
        [JsonProperty("vendorCode")]
        public string VendorCode { get; set; }

        [JsonProperty("voucherNum")]
        public long VoucherNum { get; set; }

        [JsonProperty("voucherTotal")]
        public long VoucherTotal { get; set; }
    }

    public class Invoices
    {
        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("entries")]
        public List<Invoice> Entries { get; set; }


    }
}

