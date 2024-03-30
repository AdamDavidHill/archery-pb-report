using FluentAssertions;
using PersonalBests.Enums;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class RankedPersonalBestExtensionsTests
{
    [Fact]
    public void Differential_GivenCurrentAndPreviousLists_ReturnsCorrectReportRows()
    {
        var currentList = new List<RankedPersonalBest>
        {
            new()
            {
                Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" },
                HighestScore = 320,
                MemberName = "Alice",
                Rank = 1,
                RankType = RankType.Exclusive
            },
            new()
            {
                Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" },
                HighestScore = 319,
                MemberName = "Anne",
                Rank = 2,
                RankType = RankType.Exclusive
            },
            new()
            {
                Category = new() { Round = "FITA", Class = "Compound", AgeGroup = "Open" },
                HighestScore = 305,
                MemberName = "Charlie",
                Rank = 1,
                RankType = RankType.Exclusive
            }
        };

        var previousList = new List<RankedPersonalBest>
        {
            new()
            {
                Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" },
                HighestScore = 300,
                MemberName = "Alice",
                Rank = 2,
                RankType = RankType.Exclusive
            },
            new()
            {
                Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" },
                HighestScore = 310,
                MemberName = "Anne",
                Rank = 1,
                RankType = RankType.Exclusive
            },
            new()
            {
                Category = new() { Round = "FITA", Class = "Compound", AgeGroup = "Open" },
                HighestScore = 315,
                MemberName = "Charlie",
                Rank = 1,
                RankType = RankType.Exclusive
            }
        };

        var reportRows = currentList.Differential(previousList).ToList();

        reportRows.Should().ContainEquivalentOf(new ReportRow
        {
            Round = "Portsmouth",
            Class = "Recurve",
            AgeGroup = "Open",
            HighestScore = 320,
            Name = "Alice",
            Rank = 1,
            RankType = RankType.Exclusive,
            Status = ScoreStatus.Improved,
            Movement = RankingMovement.Up,
            Moved = 1
        });

        reportRows.Should().ContainEquivalentOf(new ReportRow
        {
            Round = "Portsmouth",
            Class = "Recurve",
            AgeGroup = "Open",
            HighestScore = 319,
            Name = "Anne",
            Rank = 2,
            RankType = RankType.Exclusive,
            Status = ScoreStatus.Improved,
            Movement = RankingMovement.Down,
            Moved = -1
        });

        reportRows.Should().ContainEquivalentOf(new ReportRow
        {
            Round = "FITA",
            Class = "Compound",
            AgeGroup = "Open",
            HighestScore = 315,
            Name = "Charlie",
            Rank = 1,
            RankType = RankType.Exclusive,
            Status = ScoreStatus.Unchanged,
            Movement = RankingMovement.Static,
            Moved = 0
        });
    }
}
