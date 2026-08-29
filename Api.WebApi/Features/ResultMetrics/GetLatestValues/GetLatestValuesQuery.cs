using FluentValidation;
using MediatR;
using ResultMetrics.Api.WebApi.Models;
using ResultMetrics.Common.Result;

namespace ResultMetrics.Api.WebApi.Features.ResultMetrics.GetLatestValues;

public class GetLatestValuesQuery : IRequest<Result<IReadOnlyCollection<ValueModel>>>
{
    /// <summary>
    /// Имя файла.
    /// </summary>
    public string FileName { get; init; } = null!;

    public class Validator : AbstractValidator<GetLatestValuesQuery>
    {
        public Validator()
        {
            RuleFor(x => x.FileName)
                .NotEmpty()
                .WithMessage("File name is required.");
        }
    }
}