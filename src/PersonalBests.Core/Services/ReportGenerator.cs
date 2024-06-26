﻿using PersonalBests.Extensions;
using PersonalBests.Interfaces;
using PersonalBests.Models;

namespace PersonalBests.Services;

public class ReportGenerator(IScoreProvider _scoreProvider) : IReportGenerator
{
    /// <summary>
    /// Generates a differential personal best report. Dates are based on the end of the previous month, relative to the end of the month before that. Envisaged as being called once per month on a schedule, any time on the first day.
    /// </summary>
    /// <returns>A list of categorized and ranked personal bests</returns>
    public Task<List<ReportRow>> Generate()
        => Generate(toDate: DateTime.UtcNow.FirstDayOfMonth(), prevToDate: DateTime.UtcNow.AddMonths(-1).FirstDayOfMonth());

    /// <summary>
    /// Generates a differential personal best report. Allows running the report for a given period. 
    /// </summary>
    /// <param name="toDate">The date up until scores are counted (exclusive) for current rankings</param>
    /// <param name="prevToDate">The date up until scores were counted (exclusive) for the previous rankings</param>
    /// <returns>A list of categorized and ranked personal bests</returns>
    public async Task<List<ReportRow>> Generate(DateTime toDate, DateTime prevToDate)
    {
        var allScores = await _scoreProvider.GetAllHistoricScores();
        var simplifiedAgeGroupScores = allScores.Select(i => i.DataCleansed());
        var pbOld = simplifiedAgeGroupScores.Where(i => i.Date < prevToDate).ToPersonalBests();
        var pbNew = simplifiedAgeGroupScores.Where(i => i.Date < toDate).ToPersonalBests();
        var rankedOld = pbOld.ToCategorizedRankedPersonalBests();
        var rankedNew = pbNew.ToCategorizedRankedPersonalBests();
        var differential = rankedNew.Differential(rankedOld);

        return differential.ToList();
    }
}
