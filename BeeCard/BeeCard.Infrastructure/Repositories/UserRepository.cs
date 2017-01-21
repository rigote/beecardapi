using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;

namespace BeeCard.Infrastructure.Repositories
{
    public class UserRepository : BaseEntityRepository<User>, IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
            : base(context)
        {
            _context = context;
        }
    }
}
