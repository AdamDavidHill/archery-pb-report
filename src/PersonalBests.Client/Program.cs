﻿using Microsoft.Extensions.Configuration;
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

        var path = Path.Combine(Directory.GetCurrentDirectory(), "test.csv");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        await report.ToCsvFile(path);
    }
}