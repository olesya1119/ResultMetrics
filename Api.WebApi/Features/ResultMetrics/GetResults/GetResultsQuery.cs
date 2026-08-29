using FluentValidation;
using MediatR;
using ResultMetrics.Api.WebApi.Models;
using ResultMetrics.Common.Result;

namespace ResultMetrics.Api.WebApi.Features.ResultMetrics.GetResults;

public class GetResultsQuery : IRequest<Result<IReadOnlyCollection<MetricsResult>>>
{
    public string? FileName { get; init; }

    public DateTime? MinDate { get; init; }

    public DateTime? MaxDate { get; init; }

    public double? MinAvgValue { get; init; }

    public double? MaxAvgValue { get; init; }

    public double? MinAvgExecutionTime { get; init; }

    public double? MaxAvgExecutionTime { get; init; }

    public class Validator : AbstractValidator<GetResultsQuery>
    {
        public Validator()
        {
            RuleFor(x => x.FileName)
                .Must(fileName =>
                    fileName is null || !string.IsNullOrWhiteSpace(fileName))
                .WithMessage("File name cannot be empty.");

            RuleFor(x => x)
                .Must(x =>
                    !x.MinDate.HasValue ||
                    !x.MaxDate.HasValue ||
                    x.MinDate <= x.MaxDate)
                .WithMessage(
                    "Minimum date cannot be greater than maximum date.");

            RuleFor(x => x)
                .Must(x =>
                    !x.MinAvgValue.HasValue ||
                    !x.MaxAvgValue.HasValue ||
                    x.MinAvgValue <= x.MaxAvgValue)
                .WithMessage(
                    "Minimum average value cannot be greater than maximum average value.");

            RuleFor(x => x)
                .Must(x =>
                    !x.MinAvgExecutionTime.HasValue ||
                    !x.MaxAvgExecutionTime.HasValue ||
                    x.MinAvgExecutionTime <= x.MaxAvgExecutionTime)
                .WithMessage(
                    "Minimum average execution time cannot be greater than maximum average execution time.");

            RuleFor(x => x.MinAvgValue)
                .GreaterThanOrEqualTo(0)
                .When(x => x.MinAvgValue.HasValue)
                .WithMessage("Minimum average value cannot be negative.");

            RuleFor(x => x.MaxAvgValue)
                .GreaterThanOrEqualTo(0)
                .When(x => x.MaxAvgValue.HasValue)
                .WithMessage("Maximum average value cannot be negative.");

            RuleFor(x => x.MinAvgExecutionTime)
                .GreaterThanOrEqualTo(0)
                .When(x => x.MinAvgExecutionTime.HasValue)
                .WithMessage("Minimum average execution time cannot be negative.");

            RuleFor(x => x.MaxAvgExecutionTime)
                .GreaterThanOrEqualTo(0)
                .When(x => x.MaxAvgExecutionTime.HasValue)
                .WithMessage("Maximum average execution time cannot be negative.");
        }
    }
}