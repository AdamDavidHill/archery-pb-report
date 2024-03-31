using PersonalBests.Models;

namespace PersonalBests.Services;

public interface IReportGenerator
{
    Task<List<ReportRow>> Generate();
    Task<List<ReportRow>> Generate(DateTime toDate, DateTime prevToDate);
}
