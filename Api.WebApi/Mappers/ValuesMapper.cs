using System;
using ResultMetrics.Api.WebApi.Features.ResultMetrics.UploadCsv.Models;
using ResultMetrics.Store.PostgreSQL.Models;

namespace ResultMetrics.Api.WebApi.Mappers;

public static class ValuesMapper
{
    public static Values ToEntity(this ValueCsvRecord valueCsvRecord, string fileName) => new Values
    {
        FileName = fileName,
        Date = valueCsvRecord.Date,
        ExecutionTime = valueCsvRecord.ExecutionTime,
        Value = valueCsvRecord.Value
    };
}