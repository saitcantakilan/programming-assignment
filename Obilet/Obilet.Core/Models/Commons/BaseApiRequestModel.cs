using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Obilet.Core.Models.Sessions;

namespace Obilet.Core.Models.Commons
{
    public class BaseApiRequestModel
    {
        [JsonPropertyName("device-session")]
        public ClientSessionModel ClientSession { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }
    }
}
