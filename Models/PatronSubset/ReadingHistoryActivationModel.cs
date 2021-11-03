using Newtonsoft.Json;

namespace SierraCSharpRestClient.Models.PatronSubset
{
    public class ReadingHistoryActivationModel
    {
        [JsonProperty("readingHistoryActivation")]
        public string ReadingHistoryActivation { get; set; }
    }
}
