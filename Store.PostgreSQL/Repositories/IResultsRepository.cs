using ResultMetrics.Store.PostgreSQL.Models;

namespace ResultMetrics.Store.PostgreSQL.Repositories;

public interface IResultsRepository
{
    public Task InsertAsync(Results results, CancellationToken ct = default);
    
    public Task DeleteByFileNameAsync(string fileName, CancellationToken ct);
    
    Task<IReadOnlyCollection<Results>> GetAsync(
        string? fileName,
        DateTime? minDate,
        DateTime? maxDate,
        double? minAvgValue,
        double? maxAvgValue,
        double? minAvgExecutionTime,
        double? maxAvgExecutionTime,
        CancellationToken ct);
}