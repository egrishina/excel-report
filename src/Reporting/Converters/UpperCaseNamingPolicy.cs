using System.Text.Json;

namespace Reporting.Converters
{
    internal class UpperCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToUpper();
    }
}
