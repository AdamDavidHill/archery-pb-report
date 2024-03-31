using PersonalBests.Interfaces;
using PersonalBests.Models;

namespace PersonalBests.Tests.Mocks;

internal class MockScoreProvider(List<ScoreRecord> dataToProvide) : IScoreProvider
{
    public Task<List<ScoreRecord>> GetAllHistoricScores() => Task.FromResult(dataToProvide);
}
