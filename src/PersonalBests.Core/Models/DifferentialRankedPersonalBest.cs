using PersonalBests.Enums;

namespace PersonalBests.Models;

public record DifferentialRankedPersonalBest : RankedPersonalBest
{
    public ScoreStatus Status { get; init; } // e.g. Improved
    public RankingMovement RankingMovement { get; init; } // e.g. Up
    public int PositionsMoved { get; init; } // e.g. -3
}
