using FluentValidation;
using MediatR;
using ResultMetrics.Api.WebApi.Models;
using ResultMetrics.Common.Result;

namespace ResultMetrics.Api.WebApi.Features.ResultMetrics.UploadCsv;

public class UploadCsvCommand : IRequest<Result<MetricsResult>>
{
    /// <summary>
    /// CSV-файл с в формате Date;ExecutionTime;Value
    /// </summary>
    public IFormFile File { get; init; } = null!;

    public class Validator : AbstractValidator<UploadCsvCommand>
    {
        public Validator()
        {
            RuleFor(x => x.File).NotNull().WithMessage("File is required.");
        }
    }
}