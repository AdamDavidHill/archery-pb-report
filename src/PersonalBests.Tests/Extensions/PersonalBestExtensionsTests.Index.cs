using FluentAssertions;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class PersonalBestExtensionsTests
{
    [Fact]
    public void Index_GivenCollection_AssignsCorrectIndexes()
    {
        var scores = new List<PersonalBest>
        {
            new() { HighestScore = 300 },
            new() { HighestScore = 200 },
            new() { HighestScore = 100 }
        };

        var indexedScores = scores.Index().ToList();

        for (int i = 0; i < indexedScores.Count; i++)
        {
            indexedScores[i].ZeroBasedIndex.Should().Be(i);
            indexedScores[i].Score.Should().Be(scores[i]);
        }
    }
}
