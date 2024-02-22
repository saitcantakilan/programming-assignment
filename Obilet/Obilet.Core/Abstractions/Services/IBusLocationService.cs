using Obilet.Core.Models.BusLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Core.Abstractions.Services
{
    public interface IBusLocationService
    {
        /// <summary>
        /// Tüm otobüs lokasyonlarını getiren bir servis metodu.
        /// </summary>
        /// <returns>
        /// Otobüs lokasyonlarını içeren bir IList nesnesi.
        /// </returns>
        Task<IList<BusLocationModel>> GetBusLocationsAsync();

        /// <summary>
        /// Belirli bir lokasyon adına göre filtrelenmiş otobüs lokasyonlarını getiren bir servis metodu.
        /// </summary>
        /// <param name="location">Lokasyon adı veya filtreleme kriteri.</param>
        /// <returns>
        /// Filtrelenmiş otobüs lokasyonlarını içeren bir IList nesnesi.
        /// </returns>
        Task<IList<BusLocationModel>> GetFilterBusLocationsAsync(string location);
    }
}
