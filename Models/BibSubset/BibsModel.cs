using System.Collections.Generic;

namespace SierraCSharpRestClient.Models.BibSubset
{
    public class BibsModel
    {
        public string id { get; set; }
        public List<VarField> varFields { get; set; }
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
