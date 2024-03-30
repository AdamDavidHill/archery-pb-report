using FluentAssertions;
using PersonalBests.Enums;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class RankedPersonalBestExtensionsTests
{
    [Theory]
    [InlineData(300, 280, ScoreStatus.Improved)] // Score improved
    [InlineData(250, 250, ScoreStatus.Unchanged)] // Score unchanged
    [InlineData(260, null, ScoreStatus.New)] // New score, no previous
    public void GetStatus_GivenCurrentAndPreviousScores_ReturnsCorrectStatus(int currentScore, int? previousScore, ScoreStatus expectedStatus)
    {
        var current = new RankedPersonalBest
        {
            HighestScore = currentScore,
            Category = new Category { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" },
            MemberName = "Alice"
        };

        RankedPersonalBest? prev = previousScore.HasValue ? new RankedPersonalBest
        {
            HighestScore = previousScore.Value,
            Category = new Category { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" },
            MemberName = "Alice"
        } : null;

        var status = current.GetStatus(prev);

        status.Should().Be(expectedStatus);
    }
}
