using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;

namespace BeeCard.Infrastructure.Repositories
{
    public class CompanyTypeRepository : BaseEntityRepository<CompanyType>, ICompanyTypeRepository
    {
        private readonly Context _context;

        public CompanyTypeRepository(Context context)
            : base(context)
        {
            _context = context;
        }
    }
}
