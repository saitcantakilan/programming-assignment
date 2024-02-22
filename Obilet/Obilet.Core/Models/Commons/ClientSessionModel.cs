using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Obilet.Core.Models.Sessions;

namespace Obilet.Core.Models.Commons
{
    public class ClientSessionModel
    {
        [JsonPropertyName("session-id")]
        public string SessionId { get; set; }

        [JsonPropertyName("device-id")]
        public string DeviceId { get; set; }
        
        [JsonIgnore]
        [JsonPropertyName("affiliate")]
        public string Affiliate { get; set; }
        
        [JsonIgnore]
        [JsonPropertyName("device-type")]
        public long DeviceType { get; set; }
        
        [JsonIgnore]
        [JsonPropertyName("device")]
        public string Device { get; set; }
        [JsonIgnore]
        public string IpCountry { get; set; }
    }
}
