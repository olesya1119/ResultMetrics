using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResultMetrics.Api.WebApi.Features.ResultMetrics.UploadCsv;
using ResultMetrics.Common.Result;

namespace ResultMetrics.Api.WebApi.Features.ResultMetrics;

[ApiController]
[Route("api/result-metrics")]
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
}