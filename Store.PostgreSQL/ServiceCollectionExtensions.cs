using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ResultMetrics.Store.PostgreSQL;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPostgreSql(this IServiceCollection services)
    {
        services.AddDbContext<ResultMetricsDbContext>((serviceProvider, dbOptions) =>
        {
            var options = serviceProvider.GetRequiredService<PostgreSqlOptions>();

            dbOptions
                .UseNpgsql(options.ConnectionString)
                .UseSnakeCaseNamingConvention();
        });
        
        return services;
    }
}