using Obilet.Core.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Obilet.Infrastructure.Services
{
    public class ApiClientService : IApiClientService
    {
        private readonly HttpClient _httpClient;

        public ApiClientService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<TResponse> PostAsync<TResponse, TRequest>(string url, TRequest request)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, request);

                if (!response.IsSuccessStatusCode)
                {
                    // Başarısız durum kodunu uygun şekilde ele al
                    throw new HttpRequestException($"{url} isteği {response.StatusCode} durum kodu ile başarısız oldu.");
                }

                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            catch (HttpRequestException ex)
            {
                // HTTP istek istisnasını ele al
                throw new HttpRequestException($"{url} adres isteği işlenirken bir hata oluştu. Hata : {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                // Diğer beklenmedik istisnaları ele al
                throw new Exception("Beklenmeyen bir hata oluştu. Hata : {ex.Message}", ex);
            }
        }
    }
}
