using PersonalBests.Enums;

namespace PersonalBests.Models;

public record ReportRow
{
    public string? Round { get; init; } // e.g. Portsmouth
    public string? Class { get; init; } // e.g. Barebow
    public string? AgeGroup { get; init; } // e.g. Men 50+
    public int Rank { get; init; } // e.g. 7
    public int HighestScore { get; init; } // e.g. 555
    public string MemberName { get; init; } = string.Empty; // e.g. Bob Smith
    public RankType RankType { get; init; } // e.g. Joint
    public ScoreStatus Status { get; init; } // e.g. Improved
    public RankingMovement RankingMovement { get; init; } // e.g. Up
    public int PositionsMoved { get; init; } // e.g. -3
}
