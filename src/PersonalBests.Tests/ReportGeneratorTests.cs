using FluentAssertions;
using PersonalBests.Models;
using PersonalBests.Services;
using PersonalBests.Tests.Mocks;
using PersonalBests.Tests.TestData;
using PersonalBests.Extensions;

namespace PersonalBests.Tests;

public class PersonalBestTests
{
    private ReportGenerator CreateReportGenerator(List<ScoreRecord> dataToProvide) => new ReportGenerator(new MockScoreProvider(dataToProvide));

    [Fact]
    public async Task TotalCountAsExpected()
        => (await CreateReportGenerator(Data.AllScores).Generate())
            .Count()
            .Should()
            .Be(16);

    [Fact]
    public async Task CsvFileProduced()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "test.csv");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        var data = await CreateReportGenerator(Data.AllScores).Generate();
        await data.ToCsvFile(path);
        File.Exists(path).Should().BeTrue();
        File.Delete(path);
    }
}
