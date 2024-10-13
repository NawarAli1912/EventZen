using System.Data.Common;

namespace EventZen.Modules.Ticketing.Application.Abstraction.Data;
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<DbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}

