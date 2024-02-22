using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obilet.Core.Models.BusJourneys
{
    public class JourneyModel
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("stops")]
        public IList<JourneyStopModel> Stops { get; set; }
        [JsonPropertyName("origin")]
        public string Origin { get; set; }
        [JsonPropertyName("destination")]
        public string Destination { get; set; }
        [JsonPropertyName("departure")]
        public DateTime Departure { get; set; }
        [JsonPropertyName("arrival")]
        public DateTime Arrival { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("duration")]
        public string Duration { get; set; }
        [JsonPropertyName("original-price")]
        public double OriginalPrice { get; set; }
        [JsonPropertyName("internet-price")]
        public double InternetPrice { get; set; }
        [JsonPropertyName("booking")]
        public string Booking { get; set; }
        [JsonPropertyName("bus-name")]
        public string BusName { get; set; }
        [JsonPropertyName("policy")]
        public JourneyPolicyModel Policy { get; set; }

        [JsonPropertyName("features")]
        public IList<string> Features { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("available")]
        public string Available { get; set; }
    }
}
