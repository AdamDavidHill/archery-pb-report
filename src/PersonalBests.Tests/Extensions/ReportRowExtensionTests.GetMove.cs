using FluentAssertions;
using PersonalBests.Enums;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class ReportRowExtensionsTests
{
    [Theory]
    [InlineData(RankingMovement.New, 0, "NEW")]
    [InlineData(RankingMovement.Up, 1, "↑1")]
    [InlineData(RankingMovement.Down, 2, "↓2")]
    [InlineData(RankingMovement.Static, 0, "-")]
    public void GetMove_GivenReportRow_ReturnsCorrectMove(RankingMovement movement, int moved, string expectedMove)
    {
        var reportRow = new ReportRow
        {
            Movement = movement,
            Moved = moved
        };

        var move = reportRow.GetMove();

        move.Should().Be(expectedMove);
    }
}
