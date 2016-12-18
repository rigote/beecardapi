using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Interfaces.Services;

namespace BeeCard.Domain.Services
{
    public class PersonalCardService : BaseService<PersonalCard>, IPersonalCardService
    {
        private readonly IPersonalCardRepository _repository;

        public PersonalCardService(IPersonalCardRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
