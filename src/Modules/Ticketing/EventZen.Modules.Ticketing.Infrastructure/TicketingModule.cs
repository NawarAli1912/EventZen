using EventZen.Modules.Ticketing.Application.Abstraction.Data;
using EventZen.Modules.Ticketing.Application.Abstraction.Payments;
using EventZen.Modules.Ticketing.Application.Carts;
using EventZen.Modules.Ticketing.Domain.Customers;
using EventZen.Modules.Ticketing.Domain.Events;
using EventZen.Modules.Ticketing.Domain.Orders;
using EventZen.Modules.Ticketing.Domain.Payments;
using EventZen.Modules.Ticketing.Domain.Tickets;
using EventZen.Modules.Ticketing.Infrastructure.Customers;
using EventZen.Modules.Ticketing.Infrastructure.Database;
using EventZen.Modules.Ticketing.Infrastructure.Events;
using EventZen.Modules.Ticketing.Infrastructure.Orders;
using EventZen.Modules.Ticketing.Infrastructure.Payments;
using EventZen.Modules.Ticketing.Infrastructure.Tickets;
using EventZen.Modules.Ticketing.Presentation.Customers;
using EventZen.Shared.Infrastructure.Interceptors;
using EventZen.Shared.Presentation.ApiResults;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventZen.Modules.Ticketing.Infrastructure;
public static class TicketingModule
{

    public static IServiceCollection AddTicketingModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        return services;
    }

    public static void ConfigureConsumers(IRegistrationConfigurator registrationConfigurator)
    {
        registrationConfigurator.AddConsumer<UserRegisteredIntegrationEventConsumer>();
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TicketingDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    configuration.GetConnectionString("Database"),
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Ticketing))
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>())
                .UseSnakeCaseNamingConvention());

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TicketingDbContext>());

        services.AddSingleton<CartService>();
        services.AddSingleton<IPaymentService, PaymentService>();
    }
}
