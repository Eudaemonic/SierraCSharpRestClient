﻿using System;
using SierraCSharpRestClient.Interfaces;

namespace SierraCSharpRestClient.Models.PatronSubset
{
    public partial class CheckOut : ICheckout
    {
        private string _id;
        public string id
        {
            get => _id;
            set => _id = !string.IsNullOrEmpty(value) ? value.Remove(0, value.LastIndexOf('/') + 1) : value;
        }
       

        public string patron { get; set; }
        public virtual string item { get; set; }
        public DateTime dueDate { get; set; }
        public int numberOfRenewals { get; set; }
        public DateTime outDate { get; set; }
        public DateTime recallDate { get; set; }
        public string callNumber { get; set; }
        public string barcode { get; set; }
        public int code { get; set; }
        public int specificCode { get; set; }
        public int httpStatus { get; set; }
        public string name { get; set; }
        public string description { get; set; }


    }
}