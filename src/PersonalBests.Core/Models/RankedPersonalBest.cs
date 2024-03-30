using PersonalBests.Enums;

namespace PersonalBests.Models;

public record RankedPersonalBest : PersonalBest
{
    public int Rank { get; init; } // e.g. 7
    public RankType RankType { get; init; } // e.g. Joint
}
