using Obilet.Core.Abstractions.Services;
using Obilet.Core.Models.BusLocations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Core.Services
{
    public class BusLocationService : IBusLocationService
    {
        private readonly IObiletService _obiletService;
        private readonly IClientSessionService _clientSessionService;

        public BusLocationService(IObiletService obiletService, IClientSessionService clientSessionService)
        {
            _obiletService = obiletService;
            _clientSessionService = clientSessionService;
        }

        public async Task<IList<BusLocationModel>> GetBusLocationsAsync()
        {

            var clientSessionModel = await _clientSessionService.GetSession();
            BusLocationRequestModel busLocationRequest = new()
            {
                ClientSession = clientSessionModel,
                Language = clientSessionModel.IpCountry != null ? CultureInfo.CreateSpecificCulture(clientSessionModel.IpCountry).Name : CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name).Name,
                Date = DateTime.Now,
            };
            BusLocationResponseModel busLocationResponse = await _obiletService.GetBusLocationsAsync(busLocationRequest);

            return busLocationResponse.BusLocations;
        }

        public async Task<IList<BusLocationModel>> GetFilterBusLocationsAsync(string location)
        {

            var clientSessionModel = await _clientSessionService.GetSession();
            BusLocationRequestModel busLocationRequest = new()
            {
                Data = location,
                ClientSession = clientSessionModel,
                Language = clientSessionModel.IpCountry != null ? CultureInfo.CreateSpecificCulture(clientSessionModel.IpCountry).Name : CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name).Name,
                Date = DateTime.Now,
            };
            BusLocationResponseModel busLocationResponse = await _obiletService.GetBusLocationsAsync(busLocationRequest);

            return busLocationResponse.BusLocations;
        }
    }
}
