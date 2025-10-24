using Data.Repositories.Interface;
using Data.Repositories.Interface.Entities;

namespace Data.Repositories.Entities
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext db) : base(db) { }

        
    }
}
