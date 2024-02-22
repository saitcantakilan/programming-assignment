using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obilet.Core.Abstractions.Services;
using Obilet.Core.Models.BusJourneys;
using Obilet.Presentation.WebApp.Models;
using System.Diagnostics;

namespace Obilet.Presentation.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBusLocationService _busLocationService;
        private readonly ICookieService _cookieService;
        public HomeController(ILogger<HomeController> logger, IBusLocationService busLocationService, ICookieService cookieService)
        {
            _logger = logger;
            _busLocationService = busLocationService;
            _cookieService = cookieService;
        }

        public async Task<IActionResult> Index()
        {
            // Otobüs lokasyonlarýný al
            var busLocations = await _busLocationService.GetBusLocationsAsync();
            // Lokasyonlarý sýrala ve ilk 7 tanesini seç
            var busLocationSelectList = busLocations.OrderBy(o => o.Rank).Take(7);
            // View'a lokasyonlarý gönder
            ViewBag.BusLocationList = busLocationSelectList.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            // Çerezden filtre modelini al
            var cookieModel = _cookieService.Get<BusJourneyFilterModel>(typeof(BusJourneyFilterModel).Name);

            // Eðer çerezde model varsa direkt olarak view'a gönder
            if (cookieModel != null) return View(cookieModel);

            // Çerezde model yoksa default bir model oluþtur
            var model = new BusJourneyFilterModel()
            {
                OriginId = busLocationSelectList.First().Id, // Ýlk lokasyonu seç
                DestinationId = busLocationSelectList.Skip(2).First().Id, // Ýkinci lokasyonu seç
                DepartureDate = DateTime.Now.AddDays(1), // Yarýnki tarihi seç
            };
            return View(model);
        }

        // Otobüs lokasyonlarýný filtrelemek için kullanýlan action metodu
        public async Task<IEnumerable<SelectListItem>> GetBusLocationList(string search)
        {
            // Ýletilen arama terimiyle filtrelenmiþ otobüs lokasyonlarýný al
            var result = await _busLocationService.GetFilterBusLocationsAsync(search);
            // Gelen lokasyonlarý gönder
            return result.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
