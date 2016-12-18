using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;

namespace BeeCard.Infrastructure.Repositories
{
    public class PlanRepository : BaseRepository<Plan>, IPlanRepository
    {
        private readonly Context _context;

        public PlanRepository(Context context)
            : base(context)
        {
            _context = context;
        }
    }
}
