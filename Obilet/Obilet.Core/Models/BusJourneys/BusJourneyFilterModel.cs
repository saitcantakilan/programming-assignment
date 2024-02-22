using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obilet.Core.Models.BusJourneys
{
    public class BusJourneyFilterModel
    {

        [JsonPropertyName("origin-id")]
        public int OriginId { get; set; }
        [JsonPropertyName("destination-id")]
        public int DestinationId { get; set; }
        [JsonPropertyName("departure-date")]
        public DateTime DepartureDate { get; set; }
    }
}
