using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;

namespace BeeCard.Infrastructure.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        private readonly Context _context;

        public CountryRepository(Context context)
            : base(context)
        {
            _context = context;
        }
    }
}
