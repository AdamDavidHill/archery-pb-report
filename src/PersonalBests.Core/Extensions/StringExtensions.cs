namespace PersonalBests.Extensions;

public static class StringExtensions
{
    public static string SimplifiedAgeGroup(this string input)
        => input.ToUpper() switch
        {
            string a when a.Contains("U") => "Juniors",
            string a when a.Contains("WOMEN") => "Women",
            string a when a.Contains("LADIES") => "Women",
            _ => "Men",
        };

    public static string SimplifiedRound(this string input)
        => input.ToUpper() switch
        {
            string a when a.Contains("PROGRESS") => "Progress",
            _ => input,
        };

    public static int NumericValue(this string input)
        => int.Parse("0" + new string(input.Where(c => char.IsDigit(c)).ToArray()));
}
