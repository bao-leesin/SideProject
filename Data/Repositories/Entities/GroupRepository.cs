using Data.Repositories.Interface;
using Data.Repositories.Interface.Entities;

namespace Data.Repositories.Entities
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext db) : base(db) { }
    }
}
