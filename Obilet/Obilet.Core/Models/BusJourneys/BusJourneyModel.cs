using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obilet.Core.Models.BusJourneys
{
    public class BusJourneyModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("partner-id")]
        public int PartnerId { get; set; }

        [JsonPropertyName("partner-name")]
        public string PartnerName { get; set; }

        [JsonPropertyName("route-id")]
        public int RouteId { get; set; }

        [JsonPropertyName("bus-type")]
        public string BusType { get; set; }

        [JsonPropertyName("bus-type-name")]
        public string BusTypeName { get; set; }

        [JsonPropertyName("total-seats")]
        public int TotalSeats { get; set; }

        [JsonPropertyName("available-seats")]
        public int AvailableSeats { get; set; }

        [JsonPropertyName("journey")]
        public JourneyModel JourneyDetail { get; set; }
        [JsonPropertyName("features")]
        public IList<JourneyFeatureModel> Features { get; set; }
        [JsonPropertyName("origin-location")]
        public string OriginLocation { get; set; }
        [JsonPropertyName("destination-location")]
        public string DestinationLocation { get; set; }
        [JsonPropertyName("is-active")]
        public bool IsActive { get; set; }
        [JsonPropertyName("origin-location-id")]
        public int OriginLocationId { get; set; }
        [JsonPropertyName("destination-location-id")]
        public int DestinationLocationId { get; set; }
        [JsonPropertyName("is-promoted")]
        public bool IsPromoted { get; set; }
        [JsonPropertyName("cancellation-offset")]
        public int? CancellationOffset { get; set; }
        [JsonPropertyName("has-bus-shuttle")]
        public bool HasBusShuttle { get; set; }
        [JsonPropertyName("disable-sales-without-gov-id")]
        public bool DisableSalesWithoutGovId { get; set; }
        [JsonPropertyName("display-offset")]
        public TimeSpan DisplayOffset { get; set; }
        [JsonPropertyName("partner-rating")]
        public double? PartnerRating { get; set; }

        [JsonPropertyName("has-dynamic-pricing")]
        public bool HasDynamicPricing { get; set; }

        [JsonPropertyName("disable-sales-without-hes-code")]
        public bool DisableSalesWithoutHesCode { get; set; }

        [JsonPropertyName("disable-single-seat-selection")]
        public bool DisableSingleSeatSelection { get; set; }

        [JsonPropertyName("change-offset")]
        public int ChangeOffset { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("display-coupon-code-input")]
        public bool DisplayCouponCodeInput { get; set; }

        [JsonPropertyName("disable-sales-without-date-of-birth")]
        public bool DisableSalesWithoutDateOfBirth { get; set; }

        [JsonPropertyName("open-offset")]
        public int? OpenOffset { get; set; }

        [JsonPropertyName("display-buffer")]
        public string DisplayBuffer { get; set; }
    }
}
