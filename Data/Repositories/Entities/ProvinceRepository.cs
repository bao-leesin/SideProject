using Data.Repositories.Interface;
using Data.Repositories.Interface.Entities;

namespace Data.Repositories.Entities
{
    public class ProvinceRepository : Repository<Province>, IProvinceRepository
    {
        public ProvinceRepository(AppDbContext db) : base(db) { }
    }
}
