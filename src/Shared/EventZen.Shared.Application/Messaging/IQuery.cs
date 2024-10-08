using EventZen.Shared.Domain.Abstractions;
using MediatR;

namespace EventZen.Shared.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
