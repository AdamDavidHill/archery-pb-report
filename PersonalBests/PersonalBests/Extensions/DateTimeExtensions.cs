namespace PersonalBests.Extensions;

public static class DateTimeExtensions
{
    public static DateTime FirstDayOfMonth(this DateTime date)
        => new DateTime(date.Year, date.Month, 1);
}
