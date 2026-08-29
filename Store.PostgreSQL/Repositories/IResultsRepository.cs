using ResultMetrics.Store.PostgreSQL.Models;

namespace ResultMetrics.Store.PostgreSQL.Repositories;

public interface IResultsRepository
{
    public Task InsertAsync(Results results, CancellationToken ct = default);
}