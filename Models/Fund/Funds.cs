using Newtonsoft.Json;
using System.Collections.Generic;

namespace SierraCSharpRestClient.Models.Fund
{
    public class Funds
    {
        [JsonProperty("entries")]
        public List<Fund> Entries { get; set; }
    }
}
