using PersonalBests.Models;

namespace PersonalBests.Extensions;

public static class ScoreRecordExtensions
{
    public static IEnumerable<PersonalBest> ToPersonalBests(this IEnumerable<ScoreRecord> scores)
        => from score in scores
           where score.Score > 0
           group score by score.ToCategory() into categories
           from memberCategories in
               (
                   from memberScores in categories
                   group memberScores by memberScores.MemberName
               )
           select new PersonalBest
           {
               Category = categories.Key,
               MemberName = memberCategories.Key,
               HighestScore = memberCategories.Max(i => i.Score)
           };

    public static Category ToCategory(this ScoreRecord score)
        => new()
        {
            Round = score.Round,
            Class = score.Class,
            AgeGroup = score.AgeGroup
        };

    public static ScoreRecord DataCleansed(this ScoreRecord score)
        => score with
        {
            AgeGroup = score.AgeGroup.SimplifiedAgeGroup(),
            Round = score.Round.SimplifiedRound(),
        };
}
