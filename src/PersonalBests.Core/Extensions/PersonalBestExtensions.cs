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

    private static IEnumerable<List<RankedPersonalBest>> ToSegregatedCategorizedRankedPersonalBests(this IEnumerable<PersonalBest> scores)
        => from score in scores
           group score by score.Category into categories
           select categories.ToRankedPersonalBests();

    private static List<RankedPersonalBest> ToRankedPersonalBests(this IEnumerable<PersonalBest> scores)
        => scores
            .OrderByDescending(i => i.HighestScore)
            .Index()
            .Aggregate<IndexedScore, RankedPersonalBest>((acc, current) =>
            {
                acc.Add(new()
                {
                    Category = current.Score.Category,
                    HighestScore = current.Score.HighestScore,
                    MemberName = current.Score.MemberName,
                    Rank = acc.GetRank(current),
                    RankType = acc.GetRankType(current)
                });

                return acc;
            });

    private static IEnumerable<IndexedScore> Index(this IEnumerable<PersonalBest> source)
        => source.Select((score, index) => (ZeroBasedIndex: index, Score: score));

    private static int GetRank(this List<RankedPersonalBest> acc, IndexedScore current)
        => acc.IsNextRankDown(current)
                ? current.ZeroBasedIndex + 1
                : acc.Last().Rank;

    private static bool IsNextRankDown(this List<RankedPersonalBest> acc, IndexedScore current)
        => acc.Count == 0 || acc.Last().HighestScore != current.Score.HighestScore;

    private static RankType GetRankType(this List<RankedPersonalBest> acc, IndexedScore current)
        => acc.IsJointPlace(current)
            ? RankType.Joint
            : RankType.Exclusive;

    private static bool IsJointPlace(this List<RankedPersonalBest> acc, IndexedScore current)
        => acc.Any() && acc.Last().HighestScore == current.Score.HighestScore;
}
