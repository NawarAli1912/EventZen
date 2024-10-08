namespace EventZen.Shared.Application.Clock;
public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}
