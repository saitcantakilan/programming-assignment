using Obilet.Core.Models.BusJourneys;
using Obilet.Core.Models.BusLocations;
using Obilet.Core.Models.Commons;
using Obilet.Core.Models.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Core.Abstractions.Services
{
    public interface IObiletService
    {
        /// <summary>
        /// Verilen otobüs seyahati isteği modeline göre dış API'ye istek göndererek otobüs seyahatlerini getiren bir servis metodu.
        /// </summary>
        /// <param name="busJourneyRequest">Otobüs seyahati isteği modeli.</param>
        /// <returns>Otobüs seyahati yanıt modelini içeren bir Task.</returns>
        Task<SessionResponseModel> GetSessionAsync(SessionRequestModel sessionRequest);

        /// <summary>
        /// Verilen otobüs lokasyon isteği modeline göre dış API'ye istek göndererek otobüs lokasyonlarını getiren bir servis metodu.
        /// </summary>
        /// <param name="busLocationRequest">Otobüs lokasyon isteği modeli.</param>
        /// <returns>Otobüs lokasyon yanıt modelini içeren bir Task.</returns>
        Task<BusLocationResponseModel> GetBusLocationsAsync(BusLocationRequestModel busLocationRequest);

        /// <summary>
        /// Verilen otobüs seyahati isteği modeline göre dış API'ye istek göndererek otobüs seyahatlerini getiren bir servis metodu.
        /// </summary>
        /// <param name="busJourneyRequest">Otobüs seyahati isteği modeli.</param>
        /// <returns>Otobüs seyahati yanıt modelini içeren bir Task.</returns>
        Task<BusJourneyResponseModel> GetBusJourneysAsync(BusJourneyRequestModel busJourneyRequest);
    }
}
