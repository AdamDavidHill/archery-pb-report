using FluentAssertions;
using PersonalBests.Enums;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class PersonalBestExtensionsTests
{

    [Fact]
    public void ToSegregatedCategorizedRankedPersonalBests_GivenScores_SegregatesAndRanksCorrectly()
    {
        var scores = new List<PersonalBest>
        {
            new() { MemberName = "Alice", HighestScore = 300, Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" } },
            new() { MemberName = "Bob", HighestScore = 200, Category = new() { Round = "Portsmouth", Class = "Barebow", AgeGroup = "Men 50+" } },
            new() { MemberName = "Charlie", HighestScore = 200, Category = new() { Round = "FITA", Class = "Compound", AgeGroup = "Open" } },
            new() { MemberName = "Dana", HighestScore = 100, Category = new() { Round = "FITA", Class = "Compound", AgeGroup = "Open" } },
            new() { MemberName = "Eve", HighestScore = 250, Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" } }
        };

        var segregatedRankedPersonalBests = scores.ToSegregatedCategorizedRankedPersonalBests().ToList();
        segregatedRankedPersonalBests.Count.Should().Be(3);

        segregatedRankedPersonalBests.ForEach(categoryList =>
        {
            categoryList.Should().BeInDescendingOrder(i => i.HighestScore);
            categoryList.First().Rank.Should().Be(1);
            categoryList.First().RankType.Should().Be(RankType.Exclusive);

            for (int i = 1; i < categoryList.Count; i++)
            {
                if (categoryList[i].HighestScore == categoryList[i - 1].HighestScore)
                {
                    categoryList[i].RankType.Should().Be(RankType.Joint);
                    categoryList[i].Rank.Should().Be(categoryList[i - 1].Rank);
                }
                else
                {
                    categoryList[i].RankType.Should().Be(RankType.Exclusive);
                    categoryList[i].Rank.Should().Be(i + 1);
                }
            }
        });
    }
}
