namespace PersonalBests.Models;

public record CsvOutputRow
{
    public string Category { get; init; } = string.Empty; // e.g. Gents - Recurve
    public string Position { get; init; } = string.Empty; // e.g. 3==
    public string Name { get; init; } = string.Empty;  // e.g. John Doe
    public int Score { get; init; } // e.g. 525
    public bool Improved { get; init; } // e.g. true if score has increased or is new since last time
    public string Move { get; init; } = string.Empty;  // e.g. 
}
