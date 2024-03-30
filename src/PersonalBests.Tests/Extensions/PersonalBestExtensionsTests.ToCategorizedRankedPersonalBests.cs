using FluentAssertions;
using PersonalBests.Enums;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class PersonalBestExtensionsTests
{
    [Fact]
    public void ToCategorizedRankedPersonalBests_GivenScores_CategorizesAndRanksCorrectly()
    {
        var scores = new List<PersonalBest>
        {
            new() { MemberName = "Alice", HighestScore = 300, Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" } },
            new() { MemberName = "Bob", HighestScore = 200, Category = new() { Round = "Portsmouth", Class = "Barebow", AgeGroup = "Men 50+" } },
            new() { MemberName = "Charlie", HighestScore = 200, Category = new() { Round = "FITA", Class = "Compound", AgeGroup = "Open" } },
            new() { MemberName = "Dana", HighestScore = 100, Category = new() { Round = "FITA", Class = "Compound", AgeGroup = "Open" } },
            new() { MemberName = "Eve", HighestScore = 250, Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" } },
            new() { MemberName = "Frank", HighestScore = 150, Category = new() { Round = "Portsmouth", Class = "Barebow", AgeGroup = "Men 50+" } }
        };

        var categorizedRankedPersonalBests = scores.ToCategorizedRankedPersonalBests();
        categorizedRankedPersonalBests.Count.Should().Be(6);

        var recurveOpen = categorizedRankedPersonalBests.FindAll(i => i.Category.Round == "Portsmouth" && i.Category.Class == "Recurve" && i.Category.AgeGroup == "Open");
        recurveOpen.Should().HaveCount(2);
        recurveOpen.Should().ContainSingle(i => i.MemberName == "Alice" && i.Rank == 1 && i.RankType == RankType.Exclusive);
        recurveOpen.Should().ContainSingle(i => i.MemberName == "Eve" && i.Rank == 2 && i.RankType == RankType.Exclusive);

        var barebowMen50Plus = categorizedRankedPersonalBests.FindAll(i => i.Category.Round == "Portsmouth" && i.Category.Class == "Barebow" && i.Category.AgeGroup == "Men 50+");
        barebowMen50Plus.Should().HaveCount(2);
        barebowMen50Plus.Should().BeInDescendingOrder(i => i.HighestScore);
        barebowMen50Plus.First().Rank.Should().Be(1);
        barebowMen50Plus.Last().Rank.Should().Be(2);

        var compoundOpen = categorizedRankedPersonalBests.FindAll(i => i.Category.Round == "FITA" && i.Category.Class == "Compound" && i.Category.AgeGroup == "Open");
        compoundOpen.Should().HaveCount(2);
        compoundOpen.Should().BeInDescendingOrder(i => i.HighestScore);
        compoundOpen.First().Rank.Should().Be(1);
        compoundOpen.Last().Rank.Should().Be(2);
    }
}
