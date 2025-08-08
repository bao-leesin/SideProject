using System.Linq.Expressions;
using Domain.Common;

namespace Data.Repositories.Interface
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        // Query
        IQueryable<T> Query();

        // Read
        Task<T?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<T>> ListAsync(CancellationToken ct = default);
        Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken ct = default);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);

        // Write
        Task<T> AddAsync(T entity, CancellationToken ct = default);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Remove(T entity);
        Task RemoveByIdAsync(int id, CancellationToken ct = default);

        // Commit
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
