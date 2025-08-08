using Domain.Common;

namespace Data.Repositories.Interface.Entities
{
    public interface IRepository<T> : Interface.IGenericRepository<T> where T : EntityBase
    {
    }
}
