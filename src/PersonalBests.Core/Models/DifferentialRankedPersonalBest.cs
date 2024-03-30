using PersonalBests.Enums;

namespace PersonalBests.Models;

public record DifferentialRankedPersonalBest : RankedPersonalBest
{
    public ScoreStatus Status { get; init; } // e.g. Improved
    public RankingMovement Movement { get; init; } // e.g. Up
    public int Moved { get; init; } // e.g. -3
}
