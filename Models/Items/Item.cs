using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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

        [JsonProperty("varFields")]
        public VarField[] varFields { get; set; }
    }

    public  class VarField
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
        public Subfield[] Subfields { get; set; }
    }

    public  class Subfield
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class ItemResult
    {
        public int total { get; set; }
        
        public List<Item> entries { get; set; }
    }
}
