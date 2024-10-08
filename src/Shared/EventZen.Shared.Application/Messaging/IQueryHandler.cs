using EventZen.Shared.Domain.Abstractions;
using MediatR;

namespace EventZen.Shared.Application.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
