using Newtonsoft.Json;

namespace SierraCSharpRestClient.Models.Items
{
    public partial class SierraResponseMessage
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("specificCode")]
        public string SpecificCode { get; set; }

        [JsonProperty("httpStatus")]
        public string HttpStatus { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
