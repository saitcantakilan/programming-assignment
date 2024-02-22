using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Core.Models
{
    public class AppOptions
    {
        /// <summary>
        /// API isteklerinin temel URL'si.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// API isteklerinde kimlik doğrulaması için kullanılan anahtar.
        /// </summary>
        public string ClientToken { get; set; }

        /// <summary>
        /// Oturum bilgisi almak için API isteği yapılacak URL.
        /// </summary>
        public string GetSessionUrl { get; set; }

        /// <summary>
        /// Otobüs lokasyonlarını almak için API isteği yapılacak URL.
        /// </summary>
        public string GetBusLocationsUrl { get; set; }

        /// <summary>
        /// Otobüs seyahatlerini almak için API isteği yapılacak URL.
        /// </summary>
        public string GetBusJourneysUrl { get; set; }

        /// <summary>
        /// Harici yönlendirme URL'si.
        /// </summary>
        public string RedirectExternalUrl { get; set; }
    }
}
