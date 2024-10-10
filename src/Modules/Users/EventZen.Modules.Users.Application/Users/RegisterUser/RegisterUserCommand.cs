using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Users.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(string Email, string Password, string FirstName, string LastName)
    : ICommand<Guid>;
