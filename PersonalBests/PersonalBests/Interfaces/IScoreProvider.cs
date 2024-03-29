using PersonalBests.Models;

namespace PersonalBests.Interfaces;

public interface IScoreProvider
{
    List<ScoreRecord> GetAllHistoricScores();
}
