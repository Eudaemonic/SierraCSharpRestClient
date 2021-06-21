using Newtonsoft.Json;

namespace SierraCSharpRestClient.Models.PatronSubset
{

    public partial class Reservation
    {
        [JsonProperty("recordType")]
        public string RecordType { get; set; }

        [JsonProperty("recordNumber")]
        public int RecordNumber { get; set; }

        [JsonProperty("pickupLocation")]
        public string PickupLocation { get; set; }

        [JsonProperty("neededBy", NullValueHandling = NullValueHandling.Ignore)]
        public string NeededBy { get; set; }

        [JsonProperty("numberOfCopies", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int NumberOfCopies { get; set; }

        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; set; }
    }

  
    }