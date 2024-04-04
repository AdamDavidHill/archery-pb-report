using FluentAssertions;
using PersonalBests.Extensions;
using PersonalBests.Models;

namespace PersonalBests.Tests.Extensions;

public partial class CsvOutputRowExtensionsTests
{
    [Theory]
    [InlineData("John Doe", "Doe")]
    [InlineData("Alice Mary Johnson", "Mary Johnson")]
    [InlineData("Bob", "")]
    public void Surname_GivenCsvOutputRow_ReturnsCorrectSurname(string name, string expectedSurname)
    {
        var csvOutputRow = new CsvOutputRow
        {
            Name = name
        };

        var surname = csvOutputRow.Surname();

        surname.Should().Be(expectedSurname);
    }
}
