using EventZen.Modules.Events.Domain.Events;
using EventZen.Modules.Events.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EventZen.Modules.Events.Infrastructure.Events;
internal sealed class EventRepository : IEventRepository
{
    private readonly EventsDbContext _context;

    public EventRepository(EventsDbContext context)
    {
        _context = context;
    }

    public async Task<Event?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Events.SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public void Insert(Event @event)
    {
        _context.Events.Add(@event);
    }
}
