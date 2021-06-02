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
        public DateTime InvDate { get; set; }

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


        [JsonProperty("taxType")]
        public string TaxType { get; set; } 
        
        [JsonProperty("forCurrency")]
        public ForeignCurrency ForeignCurrency { get; set; }



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
    public class ForeignCurrency {
        [JsonProperty("code")]
        public string Code { get; set; }
        
        [JsonProperty("rate")]
        public string Rate { get; set; }
        
        [JsonProperty("format")]
        public string Format { get; set; }
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

public class UseTax
{
        [JsonProperty("useTaxFund")]
        public string UseTaxFund { get; set; }
        
        [JsonProperty("percentageRate")] 
        public decimal PercentageRate { get; set; }

        [JsonProperty("useTaxType")]
        public string UseTaxType { get; set; }


    }

    public class Invoices
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("entries")]
        public List<Invoice> Entries { get; set; }


    }
}

