using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Interfaces.Services;

namespace BeeCard.Domain.Services
{
    public class CompanyTypeService : BaseService<CompanyType>, ICompanyTypeService
    {
        private readonly ICompanyTypeRepository _repository;

        public CompanyTypeService(ICompanyTypeRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
