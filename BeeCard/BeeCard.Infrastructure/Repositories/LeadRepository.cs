using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;

namespace BeeCard.Infrastructure.Repositories
{
    public class LeadRepository : BaseEntityRepository<Lead>, ILeadRepository
    {
        private readonly Context _context;

        public LeadRepository(Context context)
            : base(context)
        {
            _context = context;
        }
    }
}
