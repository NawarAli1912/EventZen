using EventZen.Modules.Ticketing.Application.Carts;
using EventZen.Shared.Presentation.ApiResults;
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

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<CartService>();
    }
}
