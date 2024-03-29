namespace PersonalBests.Extensions;

public static class IEnumerableExtensions
{
    public static List<TResult> Aggregate<TSource, TResult>(this IEnumerable<TSource> source, Func<List<TResult>, TSource, List<TResult>> func)
        => source.Aggregate(new List<TResult>(), (acc, current) => func(acc, current));
}
