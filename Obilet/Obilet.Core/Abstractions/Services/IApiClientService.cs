using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Core.Abstractions.Services
{
    public interface IApiClientService
    {        
        /// <summary>
        /// Belirtilen URL'ye bir HTTP POST isteği gönderir ve isteğin sonucunu belirtilen yanıt türünde alır.
        /// </summary>
        /// <typeparam name="TResponse">İstek sonucunda dönecek olan yanıtın türü.</typeparam>
        /// <typeparam name="TRequest">Gönderilen isteğin türü.</typeparam>
        /// <param name="url">POST isteğinin gönderileceği hedef URL.</param>
        /// <param name="request">POST isteği için gönderilecek olan veri.</param>
        /// <returns>POST isteğinin sonucunda alınan yanıtın belirtilen türdeki karşılığı.</returns>
        Task<TResponse> PostAsync<TResponse, TRequest>(string url, TRequest request);
    }
}
