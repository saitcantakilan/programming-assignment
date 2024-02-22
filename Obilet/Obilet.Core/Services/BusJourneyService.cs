using Obilet.Core.Abstractions.Services;
using Obilet.Core.Models.BusJourneys;
using Obilet.Core.Models.BusLocations;
using Obilet.Core.Models.Commons;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Obilet.Core.Enums.CommonEnum;

namespace Obilet.Core.Services
{
    public class BusJourneyService : IBusJourneyService
    {
        private readonly IObiletService _obiletService;
        private readonly IClientSessionService _clientSessionService;

        public BusJourneyService(IObiletService obiletService, IClientSessionService clientSessionService)
        {
            _obiletService = obiletService;
            _clientSessionService = clientSessionService;
        }

        public async Task<ResponseResultModel<IEnumerable<BusJourneyModel>>> GetBusJourneyAsync(BusJourneyFilterModel busJourneyFilter)
        {

            var clientSessionModel = await _clientSessionService.GetSession();
            BusJourneyRequestModel busJourneyRequest = new()
            {
                BusJourneyFilter = busJourneyFilter,
                ClientSession = clientSessionModel,
                Language = clientSessionModel.IpCountry != null ? CultureInfo.CreateSpecificCulture(clientSessionModel.IpCountry).Name : CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name).Name,
                Date = DateTime.Now,
            };
            var response = await _obiletService.GetBusJourneysAsync(busJourneyRequest);
            if (response.Status == ResponseResultTypes.Success.ToString())
                return new ResponseResultModel<IEnumerable<BusJourneyModel>>().Success(response.BusJourneys.OrderBy(o => o.JourneyDetail.Departure).AsEnumerable());
            else
                return new ResponseResultModel<IEnumerable<BusJourneyModel>>().Error(response.BusJourneys, response.UserMessage);
        }
    }
}
