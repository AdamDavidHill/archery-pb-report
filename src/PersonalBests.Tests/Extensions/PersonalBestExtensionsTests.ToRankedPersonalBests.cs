using FluentAssertions;
using PersonalBests.Enums;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class PersonalBestExtensionsTests
{
    [Fact]
    public void ToRankedPersonalBests_GivenScores_AssignsCorrectRankAndRankType()
    {
        var category = new Category { Round = "Portsmouth", Class = "Barebow", AgeGroup = "Men 50+" };
        var scores = new List<PersonalBest>
        {
            new() { MemberName = "Andy", HighestScore = 300, Category = category },
            new() { MemberName = "Bob", HighestScore = 200, Category = category },
            new() { MemberName = "Charlie", HighestScore = 200, Category = category },
            new() { MemberName = "Dana", HighestScore = 100, Category = category }
        };

        var expectedRankedPersonalBests = new List<RankedPersonalBest>
        {
            new() { MemberName = "Andy", HighestScore = 300, Rank = 1, RankType = RankType.Exclusive, Category = category },
            new() { MemberName = "Bob", HighestScore = 200, Rank = 2, RankType = RankType.Joint, Category = category },
            new() { MemberName = "Charlie", HighestScore = 200, Rank = 2, RankType = RankType.Joint, Category = category },
            new() { MemberName = "Dana", HighestScore = 100, Rank = 4, RankType = RankType.Exclusive, Category = category }
        };

        var rankedPersonalBests = scores.ToRankedPersonalBests();
        rankedPersonalBests.Should().BeEquivalentTo(expectedRankedPersonalBests, options => options.ComparingByMembers<RankedPersonalBest>());
    }
}
