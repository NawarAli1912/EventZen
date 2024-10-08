using EventZen.Modules.Events.Domain.Events;
using EventZen.Modules.Events.Infrastructure.Database;

namespace EventZen.Modules.Events.Infrastructure.Events;
internal sealed class EventRepository : IEventRepository
{
    private readonly EventsDbContext _context;

    public EventRepository(EventsDbContext context)
    {
        _context = context;
    }

    public Task<Event?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Insert(Event @event)
    {
        _context.Add(@event);
    }
}
