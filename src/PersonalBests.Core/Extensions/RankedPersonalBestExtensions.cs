using PersonalBests.Enums;
using PersonalBests.Models;

namespace PersonalBests.Extensions;

public static class RankedPersonalBestExtensions
{
    public static IEnumerable<ReportRow> Differential(this List<RankedPersonalBest> current, List<RankedPersonalBest> prev)
        => current
            .Select(i => i.CreateDifferential(prev.Match(i)))
            .Select(i => new ReportRow
            {
                Round = i.Category.Round,
                Class = i.Category.Class,
                AgeGroup = i.Category.AgeGroup,
                Rank = i.Rank,
                HighestScore = i.HighestScore,
                Name = i.MemberName,
                RankType = i.RankType,
                Status = i.Status,
                Movement = i.Movement,
                Moved = i.Moved
            });

    public static RankedPersonalBest? Match(this List<RankedPersonalBest> prev, RankedPersonalBest current)
        => prev.FirstOrDefault(i => i.Category == current.Category && i.MemberName == current.MemberName);

    public static DifferentialRankedPersonalBest CreateDifferential(this RankedPersonalBest current, RankedPersonalBest? prev)
        => new()
        {
            Category = current.Category,
            HighestScore = Math.Max(current.HighestScore, prev?.HighestScore ?? 0),
            MemberName = current.MemberName,
            Rank = current.Rank,
            RankType = current.RankType,
            Status = current.GetStatus(prev),
            Movement = current.GetRankingMovement(prev),
            Moved = current.GetPositionsMoved(prev)
        };

    public static ScoreStatus GetStatus(this RankedPersonalBest current, RankedPersonalBest? prev)
        => (current, prev) switch
        {
            (_, null) => ScoreStatus.New,
            { } when current.HighestScore > (prev?.HighestScore ?? 0) => ScoreStatus.Improved,
            _ => ScoreStatus.Unchanged
        };

    public static RankingMovement GetRankingMovement(this RankedPersonalBest current, RankedPersonalBest? prev)
        => (current, prev) switch
        {
            (_, null) => RankingMovement.New,
            { } when current.Rank > prev.Rank => RankingMovement.Down, // Unintuitive, reversed because 4 to 1 means Up
            { } when current.Rank < prev.Rank => RankingMovement.Up,   // Unintuitive, reversed because 4 to 1 means Up
            _ => RankingMovement.Static
        };

    public static int GetPositionsMoved(this RankedPersonalBest current, RankedPersonalBest? prev)
        => (current, prev) switch
        {
            (_, null) => 0,
            _ => prev.Rank - current.Rank
        };
}
