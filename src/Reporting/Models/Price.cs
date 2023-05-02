namespace Reporting.Models
{
    internal struct Price
    {
        public Currency Currency { get; set; }

        public double NumericFloat { get; set; }

        public int NumericInteger { get; set; }
    }
}
