using System.Net;
using MediatR;
using ResultMetrics.Api.WebApi.Mappers;
using ResultMetrics.Api.WebApi.Models;
using ResultMetrics.Common.Result;
using ResultMetrics.Store.PostgreSQL.Repositories;

namespace ResultMetrics.Api.WebApi.Features.ResultMetrics.GetLatestValues;

public class GetLatestValuesQueryHandler : IRequestHandler<GetLatestValuesQuery, Result<IReadOnlyCollection<ValueModel>>>
{
    private readonly IValuesRepository valuesRepository;

    public GetLatestValuesQueryHandler(IValuesRepository valuesRepository)
    {
        this.valuesRepository = valuesRepository;
    }

    public async Task<Result<IReadOnlyCollection<ValueModel>>> Handle(GetLatestValuesQuery request, CancellationToken ct)
    {
        var values = await valuesRepository.GetLatestAsync(
            request.FileName,
            Constants.LatestValuesCount,
            ct);

        var response = values
            .Select(x => x.ToClientModel())
            .ToList();

        return Result<IReadOnlyCollection<ValueModel>>.Success(response, HttpStatusCode.OK);
    }
}