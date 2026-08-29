using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using ResultMetrics.Common.Configuration;

namespace ResultMetrics.Store.PostgreSQL;

public class ResultMetricsDbContextFactory : IDesignTimeDbContextFactory<ResultMetricsDbContext>
{
    public ResultMetricsDbContext CreateDbContext(string[] args)
    {
        var services = new ServiceCollection();

        services
            .AddApplicationOptions<PostgreSqlOptions>()
            .AddPostgreSql();
        
        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider .GetRequiredService<ResultMetricsDbContext>();
    }
}
    
