using Microsoft.EntityFrameworkCore;
using ResultMetrics.Store.PostgreSQL.Models;

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
    
    public DbSet<Values> Values => Set<Values>();
    public DbSet<Results> Results => Set<Results>();
}