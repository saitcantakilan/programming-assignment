using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Obilet.Core.Abstractions.Services;
using Obilet.Core.Models;
using Obilet.Core.Models.BusJourneys;
using Obilet.Core.Models.Validations;
using Obilet.Core.Services;
using System.Reflection;


namespace Obilet.Core
{
    public static class ServiceRegistration
    {
        public static void AddCoreConfigureService(this IServiceCollection services,
       IConfiguration configuration)
        {
            services.Configure<AppOptions>(configuration.GetSection(nameof(AppOptions)));
            services.AddScoped<IObiletService, ObiletService>();
            services.AddScoped<IClientSessionService, ClientSessionService>();
            services.AddScoped<IBusJourneyService, BusJourneyService>();
            services.AddScoped<IBusLocationService, BusLocationService>();
            services.AddScoped<IValidator<BusJourneyFilterModel>,GetBusJourneyValidator>();

        }
    }
}
