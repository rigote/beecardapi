using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Interfaces.Services;

namespace BeeCard.Domain.Services
{
    public class LeadService : BaseService<Lead>, ILeadService
    {
        private readonly ILeadRepository _repository;

        public LeadService(ILeadRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
