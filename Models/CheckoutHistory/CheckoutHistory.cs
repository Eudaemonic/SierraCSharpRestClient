using Newtonsoft.Json;
using SierraCSharpRestClient.Extensions;
using System;
using System.Threading;
using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models.BibSubset;

namespace SierraCSharpRestClient.Models.CheckoutHistory
{
    public class CheckoutHistory
    {


        [JsonProperty("itemId")]
        public int ItemId;

        [JsonProperty("item")]
        public string Item
        {
            get => ItemId.ToString();
            set => ItemId = value.GetIdAsIntFromLink();
        }

        [JsonProperty("checkoutId")]
        public int CheckOutId;

        [JsonProperty("id")]
        public string Id
        {
            get => CheckOutId.ToString();
            set => CheckOutId = value.GetIdAsIntFromLink();
        }

        [JsonProperty("bibId")] public int BibId => Bib.GetIdAsIntFromLink();

        [JsonProperty("bib")]
        public string Bib
        {
            get;
            set;
        }



        [JsonProperty("readableDate")]
        public string ReadableDate => DateTime.Parse(OutDate).ToString("D");

        [JsonProperty("outDate")]
        public string OutDate
        {
            get;
            set;
        }


    }
}
