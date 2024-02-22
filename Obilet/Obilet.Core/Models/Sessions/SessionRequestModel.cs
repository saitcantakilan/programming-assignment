using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obilet.Core.Models.Sessions
{
    public class SessionRequestModel
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("connection")]
        public SessionConnectionModel Connection { get; set; }

        [JsonPropertyName("browser")]
        public SessionBrowserModel Browser { get; set; }
    }
}
