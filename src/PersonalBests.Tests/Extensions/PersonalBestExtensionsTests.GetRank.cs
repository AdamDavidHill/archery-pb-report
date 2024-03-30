using FluentAssertions;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class PersonalBestExtensionsTests
{
    [Theory]
    [MemberData(nameof(GetRankTestData))]
    public void GetRank_GivenIndexedScoresAndIndex_ReturnsCorrectRank(IEnumerable<PersonalBest> scores, int index, int expectedRank)
    {
        var indexedScores = scores.Index().ToList();
        indexedScores.GetRank(indexedScores[index], index).Should().Be(expectedRank);
    }

    public static IEnumerable<object[]> GetRankTestData()
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
            2, // Index of second score of 90
            2  // Rank is 2 because it's the same score as the previous
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
            1, // Index of second score of 100
            1  // Rank is 1 (same as previous) because it's the same score as the first
        };

        yield return new object[]
        {
            new List<PersonalBest>
            {
                new PersonalBest { HighestScore = 100 },
                new PersonalBest { HighestScore = 90 },
                new PersonalBest { HighestScore = 80 },
                new PersonalBest { HighestScore = 70 }
            },
            3, // Index of score 70
            4  // Rank is 4 because it's the fourth highest score
        };
    }
}
