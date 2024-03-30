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
                MemberName = i.MemberName,
                RankType = i.RankType,
                Status = i.Status,
                RankingMovement = i.RankingMovement,
                PositionsMoved = i.PositionsMoved
            });

    private static RankedPersonalBest? Match(this List<RankedPersonalBest> prev, RankedPersonalBest current)
        => prev.FirstOrDefault(i => i.Category == current.Category && i.MemberName == current.MemberName);

    private static DifferentialRankedPersonalBest CreateDifferential(this RankedPersonalBest current, RankedPersonalBest? prev)
        => new()
        {
            Category = current.Category,
            HighestScore = current.HighestScore,
            MemberName = current.MemberName,
            Rank = current.Rank,
            RankType = current.RankType,
            Status = current.GetStatus(prev),
            RankingMovement = current.GetRankingMovement(prev),
            PositionsMoved = current.GetPositionsMoved(prev)
        };

    private static ScoreStatus GetStatus(this RankedPersonalBest current, RankedPersonalBest? prev)
        => (current, prev) switch
        {
            (_, null) => ScoreStatus.New,
            { } when current.HighestScore == prev.HighestScore => ScoreStatus.Unchanged,
            _ => ScoreStatus.Improved
        };

    private static RankingMovement GetRankingMovement(this RankedPersonalBest current, RankedPersonalBest? prev)
        => (current, prev) switch
        {
            (_, null) => RankingMovement.New,
            { } when current.Rank > prev.Rank => RankingMovement.Up,
            { } when current.Rank < prev.Rank => RankingMovement.Down,
            _ => RankingMovement.Static
        };

    private static int GetPositionsMoved(this RankedPersonalBest current, RankedPersonalBest? prev)
        => (current, prev) switch
        {
            (_, null) => 0,
            _ => prev.Rank - current.Rank
        };
}
