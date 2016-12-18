using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Interfaces.Services;

namespace BeeCard.Domain.Services
{
    public class SubscriptionHistoryService : BaseService<SubscriptionHistory>, ISubscriptionHistoryService
    {
        private readonly ISubscriptionHistoryRepository _repository;

        public SubscriptionHistoryService(ISubscriptionHistoryRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
