using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ResultMetrics.Store.PostgreSQL;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPostgreSql(this IServiceCollection services, PostgreSqlOptions options)
    {
        services.AddDbContext<ResultMetricsDbContext>(dbOptions => dbOptions.UseNpgsql(options.ConnectionString));
        return services;
    }
}