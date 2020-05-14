namespace SierraCSharpRestClient.Models.FinesSet
{
    public class Payment
    {
        public int amount { get; set; }

        public int paymentType { get; set; }

        public string invoiceNumber { get; set; }

        public string initials { get; set; }
    }
}
