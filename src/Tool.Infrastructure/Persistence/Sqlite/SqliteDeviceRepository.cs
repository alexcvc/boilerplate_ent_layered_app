using Tool.Core.Domain.Devices;
using Tool.Core.Ports.Persistence;

namespace Tool.Infrastructure.Persistence.Sqlite;

/// <summary>
/// Stub repository. Replace with real SQLite (EF Core/Dapper) implementation.
/// </summary>
public sealed class SqliteDeviceRepository : IRepository<Device>
{
    private readonly List<Device> _memory = new();

    public Task AddAsync(Device entity, CancellationToken ct = default)
    {
        _memory.Add(entity);
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<Device>> GetAllAsync(CancellationToken ct = default)
        => Task.FromResult((IReadOnlyList<Device>)_memory);
}
