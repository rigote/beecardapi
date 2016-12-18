using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Interfaces.Services;

namespace BeeCard.Domain.Services
{
    public class PlanService : BaseService<Plan>, IPlanService
    {
        private readonly IPlanRepository _repository;

        public PlanService(IPlanRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
