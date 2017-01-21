using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;

namespace BeeCard.Infrastructure.Repositories
{
    public class UserGroupRepository : BaseEntityRepository<UserGroup>, IUserGroupRepository
    {
        private readonly Context _context;

        public UserGroupRepository(Context context)
            : base(context)
        {
            _context = context;
        }
    }
}
