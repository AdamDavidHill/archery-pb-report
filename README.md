# archery-pb-report

Generation of a differential Personal Best report for an archery club. It features current PBs up until the end of the previous month, and how they've changed relative to their position a month prior.

This is intended to be used as a class library by a scoring platform to add a monthly PB report.

## Getting Started

1. Add a project reference to `PersonalBests.csproj`
1. Implement `IScoreProvider` with a class that loads all historic records for a given club
1. Create an instance of the `ReportGenerator` class, injecting your `IScoreProvider` implementation
1. Call `ReportGenerator.Generate()` to calculate the report
