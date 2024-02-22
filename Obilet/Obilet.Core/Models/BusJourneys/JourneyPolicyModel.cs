using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obilet.Core.Models.BusJourneys
{
    public class JourneyPolicyModel
    {
        [JsonPropertyName("max-seats")]
        public string? MaxSeats { get; set; }
        [JsonPropertyName("max-single")]
        public int? MaxSingle { get; set; }
        [JsonPropertyName("max-single-males")]
        public int? MaxSingleMales { get; set; }
        [JsonPropertyName("max-single-females")]
        public int? MaxSingleFemales { get; set; }
        [JsonPropertyName("mixed-genders")]
        public bool MixedGenders { get; set; }
        [JsonPropertyName("gov-id")]
        public bool GovId { get; set; }
        [JsonPropertyName("lht")]
        public bool Lht { get; set; }
    }
}
