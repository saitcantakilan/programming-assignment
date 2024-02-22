using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Obilet.Core.Models;
using Obilet.Core.Abstractions.Services;
using Obilet.Infrastructure.Services;

namespace Obilet.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            AppOptions appOptions = new();
            configuration.GetSection(nameof(AppOptions)).Bind(appOptions);

            services.AddHttpClient<IApiClientService, ApiClientService>(opt =>
            {
                opt.BaseAddress = new Uri(appOptions.BaseUrl);
                opt.DefaultRequestHeaders.Add("Authorization", "Basic " + appOptions.ClientToken);
            });

            services.AddSingleton<ICookieService, CookieService>();
        }
    }
}
