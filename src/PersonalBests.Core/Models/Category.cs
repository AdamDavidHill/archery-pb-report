namespace PersonalBests.Models;

// Record rather than class so it can be assessed for equality by value
public record Category
{
    public string? Round { get; init; } // e.g. Portsmouth
    public string? Class { get; init; } // e.g. Barebow
    public string? AgeGroup { get; init; } // e.g. Men 50+
}
