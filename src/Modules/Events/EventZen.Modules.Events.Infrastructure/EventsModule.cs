using EventZen.Modules.Events.Application.Abstractions.Data;
using EventZen.Modules.Events.Domain.Categories;
using EventZen.Modules.Events.Domain.Events;
using EventZen.Modules.Events.Domain.TicketTypes;
using EventZen.Modules.Events.Infrastructure.Categories;
using EventZen.Modules.Events.Infrastructure.Database;
using EventZen.Modules.Events.Infrastructure.Events;
using EventZen.Modules.Events.Infrastructure.TicketTypes;
using EventZen.Shared.Infrastructure.Interceptors;
using EventZen.Shared.Presentation.ApiResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventZen.Modules.Events.Infrastructure;
public static class EventsModule
{
    public static IServiceCollection AddEventModules(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);
        services.AddInfrastructure(configuration);
        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database")!;

        services.AddDbContext<EventsDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>()));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventsDbContext>());

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
}
