using System.Data.Common;

namespace EventZen.Modules.Events.Application.Abstractions.Data;
public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}
