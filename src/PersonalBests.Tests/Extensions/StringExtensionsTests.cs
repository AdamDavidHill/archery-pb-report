using FluentAssertions;
using PersonalBests.Extensions;

namespace PersonalBests.Tests.Extensions;

public partial class StringExtensionsTests
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
    public void SimplifiedAgeGroup_GivenVariousInputs_ReturnsExpectedOutput(string input, string expectedOutput)
    {
        var result = input.SimplifiedAgeGroup();

        result.Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData("Progress 10m", "Progress")]
    [InlineData("Progress", "Progress")]
    [InlineData("Portsmouth", "Portsmouth")]
    public void SimplifiedRound_GivenString_ReturnsSimplifiedRound(string input, string expectedResult)
    {
        var result = input.SimplifiedRound();

        result.Should().Be(expectedResult);
    }
}
