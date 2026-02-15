namespace Tool.Core.Ports.Persistence;

public interface IRepository<T>
{
    Task AddAsync(T entity, CancellationToken ct = default);
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default);
}
