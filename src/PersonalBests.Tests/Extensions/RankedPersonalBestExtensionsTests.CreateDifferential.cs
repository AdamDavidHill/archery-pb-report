using FluentAssertions;
using PersonalBests.Enums;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class RankedPersonalBestExtensionsTests
{
    [Fact]
    public void CreateDifferential_GivenCurrentAndPrevious_ReturnsCorrectDifferential()
    {
        var current = new RankedPersonalBest
        {
            Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" },
            HighestScore = 320,
            MemberName = "Alice",
            Rank = 1,
            RankType = RankType.Exclusive
        };

        var prev = new RankedPersonalBest
        {
            Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" },
            HighestScore = 300,
            MemberName = "Alice",
            Rank = 2,
            RankType = RankType.Exclusive
        };

        var expectedDifferential = new DifferentialRankedPersonalBest
        {
            Category = current.Category,
            HighestScore = current.HighestScore,
            MemberName = current.MemberName,
            Rank = current.Rank,
            RankType = current.RankType,
            Status = ScoreStatus.Improved,
            Movement = RankingMovement.Up,
            Moved = prev.Rank - current.Rank
        };

        var differential = current.CreateDifferential(prev);
        differential.Should().BeEquivalentTo(expectedDifferential, options => options.ComparingByMembers<DifferentialRankedPersonalBest>());
    }

    [Fact]
    public void CreateDifferential_WithNoPrevious_ReturnsCorrectNewDifferential()
    {
        var current = new RankedPersonalBest
        {
            Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" },
            HighestScore = 320,
            MemberName = "Alice",
            Rank = 1,
            RankType = RankType.Exclusive
        };

        var expectedDifferential = new DifferentialRankedPersonalBest
        {
            Category = current.Category,
            HighestScore = current.HighestScore,
            MemberName = current.MemberName,
            Rank = current.Rank,
            RankType = current.RankType,
            Status = ScoreStatus.New,
            Movement = RankingMovement.New,
            Moved = 0
        };

        var differential = current.CreateDifferential(null);
        differential.Should().BeEquivalentTo(expectedDifferential, options => options.ComparingByMembers<DifferentialRankedPersonalBest>());
    }
}
