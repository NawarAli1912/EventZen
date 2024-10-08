using EventZen.Modules.Events.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EventZen.Api.Extensions;

internal static class MigrationExtensions
{
    internal static void ApplyMigration(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplyMigration<EventsDbContext>(scope);
    }

    private static void ApplyMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        context.Database.Migrate();
    }
}
