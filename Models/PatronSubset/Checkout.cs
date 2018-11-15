using System;

namespace SierraCSharpRestClient.Models.PatronSubset
{
    public class CheckOut
    {
        private string _id;
        public string id
        {
            get { return _id;}
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _id = value.Substring(value.Length - 6);
                }
                else
                {
                    _id = value;
                }

            }
        }
       

        public string patron { get; set; }
        public string item { get; set; }
        public DateTime dueDate { get; set; }
        public int numberOfRenewals { get; set; }
        public DateTime outDate { get; set; }
        public DateTime recallDate { get; set; }

        public string barcode { get; set; }
    

    }
}