using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;

namespace BeeCard.Infrastructure.Repositories
{
    public class SubscriptionHistoryRepository : BaseEntityRepository<SubscriptionHistory>, ISubscriptionHistoryRepository
    {
        private readonly Context _context;

        public SubscriptionHistoryRepository(Context context)
            : base(context)
        {
            _context = context;
        }
    }
}
