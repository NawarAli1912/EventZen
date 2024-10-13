using EventZen.Shared.Application.Caching;
using EventZen.Shared.Application.Clock;
using EventZen.Shared.Application.Data;
using EventZen.Shared.Application.EventBus;
using EventZen.Shared.Infrastructure.Caching;
using EventZen.Shared.Infrastructure.Clock;
using EventZen.Shared.Infrastructure.Data;
using EventZen.Shared.Infrastructure.Interceptors;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using StackExchange.Redis;

namespace EventZen.Shared.Infrastructure;
public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        Action<IRegistrationConfigurator>[] moduleConfigureConsumers,
        string databaseConnectionString,
        string redisConnectionString)
    {
        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.TryAddSingleton<PublishDomainEventsInterceptor>();

        try
        {
            IConnectionMultiplexer connectionMultiplexer =
                ConnectionMultiplexer.Connect(redisConnectionString);
            services.TryAddSingleton(connectionMultiplexer);
            services.AddStackExchangeRedisCache(options =>
            {
                options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer);
            });
        }
        catch
        {
            services.AddDistributedMemoryCache();
        }

        services.TryAddSingleton<ICacheService, CacheService>();
        services.TryAddSingleton<IEventBus, EventBus.EventBus>();
        services.AddMassTransit(configure =>
        {
            foreach (Action<IRegistrationConfigurator> configureConsumers in moduleConfigureConsumers)
            {
                configureConsumers(configure);
            }

            configure.SetKebabCaseEndpointNameFormatter();
            configure.UsingInMemory((context, cfg) =>
            {

                cfg.ConfigureEndpoints(context);
            });

        });

        return services;
    }
}
