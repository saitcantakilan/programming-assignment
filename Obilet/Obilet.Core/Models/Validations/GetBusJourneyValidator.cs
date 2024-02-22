using FluentValidation;
using Obilet.Core.Models.BusJourneys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Core.Models.Validations
{
    public class GetBusJourneyValidator : AbstractValidator<BusJourneyFilterModel>
    {
        public GetBusJourneyValidator()
        {
            RuleFor(s => s.OriginId).NotEqual(s => s.DestinationId).WithMessage("Nereden ve Nereye konumları aynı olamaz");
            RuleFor(s => s.DepartureDate).GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("Tarih en erken bugün olabilir");
        }
    }
}
