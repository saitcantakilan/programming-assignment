using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obilet.Core.Models.Sessions
{
    public class SessionConnectionModel
    {
        [JsonPropertyName("ip-address")]
        public string IpAddress { get; set; }

        [JsonPropertyName("port")]
        public string Port { get; set; }
    }
}
