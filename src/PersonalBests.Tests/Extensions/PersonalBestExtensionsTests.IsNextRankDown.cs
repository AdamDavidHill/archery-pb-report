using FluentAssertions;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class PersonalBestExtensionsTests
{
    [Theory]
    [MemberData(nameof(IsNextRankDownTestData))]
    public void IsNextRankDown_GivenIndexedScoresAndIndex_ReturnsExpectedResult(IEnumerable<PersonalBest> scores, int index, bool expectedResult)
    {
        var indexedScores = scores.Index().ToList();
        indexedScores.IsNextRankDown(indexedScores[index], index).Should().Be(expectedResult);
    }

    public static IEnumerable<object[]> IsNextRankDownTestData()
    {
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
            false // It is not a next rank down because the previous score is the same
        };

        yield return new object[]
        {
            new List<PersonalBest>
            {
                new() { HighestScore = 100 },
                new() { HighestScore = 90 },
                new() { HighestScore = 80 },
                new() { HighestScore = 70 }
            },
            2, // Index of score 80
            true // It is a next rank down because the previous score is different
        };

        yield return new object[]
        {
            new List<PersonalBest>
            {
                new() { HighestScore = 100 }
            },
            0, // Index of first (and only) score
            true // It is the first rank
        };
    }
}
