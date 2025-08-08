using Data.Repositories.Interface;
using Data.Repositories.Interface.Entities;

namespace Data.Repositories.Entities
{
    public class FunctionRepository : Repository<Function>, IFunctionRepository
    {
        public FunctionRepository(AppDbContext db) : base(db) { }
    }
}
