using FluentAssertions;
using PersonalBests.Extensions;

namespace PersonalBests.Tests.Extensions;

public partial class IEnumerableExtensionsTests
{
    [Fact]
    public void Aggregate_WithEmptySource_ReturnsEmptyList()
        => Enumerable.Empty<int>().Aggregate<int, int>((acc, current) => acc).Should().BeEmpty();

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, new[] { 1, 3, 6 })]
    public void Aggregate_WithIntSource_AggregatesCorrectly(IEnumerable<int> source, IEnumerable<int> expected)
    {
        var result = source.Aggregate<int, int>((acc, current) 
            =>
            {
                acc.Add(acc.Any()
                    ? acc.Last() + current
                    : current);
    
                return acc;
            });

        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Theory]
    [MemberData(nameof(StringAggregationTestData))]
    public void Aggregate_WithStringSource_AggregatesCorrectly(IEnumerable<string> source, IEnumerable<string> expected)
    {
        var result = source.Aggregate<string, string>((acc, current) 
            =>
            {
                acc.Add(current.ToUpper());

                return acc;
            });

        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    public static IEnumerable<object[]> StringAggregationTestData()
    {
        yield return new object[] { new[] { "a", "b", "c" }, new[] { "A", "B", "C" } };
    }
}
