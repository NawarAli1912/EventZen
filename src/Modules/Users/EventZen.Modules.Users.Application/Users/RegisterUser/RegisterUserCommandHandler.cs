using EventZen.Modules.Users.Application.Abstractions.Data;
using EventZen.Modules.Users.Domain.Users;
using EventZen.Shared.Application.Messaging;
using EventZen.Shared.Domain.Abstractions;

namespace EventZen.Modules.Users.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(request.Email, request.FirstName, request.LastName);

        userRepository.Insert(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
