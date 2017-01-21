using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;

namespace BeeCard.Infrastructure.Repositories
{
    public class CompanyGroupRepository : BaseEntityRepository<CompanyGroup>, ICompanyGroupRepository
    {
        private readonly Context _context;

        public CompanyGroupRepository(Context context)
            : base(context)
        {
            _context = context;
        }
    }
}
