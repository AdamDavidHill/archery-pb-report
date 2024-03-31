using PersonalBests.Models;

namespace PersonalBests.Interfaces;

public interface IScoreProvider
{
    Task<List<ScoreRecord>> GetAllHistoricScores();
}
