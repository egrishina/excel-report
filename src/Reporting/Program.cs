using Reporting.Converters;

internal class Program
{
    private static void Main(string[] args)
    {
        var inputPath = Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    @"..\..\..\Resources\task 2 - hotelrates.json"));

        if (!File.Exists(inputPath))
        {
            throw new FileNotFoundException(inputPath);
        }

        var jsonString = File.ReadAllText(inputPath);

        var generator = new Generator();
        var outputPath = Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    @"..\..\..\Resources\Report.xlsx"));

        generator.GenerateExcelReport(jsonString, outputPath);
    }
}