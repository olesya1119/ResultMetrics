using ResultMetrics.Store.PostgreSQL.Models;

namespace ResultMetrics.Store.PostgreSQL.Repositories;

public interface IValuesRepository
{
    public Task InsertRangeAsync(IEnumerable<Values> values, CancellationToken ct = default);
    
    public Task DeleteByFileNameAsync(string fileName, CancellationToken ct);
    
    Task<IReadOnlyCollection<Values>> GetLatestAsync(string fileName, int count, CancellationToken ct);
}