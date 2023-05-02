namespace Reporting.Models
{
    internal class HotelInfoDto
    {
        public HotelDto Hotel { get; set; }

        public HotelRateDto[] HotelRates { get; set; }
    }
}
