using System.Data.Common;
using EventZen.Modules.Events.Application.Abstractions.Data;
using Npgsql;

namespace EventZen.Modules.Events.Infrastructure.Data;
internal sealed class DbConnectionFactory : IDbConnectionFactory
{
    private readonly NpgsqlDataSource _dataSource;

    public DbConnectionFactory(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await _dataSource.OpenConnectionAsync();
    }
}
