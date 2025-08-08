using Data.Repositories.Interface.Entities;
using Domain.Common;

namespace Data.Repositories.Entities
{
    public class Repository<T> : Repositories.GenericRepository<T>, IRepository<T> where T : EntityBase
    {
        public Repository(AppDbContext db) : base(db)
        {
        }
    }
}
