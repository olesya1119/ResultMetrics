using Microsoft.EntityFrameworkCore.Storage;

namespace ResultMetrics.Store.PostgreSQL;

public class TransactionManager : ITransactionManager
{
    private readonly ResultMetricsDbContext context;

    private IDbContextTransaction transaction;
    
    public TransactionManager(ResultMetricsDbContext context)
    {
        this.context = context;
    }
    
    public async Task BeginTransactionAsync(CancellationToken ct = default)
    {
        transaction = await context.Database.BeginTransactionAsync(ct);
    }

    public async Task CommitAsync(CancellationToken ct = default)
    {
        await transaction.CommitAsync(ct);
    }

    public async Task RollbackAsync(CancellationToken ct = default)
    {
        await  transaction.RollbackAsync(ct);
    }
}