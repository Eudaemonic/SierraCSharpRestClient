using System;

namespace SierraCSharpRestClient.Models.BibSubset
{

    public class Lang
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class MaterialType
    {
        public string code { get; set; }
        public string value { get; set; }
    }

    public class BibLevel
    {
        public string code { get; set; }
        public string value { get; set; }
    }

    public class Country
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public partial class SimpleBib
    {
        public string id { get; set; }
        public DateTime updatedDate { get; set; }
        public DateTime createdDate { get; set; }
        public bool deleted { get; set; }
        public bool suppressed { get; set; }
        public Lang lang { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public MaterialType materialType { get; set; }
        public BibLevel bibLevel { get; set; }
        public string catalogDate { get; set; }
        public Country country { get; set; }

        public int publishYear { get; set; }
    }
}
