using BeeCard.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BeeCard.Infrastructure.EntityConfig
{
    class CompanyConfig : EntityTypeConfiguration<Company>
    {
        public CompanyConfig()
        {

        }
    }
}
