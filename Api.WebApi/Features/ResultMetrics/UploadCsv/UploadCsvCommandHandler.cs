using System.Globalization;
using System.Net;
using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using ResultMetrics.Api.WebApi.Features.ResultMetrics.UploadCsv.Models;
using ResultMetrics.Api.WebApi.Mappers;
using ResultMetrics.Api.WebApi.Models;
using ResultMetrics.Common.Result;
using ResultMetrics.Store.PostgreSQL;
using ResultMetrics.Store.PostgreSQL.Repositories;

namespace ResultMetrics.Api.WebApi.Features.ResultMetrics.UploadCsv;

public class UploadCsvCommandHandler : IRequestHandler<UploadCsvCommand, Result<MetricsResult>>
{
    private readonly IValuesRepository valuesRepository;
    private readonly IResultsRepository resultsRepository;
    private readonly ITransactionManager transactionManager;

    public UploadCsvCommandHandler(
        IValuesRepository valuesRepository,
        IResultsRepository resultsRepository,
        ITransactionManager transactionManager)
    {
        this.valuesRepository = valuesRepository;
        this.resultsRepository = resultsRepository;
        this.transactionManager = transactionManager;
    }
    
    public async Task<Result<MetricsResult>> Handle(UploadCsvCommand request, CancellationToken ct)
    {
        var csvFile = request.File;
        var fileName = csvFile.FileName;
        
        using var reader = new StreamReader(csvFile.OpenReadStream());
        
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };

        using var csv = new CsvReader(reader, config);


        var metrics = new MetricsAccumulator();
        var records = csv
            .GetRecords<ValueCsvRecord>()
            .Select(x =>
            {
                metrics.Add(x);
                if (metrics.Count > Constants.MaxRecords)
                {
                    throw new FaultException(
                        new Fault("DataSize", $"CSV file cannot contain more than {Constants.MaxRecords} records."));
                }
                
                return x.ToEntity(fileName);
            });

        await transactionManager.BeginTransactionAsync(ct);

        try
        {
            await valuesRepository.InsertRangeAsync(records);
        }
        catch (FaultException faultException)
        {
            await transactionManager.RollbackAsync(ct);
            return Result<MetricsResult>.Failure(faultException.Fault, HttpStatusCode.BadRequest);
        }
        catch (Exception exception)
        {
            await transactionManager.RollbackAsync(ct);
            return Result<MetricsResult>.Failure(new Fault("UnknowError", exception.Message), HttpStatusCode.BadRequest);
        }
       
        
        if (metrics.Count < Constants.MinRecords)
        {
            return Result<MetricsResult>.Failure(
                new Fault("DataSize", $"CSV file must contain at least {Constants.MinRecords} record"),
                HttpStatusCode.PaymentRequired);
        }
        
        var results = metrics.ToEntity(fileName);
        
        await resultsRepository.InsertAsync(results);

        await transactionManager.CommitAsync(ct);

        return Result<MetricsResult>.Success(results.ToClientModel(), HttpStatusCode.Created);
    }
}