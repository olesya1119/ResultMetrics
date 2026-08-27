namespace ResultMetrics.Store.PostgreSQL.Repositories;

public class ResultsRepository : IResultsRepository
{
    private readonly ResultMetricsDbContext context;
    
    public ResultsRepository(ResultMetricsDbContext context)
    {
        this.context = context;
    }
}