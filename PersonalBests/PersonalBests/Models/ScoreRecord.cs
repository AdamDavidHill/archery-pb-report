namespace PersonalBests.Models;

public record ScoreRecord
{
    public DateTime Date { get; init; }
    public string Round { get; init; } = string.Empty; // e.g. Portsmouth
    public string Class { get; init; } = string.Empty; // e.g. Barebow
    public string AgeGroup { get; init; } = string.Empty; // e.g. Men 50+
    public int Score { get; init; } // e.g. 555
    public string MemberName { get; init; } = string.Empty; // e.g. Bob Smith
}
