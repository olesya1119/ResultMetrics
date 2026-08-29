using System;

namespace ResultMetrics.Api.WebApi;

public static class Constants
{
    public const int MinRecords = 1;
    public const int MaxRecords = 10_000;
    public static readonly DateTime MinDate = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public const int LatestValuesCount = 10;
}