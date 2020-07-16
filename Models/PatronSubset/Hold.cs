using System.Collections.Generic;

namespace SierraCSharpRestClient.Models.PatronSubset
{
    public class Holds
    {
        public int total { get; set; }
        public int start { get; set; }
        public List<Hold> entries { get; set; }
    }


    public class Hold
    {
        public string id { get; set; }
        public string record { get; set; }
        public string patron { get; set; }
        public bool frozen { get; set; }
        public string placed { get; set; }
        public string notNeededAfterDate { get; set; }
        public string notWantedBeforeDate { get; set; }
        public Pickuplocation pickupLocation { get; set; }
        public Status status { get; set; }
        public string recordType { get; set; }
        public int priority { get; set; }
    }

    public class Pickuplocation
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Status
    {
        public string code { get; set; }
        public string name { get; set; }
    }
}