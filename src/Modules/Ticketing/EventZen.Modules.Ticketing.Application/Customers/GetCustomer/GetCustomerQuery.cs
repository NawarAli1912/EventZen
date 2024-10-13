using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Ticketing.Application.Customers.GetCustomer;

public sealed record GetCustomerQuery(Guid CustomerId) : IQuery<CustomerResponse>;
