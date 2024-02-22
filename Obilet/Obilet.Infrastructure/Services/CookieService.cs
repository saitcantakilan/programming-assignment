using Microsoft.AspNetCore.Http;
using Obilet.Core.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Obilet.Infrastructure.Services
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Belirtilen anahtarla ilişkilendirilen çerez değerini alır.
        /// </summary>
        /// <typeparam name="T">Çerez değerinin türü.</typeparam>
        /// <param name="key">Çerez anahtarı.</param>
        /// <returns>Belirtilen anahtarla ilişkilendirilen çerez değeri. Eğer çerez bulunamazsa veya dönüştürme hatası oluşursa varsayılan değer döner.</returns>
        public T? Get<T>(string key)
        {
            string cookieValue = _httpContextAccessor.HttpContext.Request.Cookies[key];

            if (string.IsNullOrEmpty(cookieValue))
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(cookieValue);
        }

        /// <summary>
        /// Belirtilen anahtarla ilişkilendirilen çereze değerini ayarlar.
        /// </summary>
        /// <typeparam name="T">Çerez değerinin türü.</typeparam>
        /// <param name="key">Çerez anahtarı.</param>
        /// <param name="value">Ayarlanacak çerez değeri.</param>
        /// <param name="expires">Çerezin geçerlilik süresi.</param>
        public void Set<T>(string key, T value, DateTime expires)
        {
            var jsonValue = JsonSerializer.Serialize(value);

            CookieOptions option = new CookieOptions();
            option.Expires = expires;

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, jsonValue, option);
        }
    }

}
