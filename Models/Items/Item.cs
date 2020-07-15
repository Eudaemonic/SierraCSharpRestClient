using System;
using System.Collections.Generic;

namespace SierraCSharpRestClient.Models.Items
{
    public class Location
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Status
    {
        public string code { get; set; }
        public string display { get; set; }
        public DateTime? duedate { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public DateTime updatedDate { get; set; }
        public DateTime createdDate { get; set; }
        public bool deleted { get; set; }
        public List<string> bibIds { get; set; }
        public Location location { get; set; }
        public Status status { get; set; }
        public string barcode { get; set; }
        public string callNumber { get; set; }
    }

    public class ItemResult
    {
        public int total { get; set; }
        
        public List<Item> entries { get; set; }
    }
}
