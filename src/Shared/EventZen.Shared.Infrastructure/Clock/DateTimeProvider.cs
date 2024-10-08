using EventZen.Shared.Application.Clock;

namespace EventZen.Shared.Infrastructure.Clock;
internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
