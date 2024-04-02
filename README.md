# archery-pb-report

Generation of a differential Personal Best report for an archery club. It features current PBs up until the end of the previous month, and how they've changed relative to their position a month prior.

This is intended to be used as a class library by a scoring platform to add a monthly PB report.

## Getting Started

1. Add a project reference to `PersonalBests.Core.csproj`
1. Implement `IScoreProvider` with a class that loads all historic records for a given club
1. Create an instance of the `ReportGenerator` class, injecting your `IScoreProvider` implementation
1. Call `ReportGenerator.Generate()` to calculate the report

## Using the Client

An example console application, PersonalBests.Client, can be used to call the Golden Records API, map the data, and produce a report.

### Environment Variables

To use, you need an environment variable name `GoldenRecords__ApiKey` with your API key as the value.

e.g.

```
GoldenRecords__ApiKey=X w4VGmVScKoNVKpiwsTWopwyxHBgEw15h2SN2ewcLTRfdalRhk7tps5ePVElbmIQFFESHY...
```

### Output

For the moment this client just writes a text file called "test.csv" into the executing directory.

### .Net Runtime

To run the client you will need the [.Net 8 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).