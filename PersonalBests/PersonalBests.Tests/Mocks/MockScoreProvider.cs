using PersonalBests.Interfaces;
using PersonalBests.Models;

namespace PersonalBests.Tests.Mocks;

internal class MockScoreProvider(List<ScoreRecord> dataToProvide) : IScoreProvider
{
    public List<ScoreRecord> GetAllHistoricScores() => dataToProvide;
}
