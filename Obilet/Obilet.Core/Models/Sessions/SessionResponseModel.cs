using Obilet.Core.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obilet.Core.Models.Sessions
{
    public class SessionResponseModel : BaseApiResponseModel
    {
        [JsonPropertyName("data")] 
        public ClientSessionModel ClientSession { get; set; }
    }
}
