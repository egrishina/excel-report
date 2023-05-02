using System.Text.Json.Serialization;

namespace Reporting.Models
{
    internal class HotelRateDto
    {
        public int Adults { get; set; }

        [JsonPropertyName("los")]
        public int StayLength { get; set; }

        public Price Price { get; set; }

        public string RateDescription { get; set; }

        [JsonPropertyName("rateID")]
        public string RateId { get; set; }

        public string RateName { get; set; }

        public RateTag[] RateTags { get; set; }

        public DateTime TargetDay { get; set; }
    }
}
