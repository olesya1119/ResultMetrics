using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace ResultMetrics.Common.Configuration;

public static class ServiceCollectionExtensions
{
    private const string OptionsFileName = "options.json";

    public static IServiceCollection AddApplicationOptions<TOptions>(this IServiceCollection services) where TOptions : class
    {
        var options = LoadOptions<TOptions>();
        services.AddSingleton(options);
        return services;
    }

    private static TOptions LoadOptions<TOptions>() where TOptions : class
    {
        if (!File.Exists(OptionsFileName))
        {
            throw new FileNotFoundException($"Configuration file '{OptionsFileName}' was not found.");
        }

        var json = File.ReadAllText(OptionsFileName);

        return JsonSerializer.Deserialize<TOptions>(json, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true }) 
               ?? throw new InvalidOperationException(
                   $"Failed to deserialize '{OptionsFileName}' to {typeof(TOptions).Name}.");
    }
}