using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Obilet.Presentation.WebApp.Exceptions;
using Obilet.Presentation.WebApp.Models;

namespace Obilet.Presentation.WebApp.ExceptionHandlers
{
    public class HttpRequestExceptionHandler(ILogger<HttpRequestException> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not HttpRequestException)
                return false;

            // İstisna meydana geldiği zamanın yolunu al (hangi endpoint üzerinde meydana geldi)
            string routeWhereExceptionOccured = httpContext.Request.Path;

            // Hata modelini oluştur ve yolu ata
            var errorModel = new ErrorViewModel { Path = routeWhereExceptionOccured };

            
            // Eğer bir AggregateException meydana geldiyse
            if (exception is AggregateException ae)
            {
                // Hata mesajlarını al ve listeye ekle
                var messages = ae.InnerExceptions.Select(e => $"Http isteği işlenirken hata meydana geldi. {e.Message}").ToList();
                errorModel.ErrorMessages = messages;
            }
            else
            {
                // Diğer durumlarda sadece tek bir hata mesajı al
                string message = $"Http isteği işlenirken hata meydana geldi. {exception.Message}";
                errorModel.ErrorMessages = new List<string> { message };
            }

            // Hata modelini JSON formatına çevir
            string errorMessagesJson = JsonConvert.SerializeObject(errorModel);

            // Hata mesajlarını logla
            logger.LogInformation(errorMessagesJson);

            return true;
        }
    
    }
}
