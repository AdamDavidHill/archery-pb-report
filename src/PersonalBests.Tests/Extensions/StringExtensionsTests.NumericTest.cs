using FluentAssertions;
using PersonalBests.Extensions;

namespace PersonalBests.Tests.Extensions;

public partial class StringExtensionsTests
{
    [Theory]
    [InlineData("123", 123)]
    [InlineData("abc123xyz", 123)]
    [InlineData("The score is 4567", 4567)]
    [InlineData("No digits here!", 0)] // Assuming the behavior for strings without digits is to return 0
    public void NumericValue_GivenString_ReturnsNumericValue(string input, int expectedValue)
    {
        var result = input.NumericValue();

        result.Should().Be(expectedValue);
    }
}
