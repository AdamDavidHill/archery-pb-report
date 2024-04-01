using PersonalBests.Enums;
using PersonalBests.Models;

namespace PersonalBests.Extensions;

public static class ReportRowExtensions
{
    public static CsvOutputRow ToCsvOutputRow(this ReportRow input)
        => new()
        {
            Category = input.AgeGroup + " - " + input.Class + " - " + input.Round,
            Position = input.Rank.ToString() + (input.RankType == Enums.RankType.Exclusive ? string.Empty : "=="),
            Name = input.Name,
            Score = input.HighestScore,
            Improved = input.Status != Enums.ScoreStatus.Unchanged,
            Move = input.GetMove()
        };

    public static string GetMove(this ReportRow input)
        => input.Movement switch
        {
            RankingMovement.New => "NEW",
            RankingMovement.Up => "↑" + Math.Abs(input.Moved).ToString(),
            RankingMovement.Down => "↓" + Math.Abs(input.Moved).ToString(),
            _ => "-"
        };
}
