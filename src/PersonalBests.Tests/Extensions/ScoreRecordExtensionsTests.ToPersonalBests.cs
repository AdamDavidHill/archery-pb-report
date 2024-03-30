using FluentAssertions;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class ScoreRecordExtensionsTests
{
    [Fact]
    public void ToPersonalBests_GivenScoreRecords_ReturnsCorrectPersonalBests()
    {
        var scores = new List<ScoreRecord>
        {
            new() { MemberName = "Alice", Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open", Score = 320 },
            new() { MemberName = "Alice", Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open", Score = 310 },
            new() { MemberName = "Bob", Round = "FITA", Class = "Compound", AgeGroup = "Men 50+", Score = 305 },
            new() { MemberName = "Bob", Round = "FITA", Class = "Compound", AgeGroup = "Men 50+", Score = 0 }, // Should be ignored due to score = 0
            new() { MemberName = "Charlie", Round = "FITA", Class = "Compound", AgeGroup = "Men 50+", Score = 300 }
        };

        var expected = new List<PersonalBest>
        {
            new() { MemberName = "Alice", Category = new() { Round = "Portsmouth", Class = "Recurve", AgeGroup = "Open" }, HighestScore = 320 },
            new() { MemberName = "Bob", Category = new() { Round = "FITA", Class = "Compound", AgeGroup = "Men 50+" }, HighestScore = 305 },
            new() { MemberName = "Charlie", Category = new() { Round = "FITA", Class = "Compound", AgeGroup = "Men 50+" }, HighestScore = 300 }
        };

        var result = scores.ToPersonalBests();

        result.Should().BeEquivalentTo(expected, options => options.ComparingByMembers<PersonalBest>());
    }
}
