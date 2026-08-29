using ResultMetrics.Api.WebApi.Features.ResultMetrics.UploadCsv.Models;
using ResultMetrics.Api.WebApi.Models;
using Results = ResultMetrics.Store.PostgreSQL.Models.Results;

namespace ResultMetrics.Api.WebApi.Mappers;

public static class ResultsMapper
{
    public static MetricsResult ToClientModel(this Results results) => new MetricsResult
    {
        FileName = results.FileName,
        DeltaDateInSeconds = results.DeltaDateInSeconds,
        MinDate = results.MinDate,
        AvgExecutionTimeInSeconds = results.AvgExecutionTime,
        AvgValue = results.AvgValue,
        MedianValue = results.MedianValue,
        MinValue = results.MinValue,
        MaxValue = results.MaxValue
    };

    public static Results ToEntity(this MetricsAccumulator metrics, string fileName) => new Results
    {
        FileName = fileName,
        DeltaDateInSeconds = metrics.DeltaDateInSeconds,
        MinDate = metrics.MinDate,
        AvgExecutionTime = metrics.AvgExecutionTimeInSeconds,
        AvgValue = metrics.AvgValue,
        MedianValue = metrics.MedianValue,
        MinValue = metrics.MinValue,
        MaxValue = metrics.MaxValue
    };
}