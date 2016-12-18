using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Interfaces.Services;

namespace BeeCard.Domain.Services
{
    public class CompanyGroupService : BaseService<CompanyGroup>, ICompanyGroupService
    {
        private readonly ICompanyGroupRepository _repository;

        public CompanyGroupService(ICompanyGroupRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
