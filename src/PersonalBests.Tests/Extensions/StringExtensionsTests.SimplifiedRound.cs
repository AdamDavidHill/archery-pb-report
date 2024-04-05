using FluentAssertions;
using PersonalBests.Extensions;

namespace PersonalBests.Tests.Extensions;

public partial class StringExtensionsTests
{
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
