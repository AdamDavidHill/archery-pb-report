using FluentAssertions;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class RankedPersonalBestExtensionsTests
{
    [Fact]
    public void Match_WithMatchingEntry_ReturnsCorrectMatch()
    {
        var current = new RankedPersonalBest
        {
            Category = new() { Round = "Portsmouth", Class = "Compound", AgeGroup = "Men 50+" },
            HighestScore = 300,
            MemberName = "Bob"
        };

        var previousList = new List<RankedPersonalBest>
        {
            new()
            {
                Category = new() { Round = "Portsmouth", Class = "Compound", AgeGroup = "Men 50+" },
                HighestScore = 280,
                MemberName = "Bob"
            },
            new()
            {
                Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" },
                HighestScore = 310,
                MemberName = "Alice"
            }
        };

        var match = previousList.Match(current);

        match.Should().NotBeNull();
        match!.MemberName.Should().Be("Bob");
        match.HighestScore.Should().Be(280);
    }

    [Fact]
    public void Match_WithoutMatchingEntry_ReturnsNull()
    {
        var current = new RankedPersonalBest
        {
            Category = new() { Round = "FITA", Class = "Barebow", AgeGroup = "Open" },
            HighestScore = 320,
            MemberName = "Charlie"
        };

        var previousList = new List<RankedPersonalBest>
        {
            new()
            {
                Category = new() { Round = "Portsmouth", Class = "Compound", AgeGroup = "Men 50+" },
                HighestScore = 280,
                MemberName = "Bob"
            },
            new()
            {
                Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" },
                HighestScore = 310,
                MemberName = "Alice"
            }
        };

        var match = previousList.Match(current);

        match.Should().BeNull();
    }
}
