using PersonalBests.Models;

namespace PersonalBests.Tests.TestData;

internal static class Data
{
    private static string Jon = "Jon Doe";
    private static string Jim = "Jim Doe";
    private static string Bob = "Bob Doe";
    private static string Dan = "Dan Doe";
    private static string Jane = "Jane Doe";
    private static string Jenn = "Jenn Doe";
    private static string M = "Men";
    private static string W = "Women";
    private static string BB = "Barebow";
    private static string RC = "Recurve";
    private static string P = "Portsmouth";
    private static string F = "Frostbite";
    private static DateTime OldDate = DateTime.UtcNow.AddMonths(-2);
    private static DateTime NewDate = DateTime.UtcNow.AddMonths(-1);

    public static List<ScoreRecord> AllScores => OldScores.Concat(RecentScores).ToList();

    public static List<ScoreRecord> OldScores => new()
        {
            new () { Date = OldDate, Round = F, Class=RC, AgeGroup=M, MemberName = Jim, Score = 270 },
            new () { Date = OldDate, Round = F, Class=RC, AgeGroup=M, MemberName = Jon, Score = 280 },
            new () { Date = OldDate, Round = F, Class=BB, AgeGroup=W, MemberName = Jane, Score = 230 },
            new () { Date = OldDate, Round = F, Class=RC, AgeGroup=W, MemberName = Jenn, Score = 251 },
            new () { Date = OldDate, Round = P, Class=BB, AgeGroup=M, MemberName = Dan, Score = 435 },
            new () { Date = OldDate, Round = P, Class=BB, AgeGroup=M, MemberName = Jon, Score = 510 },
            new () { Date = OldDate, Round = P, Class=BB, AgeGroup=M, MemberName = Jon, Score = 511 },
            new () { Date = OldDate, Round = P, Class=BB, AgeGroup=M, MemberName = Jim, Score = 501 },
            new () { Date = OldDate, Round = P, Class=BB, AgeGroup=M, MemberName = Jim, Score = 502 },
            new () { Date = OldDate, Round = P, Class=RC, AgeGroup=M, MemberName = Jon, Score = 568 },
            new () { Date = OldDate, Round = P, Class=RC, AgeGroup=M, MemberName = Jon, Score = 565 },
            new () { Date = OldDate, Round = P, Class=RC, AgeGroup=M, MemberName = Jim, Score = 454 },
            new () { Date = OldDate, Round = P, Class=RC, AgeGroup=M, MemberName = Jim, Score = 555 },
            new () { Date = OldDate, Round = P, Class=BB, AgeGroup=W, MemberName = Jane, Score = 465 },
            new () { Date = OldDate, Round = P, Class=BB, AgeGroup=W, MemberName = Jane, Score = 470 },
            new () { Date = OldDate, Round = P, Class=BB, AgeGroup=W, MemberName = Jenn, Score = 495 },
            new () { Date = OldDate, Round = P, Class=BB, AgeGroup=W, MemberName = Jenn, Score = 497 },
            new () { Date = OldDate, Round = P, Class=RC, AgeGroup=W, MemberName = Jane, Score = 537 },
            new () { Date = OldDate, Round = P, Class=RC, AgeGroup=W, MemberName = Jane, Score = 567 },
            new () { Date = OldDate, Round = P, Class=RC, AgeGroup=W, MemberName = Jenn, Score = 557 },
            new () { Date = OldDate, Round = P, Class=RC, AgeGroup=W, MemberName = Jenn, Score = 567 },
        };

    public static List<ScoreRecord> RecentScores => new()
        {
            new () { Date = NewDate, Round = F, Class=RC, AgeGroup=W, MemberName = Jane, Score = 250 },
            new () { Date = NewDate, Round = F, Class=RC, AgeGroup=W, MemberName = Jenn, Score = 252 },
            new () { Date = NewDate, Round = P, Class=BB, AgeGroup=M, MemberName = Bob, Score = 570 },
            new () { Date = NewDate, Round = P, Class=RC, AgeGroup=M, MemberName = Bob, Score = 585 },
            new () { Date = NewDate, Round = P, Class=BB, AgeGroup=M, MemberName = Jim, Score = 569 },
            new () { Date = NewDate, Round = P, Class=BB, AgeGroup=M, MemberName = Dan, Score = 569 },
            new () { Date = NewDate, Round = P, Class=BB, AgeGroup=M, MemberName = Jon, Score = 481 },
            new () { Date = NewDate, Round = P, Class=BB, AgeGroup=M, MemberName = Jon, Score = 499 },
        };
}
