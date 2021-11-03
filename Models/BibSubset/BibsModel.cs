using System.Collections.Generic;
using Newtonsoft.Json;

namespace SierraCSharpRestClient.Models.BibSubset
{
    public class BibsModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string publishYear { get; set; }
        public List<Location> locations { get; set; }
        public List<VarField> varFields { get; set; }

        [JsonProperty("bibLevel")]
        public BibLevel bibLevel { get; set; }
    }

    public class Location
    {
        public string code { get; set; }
        public string name { get; set; }
    }


    public class Subfield
    {
        public string tag { get; set; }
        public string content { get; set; }
    }

    public class VarField
    {
        public string fieldTag { get; set; }
        public string marcTag { get; set; }
        public string ind1 { get; set; }
        public string ind2 { get; set; }
        public List<Subfield> subfields { get; set; }
        public string content { get; set; }
    }


}
