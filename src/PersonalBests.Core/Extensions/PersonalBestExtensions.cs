using PersonalBests.Enums;
using PersonalBests.Models;
using IndexedScore = (int ZeroBasedIndex, PersonalBests.Models.PersonalBest Score);

namespace PersonalBests.Extensions;

public static class PersonalBestExtensions
{
    public static List<RankedPersonalBest> ToCategorizedRankedPersonalBests(this IEnumerable<PersonalBest> scores)
        => scores
            .ToSegregatedCategorizedRankedPersonalBests()
            .SelectMany(i => i)
            .ToList();

    public static IEnumerable<List<RankedPersonalBest>> ToSegregatedCategorizedRankedPersonalBests(this IEnumerable<PersonalBest> scores)
        => from score in scores
           group score by score.Category into categories
           select categories.ToRankedPersonalBests();

    public static List<RankedPersonalBest> ToRankedPersonalBests(this IEnumerable<PersonalBest> scores)
    {
        var indexedScores = scores
            .OrderByDescending(i => i.HighestScore)
            .Index()
            .ToList(); // Materialized to enable forward-looking

        return indexedScores
            .Select((current, index) => new RankedPersonalBest
            {
                Category = current.Score.Category,
                HighestScore = current.Score.HighestScore,
                MemberName = current.Score.MemberName,
                Rank = indexedScores.GetRank(current, index),
                RankType = indexedScores.GetRankType(current, index)
            }).ToList();
    }

    public static IEnumerable<IndexedScore> Index(this IEnumerable<PersonalBest> source)
        => source.Select((score, index) => (ZeroBasedIndex: index, Score: score));

    public static int GetRank(this List<IndexedScore> indexedScores, IndexedScore current, int index)
        => indexedScores.IsNextRankDown(current, index)
                ? current.ZeroBasedIndex + 1
                : indexedScores[index - 1 < 0 ? 0 : index - 1].ZeroBasedIndex + 1;

    public static bool IsNextRankDown(this List<IndexedScore> indexedScores, IndexedScore current, int index)
        => index == 0 || indexedScores[index - 1].Score.HighestScore != current.Score.HighestScore;

    /*public static RankType GetRankType(this List<IndexedScore> indexedScores, IndexedScore current, int index)
    {
        bool isPreviousSame = index > 0 && indexedScores[index - 1].Score.HighestScore == current.Score.HighestScore;
        bool isNextSame = index < indexedScores.Count - 1 && indexedScores[index + 1].Score.HighestScore == current.Score.HighestScore;

        return isPreviousSame || isNextSame ? RankType.Joint : RankType.Exclusive;
    }*/
    public static RankType GetRankType(this List<IndexedScore> indexedScores, IndexedScore current, int index)
    {
        bool isPreviousSame = index > 0 && indexedScores[index - 1].Score.HighestScore == current.Score.HighestScore;
        bool isNextSame = index < indexedScores.Count - 1 && indexedScores[index + 1].Score.HighestScore == current.Score.HighestScore;

        return isPreviousSame || isNextSame ? RankType.Joint : RankType.Exclusive;
    }
}
