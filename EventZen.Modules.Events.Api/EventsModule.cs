using EventZen.Modules.Events.Api.Database;
using EventZen.Modules.Events.Api.Events;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventZen.Modules.Events.Api;
public static class EventsModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateEvent.MapEndPoint(app);
        GetEvent.MapEndPoint(app);
    }

    public static IServiceCollection AddEventModules(this IServiceCollection services,
        IConfiguration configuration)
    {
        string dbConnectionString = configuration.GetConnectionString("Database")!;

        services.AddDbContext<EventsDbContext>(options =>
            options.UseNpgsql(
                dbConnectionString,
                npgsqlOptions => npgsqlOptions
                    .MigrationsHistoryTable(
                        HistoryRepository.DefaultTableName,
                        Schemas.Events))
            .UseSnakeCaseNamingConvention());

        return services;
    }
}
