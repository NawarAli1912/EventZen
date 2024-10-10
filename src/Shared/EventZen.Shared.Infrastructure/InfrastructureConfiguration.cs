using EventZen.Shared.Application.Caching;
using EventZen.Shared.Application.Clock;
using EventZen.Shared.Application.Data;
using EventZen.Shared.Infrastructure.Caching;
using EventZen.Shared.Infrastructure.Clock;
using EventZen.Shared.Infrastructure.Data;
using EventZen.Shared.Infrastructure.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using StackExchange.Redis;

namespace EventZen.Shared.Infrastructure;
public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string databaseConnectionString,
        string redisConnectionString)
    {
        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.TryAddSingleton<PublishDomainEventsInterceptor>();

        IConnectionMultiplexer connectionMultiplexer =
            ConnectionMultiplexer.Connect(redisConnectionString);
        services.TryAddSingleton(connectionMultiplexer);
        services.AddStackExchangeRedisCache(options =>
        {
            options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer);
        });
        services.TryAddSingleton<ICacheService, CacheService>();

        return services;
    }
}
