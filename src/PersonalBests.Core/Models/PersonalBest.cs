namespace PersonalBests.Models;

public record PersonalBest
{
    public Category Category { get; init; } = new(); 
    public int HighestScore { get; init; } // e.g. 555
    public string MemberName { get; init; } = string.Empty; // e.g. Bob Smith
}
