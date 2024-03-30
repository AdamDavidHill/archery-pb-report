using FluentAssertions;
using PersonalBests.Extensions;
using System.Text;

namespace PersonalBests.Tests.Extensions;

public partial class IEnumerableExtensionsTests
{
    public static IEnumerable<object[]> CsvStringTestData
        => new List<object[]>
        {
            new object[]
            {
                new List<dynamic> { new { Header1 = "Value1", Header2 = "Value2" } },
                new[] { "Header1,Header2", "Value1,Value2" }
            }
        };

    [Theory]
    [MemberData(nameof(CsvStringTestData))]
    public async Task ToCsvString_GivenCollection_ReturnsCsvString(IEnumerable<dynamic> records, string[] expectedLines)
    {
        var csvString = await records.ToCsvString();
        var resultLines = csvString.Split('\n');

        for (int i = 0; i < expectedLines.Length; i++)
        {
            resultLines[i].Trim().Should().Be(expectedLines[i]);
        }
    }

    [Fact]
    public async Task ToCsvBytes_GivenCollection_ReturnsCsvBytes()
    {
        var records = new List<dynamic>
        {
            new { Header1 = "Value1", Header2 = "Value2" }
        };

        var expectedCsvString = await records.ToCsvString();
        var expectedBytes = Encoding.UTF8.GetBytes(expectedCsvString);
        var csvBytes = await records.ToCsvBytes();
        csvBytes.Should().BeEquivalentTo(expectedBytes);
    }

    [Fact]
    public async Task ToCsvFile_GivenCollection_WritesCsvFile()
    {
        var filePath = Path.GetTempFileName();
        var records = new List<dynamic>
        {
            new { Header1 = "Value1", Header2 = "Value2" }
        };
        await records.ToCsvFile(filePath);
        var fileContents = await File.ReadAllTextAsync(filePath, Encoding.UTF8);
        var expectedCsvString = await records.ToCsvString();
        fileContents.Should().Be(expectedCsvString);
        File.Delete(filePath);
    }
}
