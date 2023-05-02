using Reporting.Models;
using SpreadsheetLight;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reporting.Converters
{
    public class Generator
    {
        public void GenerateExcelReport(string rawData, string outputPath)
        {
            if (rawData is null)
            {
                throw new ArgumentNullException(nameof(rawData));
            }

            if (outputPath is null)
            {
                throw new ArgumentNullException(nameof(outputPath));
            }

            if (!outputPath.EndsWith(".xlsx"))
            {
                throw new ArgumentException("The file extension is invalid.", nameof(outputPath));
            }

            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            var hotelInfo = DeserializeJsonString(rawData);
            var dataTable = CreateDataTableWithHotelInfo(hotelInfo);
            ExportDataToExcel(dataTable, outputPath);
        }

        private HotelInfoDto DeserializeJsonString(string jsonString)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters =
                {
                    new JsonStringEnumConverter(new UpperCaseNamingPolicy())
                }
            };

            var hotelInfo = JsonSerializer.Deserialize<HotelInfoDto>(jsonString, options);
            return hotelInfo;
        }

        private DataTable CreateDataTableWithHotelInfo(HotelInfoDto hotelInfo)
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add("ARRIVAL_DATE", typeof(DateTime));
            dataTable.Columns.Add("DEPARTURE_DATE", typeof(DateTime));
            dataTable.Columns.Add("PRICE", typeof(double));
            dataTable.Columns.Add("CURRENCY", typeof(string));
            dataTable.Columns.Add("RATE_NAME", typeof(string));
            dataTable.Columns.Add("ADULTS", typeof(int));
            dataTable.Columns.Add("BREAKFAST_INCLUDED", typeof(int));

            if (hotelInfo is null || hotelInfo.HotelRates is null)
            {
                return dataTable;
            }

            foreach (var hotelRate in hotelInfo.HotelRates)
            {
                var breakfastIncluded = hotelRate.RateTags?
                    .Where(tag => tag.Name == "breakfast")
                    .Cast<RateTag?>()
                    .FirstOrDefault()?
                    .Shape
                    ?? false;

                dataTable.Rows.Add(
                    hotelRate.TargetDay,
                    hotelRate.TargetDay.AddDays(hotelRate.StayLength),
                    hotelRate.Price.NumericFloat,
                    hotelRate.Price.Currency.ToString(),
                    hotelRate.RateName,
                    hotelRate.Adults,
                    Convert.ToInt32(breakfastIncluded)
                );
            }

            return dataTable;
        }

        private void ExportDataToExcel(DataTable dataTable, string outputPath)
        {
            using var document = new SLDocument();

            var startRowIndex = 1;
            var startColumnIndex = 1;
            document.ImportDataTable(startRowIndex, startColumnIndex, dataTable, true);

            var style = document.CreateStyle();
            style.FormatCode = "dd.mm.yy";
            document.SetColumnStyle(1, style);
            document.SetColumnStyle(2, style);

            style.FormatCode = "#,##0.00";
            document.SetColumnStyle(3, style);

            var endRowIndex = startRowIndex + dataTable.Rows.Count;
            var endColumnIndex = startColumnIndex + dataTable.Columns.Count - 1;
            var table = document.CreateTable(startRowIndex, startColumnIndex, endRowIndex, endColumnIndex);
            table.SetTableStyle(SLTableStyleTypeValues.Light2);

            document.InsertTable(table);
            document.AutoFitColumn(startColumnIndex, endColumnIndex);
            document.SaveAs(outputPath);
        }
    }
}
