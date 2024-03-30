using FluentAssertions;
using PersonalBests.Extensions;

namespace PersonalBests.Tests.Extensions;

public class DateTimeExtensionsTests
{
    [Theory]
    [InlineData("2023-03-15", "2023-03-01")]
    [InlineData("2024-02-28", "2024-02-01")]
    public void FirstDayOfMonth_GivenDate_ReturnsFirstDay(string inputDate, string expectedDate)
        => DateTime.Parse(inputDate).FirstDayOfMonth().Should().Be(DateTime.Parse(expectedDate));
}
