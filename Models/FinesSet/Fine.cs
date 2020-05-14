using System;

namespace SierraCSharpRestClient.Models.FinesSet
{
    public class Fine
    {
        public string id { get; set; }
        public string patron { get; set; }
        public DateTime assessedDate { get; set; }
        public string description { get; set; }
        public int invoiceNumber { get; set; }
        public ChargeType chargeType { get; set; }
        public double itemCharge { get; set; }
        public double processingFee { get; set; }
        public double billingFee { get; set; }
        public double paidAmount { get; set; }
        public Location location { get; set; }
    }

    public class ChargeType
    {
        public string code { get; set; }
        public string display { get; set; }
    }

    public class Location
    {
        public string code { get; set; }
        public string name { get; set; }
    }
}