using PersonalBests.Models;

namespace PersonalBests.Extensions;

public static class CsvOutputRowExtensions
{
    public static string Surname(this CsvOutputRow input)
        => string.Join(' ', input.Name?.Split(' ')?.Skip(1) ?? []);
}
