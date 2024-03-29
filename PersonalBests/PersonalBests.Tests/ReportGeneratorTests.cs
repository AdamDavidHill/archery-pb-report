using FluentAssertions;
using PersonalBests.Models;
using PersonalBests.Services;
using PersonalBests.Tests.Mocks;
using PersonalBests.Tests.TestData;

namespace PersonalBests.Tests;

public class PersonalBestTests
{
    private ReportGenerator CreateReportGenerator(List<ScoreRecord> dataToProvide) => new ReportGenerator(new MockScoreProvider(dataToProvide));

    [Fact]
    public void TotalCount_AsExpected()
        => CreateReportGenerator(Data.AllScores)
            .Generate()
            .Count()
            .Should()
            .Be(16);
}
