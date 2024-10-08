using System.Data.Common;

namespace EventZen.Shared.Application.Data;
public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}
