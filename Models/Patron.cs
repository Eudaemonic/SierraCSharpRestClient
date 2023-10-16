using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace SierraCSharpRestClient.Models
{
    public class Patron
    {


        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DisplayName("Email")]
        public List<string> emails { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DisplayName("Name")]
        public List<string> names { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DisplayName("Patron Type")]
        public int? patronType { get; set; }


        [DisplayName("Address")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Address> addresses { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DisplayName("Barcode")]
        public List<string> barcodes { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DisplayName("Expiry Date")]
        public string expirationDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DisplayName("Patron Codes")]
        public PatronCodes patronCodes { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<VarField> varFields { get; set; }


        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<int, FixedFieldEntry> fixedFields { get; set; }
    }


    public class Address
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> lines { get; set; }

        public string type { get; set; }
    }

    public class PatronCodes
    {
        [DisplayName("Pcode 1")]
        public string pcode1 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DisplayName("Pcode 2")]
        public string pcode2 { get; set; }

        [DisplayName("Pcode 3")]
        public int pcode3 { get; set; }

        [DisplayName("Pcode 4")]
        public int pcode4 { get; set; }
    }


    [DisplayName("varField")]
    public class VarField
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string fieldTag { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string content { get; set; }
    }



    public class FixedFieldEntry
    {
        public string label { get; set; }
        public string value { get; set; }


    }

    public class Canvas
    {
        void test()
        {
            var x = new Patron();

            var y = new Dictionary<int, List<List<FixedFieldEntry>>>();

         
        }
    }
   


}