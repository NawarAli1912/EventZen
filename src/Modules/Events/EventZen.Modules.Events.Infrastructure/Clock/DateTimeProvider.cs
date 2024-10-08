using EventZen.Modules.Events.Application.Abstractions.Clock;

namespace EventZen.Modules.Events.Infrastructure.Clock;
internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
