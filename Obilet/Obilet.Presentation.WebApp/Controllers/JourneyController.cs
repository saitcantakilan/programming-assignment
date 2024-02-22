using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Obilet.Core.Abstractions.Services;
using Obilet.Core.Models;
using Obilet.Core.Models.BusJourneys;

namespace Obilet.Presentation.WebApp.Controllers
{
    public class JourneyController : Controller
    {
        private readonly IBusJourneyService _busJourneyService;
        private readonly ICookieService _cookieService;
        private readonly IOptions<AppOptions> _appOptions;
        private readonly IValidator<BusJourneyFilterModel> _validator;

        public JourneyController(IBusJourneyService busJourneyService, ICookieService cookieService, IOptions<AppOptions> appOptions, IValidator<BusJourneyFilterModel> validator)
        {
            _busJourneyService = busJourneyService;
            _cookieService = cookieService;
            _appOptions = appOptions;
            _validator = validator;
        }

        public async Task<IActionResult> Index(BusJourneyFilterModel filterModel)
        {
            // Gelen filtre modelini doğrulama
            ValidationResult validationResult = await _validator.ValidateAsync(filterModel);
            if (!validationResult.IsValid)
            {
                return RedirectToAction("Index", "Home", new { ErrorMessage = validationResult.Errors.FirstOrDefault() });
            }

            // Filtre modelini çerez olarak ayarla
            _cookieService.Set(typeof(BusJourneyFilterModel).Name, filterModel, DateTime.Now.AddMinutes(30));

            // Otobüs seferlerini al
            var busJourneyServiceResult = await _busJourneyService.GetBusJourneyAsync(filterModel);
            if (busJourneyServiceResult.ResponseDataType == Core.Enums.CommonEnum.ResponseResultTypes.Success)
            {
                // Başarılı bir şekilde veri alındıysa ilgili view'a yönlendir ve verileri gönder
                var busJourneys = busJourneyServiceResult.Result;
                ViewBag.DestinationLocation = busJourneys?.FirstOrDefault()?.DestinationLocation;
                ViewBag.OriginLocation = busJourneys?.FirstOrDefault()?.OriginLocation;
                ViewBag.DepartureDate = filterModel.DepartureDate.Date.ToString("d MMMM dddd");
                return View(busJourneys);
            }
            else
            {
                // Veri alınırken bir hata oluştuysa anasayfaya yönlendir ve hata mesajını gönder
                return RedirectToAction("Index", "Home", new { ErrorMessage = busJourneyServiceResult.Message });
            }
        }

        // Harici bir URL'ye yönlendiren action metodu
        [Route("seferler/{originId}-{destinationId}/{departureDate}/{journeyId}")]
        public ActionResult RedirectExternal()
        {
            // Harici URL'ye yönlendir
            return Redirect(_appOptions.Value.RedirectExternalUrl + Request.Path);
        }
    }
}
