using ResultMetrics.Common.Configuration;
using ResultMetrics.Store.PostgreSQL;
using ResultMetrics.Store.PostgreSQL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(
        typeof(Program).Assembly);
});

builder.Services.AddScoped<IValuesRepository, ValuesRepository>();
builder.Services.AddScoped<IResultsRepository, ResultsRepository>();
builder.Services.AddScoped<ITransactionManager, TransactionManager>().AddApplicationOptions<PostgreSqlOptions>();

builder.Services.AddPostgreSql();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();