using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Interfaces.Services;

namespace BeeCard.Domain.Services
{
    public class CorporateCardService : BaseService<CorporateCard>, ICorporateCardService
    {
        private readonly ICorporateCardRepository _repository;

        public CorporateCardService(ICorporateCardRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
