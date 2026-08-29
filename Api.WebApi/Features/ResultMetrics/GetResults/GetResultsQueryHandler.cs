using System.Net;
using MediatR;
using ResultMetrics.Api.WebApi.Mappers;
using ResultMetrics.Api.WebApi.Models;
using ResultMetrics.Common.Result;
using ResultMetrics.Store.PostgreSQL.Repositories;

namespace ResultMetrics.Api.WebApi.Features.ResultMetrics.GetResults;

public sealed class GetResultsQueryHandler
    : IRequestHandler<GetResultsQuery, Result<IReadOnlyCollection<MetricsResult>>>
{
    private readonly IResultsRepository resultsRepository;

    public GetResultsQueryHandler(IResultsRepository resultsRepository)
    {
        this.resultsRepository = resultsRepository;
    }

    public async Task<Result<IReadOnlyCollection<MetricsResult>>> Handle(
        GetResultsQuery request,
        CancellationToken ct)
    {
        var results = await resultsRepository.GetAsync(
            request.FileName,
            request.MinDate,
            request.MaxDate,
            request.MinAvgValue,
            request.MaxAvgValue,
            request.MinAvgExecutionTime,
            request.MaxAvgExecutionTime,
            ct);

        var response = results
            .Select(x => x.ToClientModel())
            .ToList();

        return Result<IReadOnlyCollection<MetricsResult>>.Success(response,HttpStatusCode.OK);
    }
}