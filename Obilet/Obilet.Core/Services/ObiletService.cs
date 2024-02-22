using Microsoft.Extensions.Options;
using Obilet.Core.Abstractions.Services;
using Obilet.Core.Models;
using Obilet.Core.Models.BusJourneys;
using Obilet.Core.Models.BusLocations;
using Obilet.Core.Models.Sessions;

namespace Obilet.Core.Services
{
    public class ObiletService : IObiletService
    {
        private readonly IApiClientService _apiClient;
        private readonly IOptions<AppOptions> _appOptions;

        public ObiletService(IApiClientService apiClient, IOptions<AppOptions> appOptions)
        {
            _apiClient = apiClient;
            _appOptions = appOptions;
        }

        public async Task<BusJourneyResponseModel> GetBusJourneysAsync(BusJourneyRequestModel busJourneyRequest)
        {
            return await _apiClient.PostAsync<BusJourneyResponseModel, BusJourneyRequestModel>(_appOptions.Value.GetBusJourneysUrl, busJourneyRequest);
        }

        public async Task<BusLocationResponseModel> GetBusLocationsAsync(BusLocationRequestModel busLocationRequest)
        {
            return await _apiClient.PostAsync<BusLocationResponseModel, BusLocationRequestModel>(_appOptions.Value.GetBusLocationsUrl, busLocationRequest);
        }

        public async Task<SessionResponseModel> GetSessionAsync(SessionRequestModel sessionRequest)
        {
            return await _apiClient.PostAsync<SessionResponseModel, SessionRequestModel>(_appOptions.Value.GetSessionUrl, sessionRequest);
        }
    }
}
