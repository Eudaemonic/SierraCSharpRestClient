using Newtonsoft.Json;

namespace SierraCSharpRestClient.Models.PatronSubset
{
    public class ReadingHistoryActivationModel
    {
        [JsonProperty("readingHistoryActivation")]
        public bool ReadingHistoryActivation { get; set; }
    }
}
