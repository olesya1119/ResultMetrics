using ResultMetrics.Store.PostgreSQL.Models;

namespace ResultMetrics.Store.PostgreSQL.Repositories;

public interface IValuesRepository
{
    public Task InsertRangeAsync(IEnumerable<Values> values, CancellationToken ct = default); 
}