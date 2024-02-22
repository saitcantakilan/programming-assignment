using Obilet.Core.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obilet.Core.Models.BusJourneys
{
    public class BusJourneyResponseModel : BaseApiResponseModel
    {
        [JsonPropertyName("data")]
        public IList<BusJourneyModel> BusJourneys { get; set; }
    }
}
