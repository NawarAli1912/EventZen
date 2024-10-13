using EventZen.Modules.Ticketing.Application.Abstraction.Data;
using EventZen.Modules.Ticketing.Domain.Customers;
using EventZen.Shared.Application.Messaging;
using EventZen.Shared.Domain.Abstractions;

namespace EventZen.Modules.Ticketing.Application.Customers.UpdateCustomer;

internal sealed class UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateCustomerCommand>
{
    public async Task<Result> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer? customer = await customerRepository.GetAsync(request.CustomerId, cancellationToken);

        if (customer is null)
        {
            return Result.Failure(CustomerErrors.NotFound(request.CustomerId));
        }

        customer.Update(request.FirstName, request.LastName);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
