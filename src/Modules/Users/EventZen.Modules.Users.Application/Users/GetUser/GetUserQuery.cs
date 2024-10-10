using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Users.Application.Users.GetUser;

public sealed record GetUserQuery(Guid UserId) : IQuery<UserResponse>;
