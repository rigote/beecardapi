using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Services;
using BeeCard.Domain.Interfaces.Repositories;

namespace BeeCard.Domain.Services
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        private readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
            : base(repository)
        {
            _repository = repository;
        }               
    }
}
