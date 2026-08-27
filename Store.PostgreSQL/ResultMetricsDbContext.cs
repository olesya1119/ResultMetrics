using Microsoft.EntityFrameworkCore;

namespace ResultMetrics.Store.PostgreSQL;

public class ResultMetricsDbContext: DbContext
{
    public ResultMetricsDbContext(DbContextOptions<ResultMetricsDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResultMetricsDbContext).Assembly);
    }
}