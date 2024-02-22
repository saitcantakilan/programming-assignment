using FluentValidation;
using Obilet.Core.Models.BusJourneys;

namespace Obilet.Presentation.WebApp.Validations
{
    public class GetBusJourneyValidator : AbstractValidator<BusJourneyFilterModel>
    {
        public GetBusJourneyValidator()
        {
            RuleFor(s => s.OriginId).NotEmpty().WithMessage("Nereden konumu boş olamaz");
            RuleFor(s => s.DestinationId).NotEmpty().WithMessage("Nereye konumu boş olamaz");
            RuleFor(s => s.OriginId).NotEqual(s => s.DestinationId).WithMessage("Nereden ve Nereye konumları aynı olamaz");
            RuleFor(s => s.DepartureDate).Must(IsValidDeparturaDate).WithMessage("Tarih en erken bugün olabilir");
        }


        private bool IsValidDeparturaDate(DateTime departuraDate)
        {
            return false;
        }
    }
}
