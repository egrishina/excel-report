using Reporting.Converters;

namespace Reporting.Tests
{
    public class GeneratorTests
    {
        private Generator _generator;
        private string _outputPath;

        [SetUp]
        public void Setup()
        {
            _generator = new Generator();
            _outputPath = Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    @"..\..\..\..\..\src\Reporting\Resources\Report_test.xlsx"));
        }

        [Test]
        public void FileIsCreated()
        {
            _generator.GenerateExcelReport(Constants.JsonStringWithFullData, _outputPath);
            Assert.That(_outputPath, Does.Exist);
        }

        [Test]
        public void RawDataIsNull_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentNullException>(
                () => _generator.GenerateExcelReport(null, _outputPath));
            Assert.That(exception.ParamName, Is.EqualTo("rawData"));
        }

        [Test]
        public void OutputPathIsNull_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentNullException>(
                () => _generator.GenerateExcelReport(Constants.JsonStringWithFullData, null));
            Assert.That(exception.ParamName, Is.EqualTo("outputPath"));
        }

        [Test]
        public void OutputPathIsNotExcelFile_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => _generator.GenerateExcelReport(Constants.JsonStringWithFullData, "Report"));
            Assert.That(exception.ParamName, Is.EqualTo("outputPath"));
            Assert.That(exception.Message, Is.EqualTo("The file extension is invalid. (Parameter 'outputPath')"));
        }

        [Test]
        public void RawDataIsEmpty_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => _generator.GenerateExcelReport("{}", _outputPath));
        }

        [Test]
        public void RawDataIsInvalid_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => _generator.GenerateExcelReport(Constants.JsonStringWithInvalidData, _outputPath));
        }
    }
}