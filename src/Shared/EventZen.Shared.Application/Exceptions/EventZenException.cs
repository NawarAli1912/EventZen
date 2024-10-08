using EventZen.Shared.Domain.Abstractions;

namespace EventZen.Shared.Application.Exceptions;
public sealed class EventZenException : Exception
{
    public EventZenException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

    public string RequestName { get; }

    public Error? Error { get; }
}
