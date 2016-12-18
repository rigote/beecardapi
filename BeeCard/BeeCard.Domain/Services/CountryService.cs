using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Interfaces.Services;

namespace BeeCard.Domain.Services
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        private readonly ICountryRepository _repository;

        public CountryService(ICountryRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
