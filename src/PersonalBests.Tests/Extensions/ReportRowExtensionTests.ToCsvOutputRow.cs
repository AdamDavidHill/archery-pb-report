using FluentAssertions;
using PersonalBests.Enums;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class ReportRowExtensionsTests
{
    [Fact]
    public void ToCsvOutputRow_GivenReportRow_ReturnsCorrectCsvOutputRow()
    {
        var reportRow = new ReportRow
        {
            Round = "Portsmouth",
            Class = "Compound",
            AgeGroup = "Men 50+",
            Rank = 1,
            RankType = RankType.Joint,
            Name = "John Doe",
            HighestScore = 525,
            Status = ScoreStatus.Improved,
            Movement = RankingMovement.Up,
            Moved = 1
        };

        var expectedCsvOutputRow = new CsvOutputRow
        {
            Category = "Men 50+ - Compound - Portsmouth",
            Position = "1==",
            Name = "John Doe",
            Score = 525,
            Improved = true,
            Move = "↑1"
        };

        var csvOutputRow = reportRow.ToCsvOutputRow();

        csvOutputRow.Should().BeEquivalentTo(expectedCsvOutputRow);
    }
}
