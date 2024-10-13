namespace EventZen.Modules.Ticketing.Application.Abstraction.Payments;

public sealed record PaymentResponse(Guid TransactionId, decimal Amount, string Currency);
