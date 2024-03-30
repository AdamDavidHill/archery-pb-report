using FluentAssertions;
using PersonalBests.Enums;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class PersonalBestExtensionsTests
{
    [Theory]
    [MemberData(nameof(GetRankTypeTestData))]
    public void GetRankType_GivenIndexedScores_ReturnsCorrectRankType(IEnumerable<PersonalBest> scores, int index, RankType expectedRankType)
    {
        var indexedScores = scores.Index().ToList();
        indexedScores.GetRankType(indexedScores[index], index).Should().Be(expectedRankType);
    }

    public static IEnumerable<object[]> GetRankTypeTestData()
    {
        yield return new object[]
        {
            new List<PersonalBest>
            {
                new() { HighestScore = 100 },
                new() { HighestScore = 90 },
                new() { HighestScore = 90 },
                new() { HighestScore = 80 }
            },
            1, // Index of first score of 90
            RankType.Joint
        };

        yield return new object[]
        {
            new List<PersonalBest>
            {
                new() { HighestScore = 100 },
                new() { HighestScore = 100 },
                new() { HighestScore = 90 },
                new() { HighestScore = 80 }
            },
            0, // Index of first score of 100
            RankType.Joint
        };

        yield return new object[]
        {
            new List<PersonalBest>
            {
                new() { HighestScore = 100 },
                new() { HighestScore = 90 },
                new() { HighestScore = 80 }
            },
            2, // Index of score 80
            RankType.Exclusive
        };
    }
}
