using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obilet.Core.Models.Commons
{
    public class BaseApiResponseModel
    {
        /// <summary>
        /// Yapılan isteğin cevap durumunu belirtir.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
        /// <summary>
        /// Yapılan istek başarılı değilse hata mesajını içerir.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
        /// <summary>
        /// Yapılan isteğin cevap durumunu kullanıcı için açıklayan mesajı içerir.
        /// </summary>
        [JsonPropertyName("user-message")]
        public string UserMessage { get; set; }
        /// <summary>
        /// Yapılan isteğin benzersiz bir kimliğini belirtir.
        /// </summary>
        [JsonPropertyName("api-request-id")]
        public string ApiRequestId { get; set; }
        /// <summary>
        /// Yapılan isteğin cevabını oluşturan controllerı belirtir.
        /// </summary>
        [JsonPropertyName("controller")]
        public string Controller { get; set; }
    }
}
