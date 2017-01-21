using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;

namespace BeeCard.Infrastructure.Repositories
{
    public class PersonalCardRepository : BaseEntityRepository<PersonalCard>, IPersonalCardRepository
    {
        private readonly Context _context;

        public PersonalCardRepository(Context context)
            : base(context)
        {
            _context = context;
        }
    }
}
