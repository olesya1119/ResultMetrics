using ResultMetrics.Store.PostgreSQL.Models;

namespace ResultMetrics.Store.PostgreSQL.Repositories;

public class ResultsRepository : IResultsRepository
{
    private readonly ResultMetricsDbContext context;
    
    public ResultsRepository(ResultMetricsDbContext context)
    {
        this.context = context;
    }

    public async Task InsertAsync(Results results, CancellationToken ct = default)
    {
        await context.Results.AddAsync(results, ct);
        await context.SaveChangesAsync(ct);
    }
}