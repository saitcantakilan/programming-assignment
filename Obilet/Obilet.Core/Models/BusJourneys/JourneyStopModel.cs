using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obilet.Core.Models.BusJourneys
{
    public class JourneyStopModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("station")]
        public string Station { get; set; }
        [JsonPropertyName("time")]
        public DateTime? Time { get; set; }
        [JsonPropertyName("is-origin")]
        public bool IsOrigin { get; set; }
        [JsonPropertyName("is-destination")]
        public bool IsDestination { get; set; }
    }
}
