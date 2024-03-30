using FluentAssertions;
using PersonalBests.Enums;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class RankedPersonalBestExtensionsTests
{
    [Theory]
    [InlineData(1, 3, RankingMovement.Up)] // Improved position
    [InlineData(4, 1, RankingMovement.Down)] // Dropped position
    [InlineData(2, 2, RankingMovement.Static)] // Unchanged position
    [InlineData(5, null, RankingMovement.New)] // New entry
    public void GetRankingMovement_GivenCurrentAndPreviousRanks_ReturnsCorrectMovement(int currentRank, int? previousRank, RankingMovement expectedMovement)
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

        var movement = current.GetRankingMovement(prev);

        movement.Should().Be(expectedMovement);
    }
}
