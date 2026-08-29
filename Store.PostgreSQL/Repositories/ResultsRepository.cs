using Microsoft.EntityFrameworkCore;
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
    
    public async Task DeleteByFileNameAsync(string fileName, CancellationToken ct)
    {
        await context.Results
            .Where(x => x.FileName == fileName)
            .ExecuteDeleteAsync(ct);
    }
    
    public async Task<IReadOnlyCollection<Results>> GetAsync(
        string? fileName,
        DateTime? minDate,
        DateTime? maxDate,
        double? minAvgValue,
        double? maxAvgValue,
        double? minAvgExecutionTime,
        double? maxAvgExecutionTime,
        CancellationToken ct)
    {
        var query = context.Results.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(fileName))
        {
            query = query.Where(x => x.FileName == fileName);
        }

        if (minDate.HasValue)
        {
            query = query.Where(x => x.MinDate >= minDate.Value);
        }

        if (maxDate.HasValue)
        {
            query = query.Where(x => x.MinDate <= maxDate.Value);
        }

        if (minAvgValue.HasValue)
        {
            query = query.Where(x => x.AvgValue >= minAvgValue.Value);
        }

        if (maxAvgValue.HasValue)
        {
            query = query.Where(x => x.AvgValue <= maxAvgValue.Value);
        }

        if (minAvgExecutionTime.HasValue)
        {
            query = query.Where(
                x => x.AvgExecutionTime >= minAvgExecutionTime.Value);
        }

        if (maxAvgExecutionTime.HasValue)
        {
            query = query.Where(
                x => x.AvgExecutionTime <= maxAvgExecutionTime.Value);
        }

        return await query
            .OrderBy(x => x.MinDate)
            .ToListAsync(ct);
    }
}