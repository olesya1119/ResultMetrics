using System;
using FluentValidation;

namespace ResultMetrics.Api.WebApi.Features.ResultMetrics.UploadCsv.Models;

public class ValueCsvRecord
{
    public DateTime Date { get; init; }
    public double ExecutionTime { get; init; }
    public double Value { get; init; }

    public sealed class ValueCsvModelValidator : AbstractValidator<ValueCsvRecord>
    {
        public ValueCsvModelValidator()
        {
            RuleFor(x => x.Date)
                .GreaterThanOrEqualTo(Constants.MinDate) .WithMessage("Date cannot be earlier than 01.01.2000.");
            RuleFor(x => x.Date)
                .LessThanOrEqualTo(DateTime.UtcNow) .WithMessage("Date cannot be later than the current time.");
            RuleFor(x => x.ExecutionTime)
                .GreaterThanOrEqualTo(0) .WithMessage("ExecutionTime cannot be less than 0.");
            RuleFor(x => x.Value)
                .GreaterThanOrEqualTo(0) .WithMessage("Value cannot be less than 0.");
        }
    }
}