using FluentAssertions;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class RankedPersonalBestExtensionsTests
{
    [Theory]
    [InlineData(3, 1, 2)] // Moved up
    [InlineData(1, 4, -3)]  // Moved down
    [InlineData(2, 2, 0)]  // No movement
    [InlineData(null, 5, 0)] // New entry, no previous rank
    public void GetPositionsMoved_GivenCurrentAndPreviousRank_ReturnsCorrectMovement(int? previousRank, int currentRank, int expectedMovement)
    {
        var current = new RankedPersonalBest
        {
            Rank = currentRank,
            Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" },
            HighestScore = 300,
            MemberName = "Alice"
        };

        RankedPersonalBest? prev = previousRank.HasValue ? new()
        {
            Rank = previousRank.Value,
            Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" },
            HighestScore = 280,
            MemberName = "Alice"
        } : null;

        var movement = current.GetPositionsMoved(prev);

        movement.Should().Be(expectedMovement);
    }
}
