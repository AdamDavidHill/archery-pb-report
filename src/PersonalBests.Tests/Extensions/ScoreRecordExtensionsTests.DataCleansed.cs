using FluentAssertions;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class ScoreRecordExtensionsTests
{
    [Theory]
    [InlineData("Ladies", "Women")]
    [InlineData("Ladies U12", "Juniors")]
    [InlineData("Ladies 50+", "Women")]
    [InlineData("Gentlemen", "Men")]
    [InlineData("Gentlemen U18", "Juniors")]
    [InlineData("Gentlemen 50+", "Men")]
    [InlineData("gentlemen", "Men")]
    [InlineData("Men", "Men")]
    [InlineData("Men 50+", "Men")]
    [InlineData("Men U18", "Juniors")]
    public void DataCleansed_GivenScoreRecordWithVariousAgeGroups_ReturnsScoreRecordWithSimplifiedAgeGroup(string originalAgeGroup, string expectedSimplifiedAgeGroup)
    {
        var score = new ScoreRecord
        {
            MemberName = "John Doe",
            Round = "Portsmouth",
            Class = "Compound",
            AgeGroup = originalAgeGroup,
            Score = 300
        };

        var simplifiedScore = score.DataCleansed();

        simplifiedScore.AgeGroup.Should().Be(expectedSimplifiedAgeGroup);
    }

    [Theory]
    [InlineData("Men 50+", "Senior", "Portsmouth Progress", "Men", "Progress")]
    [InlineData("Women", "Open", "FITA", "Women", "FITA")]
    public void DataCleansed_GivenScoreRecord_ReturnsCleansedData(
        string initialAgeGroup, string initialClass, string initialRound,
        string expectedAgeGroup, string expectedRound)
    {
        var score = new ScoreRecord
        {
            AgeGroup = initialAgeGroup,
            Class = initialClass,
            Round = initialRound,
            Score = 300,
            MemberName = "Jane Doe"
        };

        var cleansedScore = score.DataCleansed();

        cleansedScore.AgeGroup.Should().Be(expectedAgeGroup);
        cleansedScore.Round.Should().Be(expectedRound);
    }
}
