using EventZen.Modules.Events.Api.Events;
using Microsoft.EntityFrameworkCore;

namespace EventZen.Modules.Events.Api.Database;
public sealed class EventsDbContext : DbContext
{
    internal DbSet<Event> Events { get; set; }

    public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);

        base.OnModelCreating(modelBuilder);
    }
}
