using Obilet.Presentation.WebApp.ExceptionHandlers;
using Obilet.Presentation.WebApp.Exceptions;

namespace Obilet.Presentation.WebApp.Extensions
{
    public static class ExceptionHandlerExtension
    {
        public static IServiceCollection AddExceptionHandlerExtensions(this IServiceCollection services)
        {            
            services.AddExceptionHandler<NullReferenceExceptionHandler>();
            services.AddExceptionHandler<HttpRequestExceptionHandler>();
            services.AddExceptionHandler<ExceptionHandler>();
            return services;
        }
    }
}
