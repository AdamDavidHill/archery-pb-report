using Microsoft.Extensions.Options;
using PersonalBests.Client.Config;
using PersonalBests.Client.Models;
using PersonalBests.Interfaces;
using PersonalBests.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Web;

namespace PersonalBests.Client.Services;

public class ScoreProvider(IOptions<GoldenRecordsOptions> _config, IHttpClientFactory _httpClientFactory) : IScoreProvider
{
    public async Task<List<ScoreRecord>> GetAllHistoricScores()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(_config.Value.ApiKey);
        var httpClient = _httpClientFactory.CreateClient(nameof(ScoreProvider));
        var apiKeyParts = _config.Value.ApiKey!.Split(' ');
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(apiKeyParts.First(), apiKeyParts.Last());
        var url = GetUrl(1);
        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var contents = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<ApiScoreRecord>>(contents, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })?
                .Where(HasNoKeyFieldNulls)
                .Select(Map)
                .ToList()
                ?? [];
        }

        return [];
    }

    private static string GetUrl(int page)
    {
        const string url = @"https://api.archery-records.net/api/scores";
        var builder = new UriBuilder(url);
        //builder.Port = -1;
        var query = HttpUtility.ParseQueryString(builder.Query);
        query["page"] = page.ToString();
        query["pageSize"] = "1000";
        builder.Query = query.ToString();

        return builder.ToString();
    }

    private static bool HasNoKeyFieldNulls(ApiScoreRecord i)
        => i.DateShot is not null
            && i.Round is not null
            && i.BowClass is not null
            && i.Category is not null
            && i.Score is not null
            && i.Name is not null;

    public ScoreRecord Map(ApiScoreRecord i)
        => new()
        {
            Date = i.DateShot! ?? DateTime.UtcNow,
            Round = i.Round!,
            Class = i.BowClass!,
            AgeGroup = i.Category!,
            Score = i.Score ?? 0,
            MemberName = i.Name!
        };
}
