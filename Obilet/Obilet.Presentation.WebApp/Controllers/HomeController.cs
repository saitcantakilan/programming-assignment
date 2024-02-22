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
            // Otob�s lokasyonlar�n� al
            var busLocations = await _busLocationService.GetBusLocationsAsync();
            // Lokasyonlar� s�rala ve ilk 7 tanesini se�
            var busLocationSelectList = busLocations.OrderBy(o => o.Rank).Take(7);
            // View'a lokasyonlar� g�nder
            ViewBag.BusLocationList = busLocationSelectList.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            // �erezden filtre modelini al
            var cookieModel = _cookieService.Get<BusJourneyFilterModel>(typeof(BusJourneyFilterModel).Name);

            // E�er �erezde model varsa direkt olarak view'a g�nder
            if (cookieModel != null) return View(cookieModel);

            // �erezde model yoksa default bir model olu�tur
            var model = new BusJourneyFilterModel()
            {
                OriginId = busLocationSelectList.First().Id, // �lk lokasyonu se�
                DestinationId = busLocationSelectList.Skip(2).First().Id, // �kinci lokasyonu se�
                DepartureDate = DateTime.Now.AddDays(1), // Yar�nki tarihi se�
            };
            return View(model);
        }

        // Otob�s lokasyonlar�n� filtrelemek i�in kullan�lan action metodu
        public async Task<IEnumerable<SelectListItem>> GetBusLocationList(string search)
        {
            // �letilen arama terimiyle filtrelenmi� otob�s lokasyonlar�n� al
            var result = await _busLocationService.GetFilterBusLocationsAsync(search);
            // Gelen lokasyonlar� g�nder
            return result.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
