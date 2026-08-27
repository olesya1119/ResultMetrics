namespace ResultMetrics.Store.PostgreSQL.Repositories;

public class ValuesRepository : IValuesRepository
{
    private readonly ResultMetricsDbContext context;

    public ValuesRepository(ResultMetricsDbContext context)
    {
        this.context = context;
    }
}