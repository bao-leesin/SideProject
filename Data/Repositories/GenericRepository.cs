using System.Linq.Expressions;
using Data.Repositories.Interface;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected readonly AppDbContext _db;
        protected readonly DbSet<T> _set;

        public GenericRepository(AppDbContext db)
        {
            _db = db;
            _set = _db.Set<T>();
        }

        public IQueryable<T> Query() => _set.AsQueryable();

        public async Task<T?> GetByIdAsync(int id, CancellationToken ct = default)
            => await _set.FindAsync([id], ct);

        public async Task<IReadOnlyList<T>> ListAsync(CancellationToken ct = default)
            => await _set.AsNoTracking().ToListAsync(ct);

        public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
            => await _set.AsNoTracking().Where(predicate).ToListAsync(ct);

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken ct = default)
            => predicate is null ? await _set.CountAsync(ct) : await _set.CountAsync(predicate, ct);

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
            => await _set.AnyAsync(predicate, ct);

        public async Task<T> AddAsync(T entity, CancellationToken ct = default, bool saving = true)
        {
            await _set.AddAsync(entity, ct);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default)
            => await _set.AddRangeAsync(entities, ct);

        public void Update(T entity) => _set.Update(entity);

        public void UpdateRange(IEnumerable<T> entities) => _set.UpdateRange(entities);

        public void Remove(T entity) => _set.Remove(entity);

        public async Task RemoveByIdAsync(int id, CancellationToken ct = default)
        {
            var existing = await GetByIdAsync(id, ct);
            if (existing is not null) _set.Remove(existing);
        }

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
            => _db.SaveChangesAsync(ct);


    }
}
