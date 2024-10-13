using EventZen.Shared.Domain.Abstractions;

namespace EventZen.Modules.Ticketing.Domain.Customers;
public static class CustomerErrors
{
    public static Error NotFound(Guid customerId) =>
        Error.NotFound("Customers.NotFound", $"The customer with the identifier {customerId} was not found");
}
