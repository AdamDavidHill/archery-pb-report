using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.Text;

namespace PersonalBests.Extensions;

public static class IEnumerableExtensions
{
    public static List<TResult> Aggregate<TSource, TResult>(this IEnumerable<TSource> source, Func<List<TResult>, TSource, List<TResult>> func)
        => source.Aggregate(new List<TResult>(), (acc, current) => func(acc, current));

    public static async Task ToCsvFile<T>(this IEnumerable<T> source, string filePath)
    {
        using var writer = new StreamWriter(filePath, append: false, Encoding.UTF8);
        using var csv = new CsvWriter(writer, CultureInfo.CurrentCulture);
        await csv.WriteRecordsAsync(source);
    }

    public static async Task<byte[]> ToCsvBytes<T>(this IEnumerable<T> source)
        => Encoding.UTF8.GetBytes(await source.ToCsvString<T>());

    public static async Task<string> ToCsvString<T>(this IEnumerable<T> source)
    {
        using var stream = new MemoryStream();
        using var reader = new StreamReader(stream, Encoding.UTF8);
        using var writer = new StreamWriter(stream, Encoding.UTF8);
        using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.CurrentCulture));
        await csv.WriteRecordsAsync(source);
        writer.Flush();
        stream.Position = 0;

        return await reader.ReadToEndAsync();
    }
}
