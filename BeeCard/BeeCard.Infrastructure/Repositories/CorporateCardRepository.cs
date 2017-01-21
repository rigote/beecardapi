using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;

namespace BeeCard.Infrastructure.Repositories
{
    public class CorporateCardRepository : BaseEntityRepository<CorporateCard>, ICorporateCardRepository
    {
        private readonly Context _context;

        public CorporateCardRepository(Context context)
            : base(context)
        {
            _context = context;
        }
    }
}
