using Newtonsoft.Json;

namespace SierraCSharpRestClient.Models
{

    public partial class BaseResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("specificCode")]
        public int SpecificCode { get; set; }

        [JsonProperty("httpStatus")]
        public int HttpStatus { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
