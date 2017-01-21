using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;

namespace BeeCard.Infrastructure.Repositories
{
    public class CompanyRepository : BaseEntityRepository<Company>, ICompanyRepository
    {
        private readonly Context _context;

        public CompanyRepository(Context context)
            : base(context)
        {
            _context = context;
        }
    }
}
