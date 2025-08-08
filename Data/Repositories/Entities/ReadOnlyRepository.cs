using System.Linq.Expressions;
using Data.Repositories.Interface;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Entities
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : EntityBase
    {
        protected readonly AppDbContext _db;
        protected readonly DbSet<T> _set;

        public ReadOnlyRepository(AppDbContext db)
        {
            _db = db;
            _set = _db.Set<T>();
        }

        public IQueryable<T> Query() => _set.AsNoTracking().AsQueryable();

        public async Task<T?> GetByIdAsync(int id, CancellationToken ct = default)
            => await _set.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, ct);

        public async Task<IReadOnlyList<T>> ListAsync(CancellationToken ct = default)
            => await _set.AsNoTracking().ToListAsync(ct);

        public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
            => await _set.AsNoTracking().Where(predicate).ToListAsync(ct);

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken ct = default)
            => predicate is null ? await _set.CountAsync(ct) : await _set.CountAsync(predicate, ct);

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
            => await _set.AsNoTracking().AnyAsync(predicate, ct);
    }
}
