using FluentAssertions;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class ScoreRecordExtensionsTests
{
    [Fact]
    public void ToCategory_GivenScoreRecord_ReturnsCorrectCategory()
    {
        var scoreRecord = new ScoreRecord
        {
            Round = "Portsmouth",
            Class = "Compound",
            AgeGroup = "Men 50+",
            Score = 300,
            MemberName = "John Doe"
        };

        var expectedCategory = new Category
        {
            Round = "Portsmouth",
            Class = "Compound",
            AgeGroup = "Men 50+"
        };

        var category = scoreRecord.ToCategory();

        category.Should().BeEquivalentTo(expectedCategory);
    }
}
