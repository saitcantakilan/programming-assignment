using Obilet.Core.Models.BusJourneys;
using Obilet.Core.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Core.Abstractions.Services
{
    public interface IBusJourneyService
    {
        /// <summary>
        /// Verilen otobüs seyahati filtresine göre otobüs seyahatlerini getiren bir servis metodu.
        /// </summary>
        /// <param name="busJourneyFilter">Otobüs seyahati filtresi.</param>
        /// <returns>
        /// Otobüs seyahatlerini içeren bir ResponseResultModel nesnesi.
        /// </returns>
        Task<ResponseResultModel<IEnumerable<BusJourneyModel>>> GetBusJourneyAsync(BusJourneyFilterModel busJourneyFilter);
    }
}
