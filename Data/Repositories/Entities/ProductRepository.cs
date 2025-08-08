using Data.Repositories.Interface;
using Data.Repositories.Interface.Entities;

namespace Data.Repositories.Entities
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext db) : base(db) { }
    }
}
