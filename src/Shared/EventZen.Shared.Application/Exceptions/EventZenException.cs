using EventZen.Shared.Domain.Abstractions;

namespace EventZen.Shared.Application.Exceptions;
public sealed class EventZenException(
    string requestName, Error? error = default,
    Exception? innerException = default)
    : Exception("Application exception", innerException)
{
    public string RequestName { get; } = requestName;

    public Error? Error { get; } = error;
}
