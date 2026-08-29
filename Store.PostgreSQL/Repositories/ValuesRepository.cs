using ResultMetrics.Store.PostgreSQL.Models;

namespace ResultMetrics.Store.PostgreSQL.Repositories;

public class ValuesRepository : IValuesRepository
{
    private readonly ResultMetricsDbContext context;
    
    private const int BatchSize = 100;

    public ValuesRepository(ResultMetricsDbContext context)
    {
        this.context = context;
    }

    public async Task InsertRangeAsync(IEnumerable<Values> values, CancellationToken ct = default)
    {
        foreach (var batch in values.Chunk(BatchSize))
        {
            await context.Values.AddRangeAsync(batch, ct);
            await context.SaveChangesAsync(ct);
            
            context.ChangeTracker.Clear();
        }
    }
}