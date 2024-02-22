using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Core.Abstractions.Services
{
    public interface ICookieService
    {
        /// <summary>
        /// Belirtilen anahtarla ilişkilendirilen çerez değerini alır.
        /// </summary>
        /// <typeparam name="T">Çerez değerinin türü.</typeparam>
        /// <param name="key">Çerez anahtarı.</param>
        /// <returns>Belirtilen anahtarla ilişkilendirilen çerez değeri. Eğer çerez bulunamazsa veya dönüştürme hatası oluşursa varsayılan değer döner.</returns>
        T? Get<T>(string key);

        /// <summary>
        /// Belirtilen anahtarla ilişkilendirilen çereze değerini ayarlar.
        /// </summary>
        /// <typeparam name="T">Çerez değerinin türü.</typeparam>
        /// <param name="key">Çerez anahtarı.</param>
        /// <param name="value">Ayarlanacak çerez değeri.</param>
        /// <param name="expires">Çerezin geçerlilik süresi.</param>
        void Set<T>(string key, T value, DateTime expires);
    }
}
