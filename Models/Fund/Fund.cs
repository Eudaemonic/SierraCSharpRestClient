using Newtonsoft.Json;

namespace SierraCSharpRestClient.Models.Fund
{
  

    public partial class Fund
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("fundName")]
        public string FundName { get; set; }

        [JsonProperty("note1")]
        public string Note1 { get; set; }

        [JsonProperty("note2")]
        public string Note2 { get; set; }

        [JsonProperty("extCode")]
        public long ExtCode { get; set; }

        [JsonProperty("extFundName")]
        public string ExtFundName { get; set; }

        [JsonProperty("fundType")]
        public string FundType { get; set; }
    }

}
