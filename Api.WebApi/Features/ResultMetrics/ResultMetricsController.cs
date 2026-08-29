using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResultMetrics.Api.WebApi.Features.ResultMetrics.GetResults;
using ResultMetrics.Api.WebApi.Features.ResultMetrics.UploadCsv;
using ResultMetrics.Common.Result;

namespace ResultMetrics.Api.WebApi.Features.ResultMetrics;

[ApiController]
[Route("")]
public class ResultMetricsController : ControllerBase
{
    private readonly IMediator mediator;

    public ResultMetricsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("csv")]
    public async Task<IActionResult> UploadCsv(IFormFile file,CancellationToken cancellationToken)
    {
        var command = new UploadCsvCommand { File = file };
        var result = await mediator.Send(command, cancellationToken);
        return this.ToActionResult(result);
    }
    
    [HttpGet("results")]
    public async Task<IActionResult> GetResults(
        [FromQuery] GetResultsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(query, cancellationToken);

        return this.ToActionResult(result);
    }
}