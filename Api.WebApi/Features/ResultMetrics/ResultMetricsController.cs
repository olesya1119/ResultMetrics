using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResultMetrics.Api.WebApi.Features.ResultMetrics.GetResults;
using ResultMetrics.Api.WebApi.Features.ResultMetrics.UploadCsv;
using ResultMetrics.Api.WebApi.Models;
using ResultMetrics.Common.Result;

namespace ResultMetrics.Api.WebApi.Features.ResultMetrics;

[ApiController]
[Route("result-metrics/api")]
[Produces("application/json")]
public class ResultMetricsController : ControllerBase
{
    private readonly IMediator mediator;

    public ResultMetricsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Загружает CSV-файл, валидирует и сохраняет его значения в базу данных.
    /// После сохранения рассчитываются интегральные результаты.
    /// </summary>
    /// <param name="file">CSV-файл с результатами обработки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Рассчитанные интегральные результаты для загруженного файла.</returns>
    [HttpPost("csv")]
    [ProducesResponseType<MetricsResult>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadCsv(IFormFile file,CancellationToken cancellationToken)
    {
        var command = new UploadCsvCommand { File = file };
        var result = await mediator.Send(command, cancellationToken);
        return this.ToActionResult(result);
    }
    
    /// <summary>
    /// Возвращает список интегральных результатов с учетом указанных фильтров.
    /// </summary> /// <param name="query">Фильтры результатов.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список результатов, соответствующих заданным фильтрам.</returns>
    [HttpGet("results")]
    [ProducesResponseType<IReadOnlyCollection<MetricsResult>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetResults(
        [FromQuery] GetResultsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(query, cancellationToken);

        return this.ToActionResult(result);
    }
}