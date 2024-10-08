using EventZen.Modules.Events.Domain.Abstractions;
using MediatR;

namespace EventZen.Modules.Events.Application.Abstractions.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
