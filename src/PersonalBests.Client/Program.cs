using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetCore.AutoRegisterDi;
using PersonalBests.Client.Config;
using PersonalBests.Extensions;
using PersonalBests.Services;
using System.Globalization;

namespace PersonalBests.Client;

public static class Program
{
    static async Task Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
        var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, builder) =>
            {
                builder.AddEnvironmentVariables();
            })
            .ConfigureServices((context, services) =>
            {
                services
                    .AddHttpClient()
                    .AddLogging(logging => logging.AddConsole())
                    .RegisterAssemblyPublicNonGenericClasses(AppAssemblies.All)
                    .AsPublicImplementedInterfaces();
                services.Configure<GoldenRecordsOptions>(options => { context.Configuration.GetSection("GoldenRecords").Bind(options); });
            })
            .Build();
        var reportGenerator = host.Services.GetRequiredService<IReportGenerator>()!;
        var report = await reportGenerator.Generate();
        var reformatted = report
            .Select(i => i.ToCsvOutputRow())
            .OrderBy(row => row.Category)
            .ThenBy(row => row.Position)
            .ThenBy(row => row.Surname())
            .ToList();

        var path = Path.Combine(Directory.GetCurrentDirectory(), $"report-{DateTime.UtcNow.ToString("yyyyMMdd")}.csv");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        await reformatted.ToCsvFile(path);
        Console.WriteLine("File written. Press any key to exit.");
        Console.ReadLine();
    }
}
