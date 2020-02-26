using Newtonsoft.Json;

namespace SierraCSharpRestClient.Models.PatronSubset
{
    public class ErrorCode
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "specificCode")]
        public string SpecificCode { get; set; }

        [JsonProperty(PropertyName = "httpStatus")]
        public string HttpStatus { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}