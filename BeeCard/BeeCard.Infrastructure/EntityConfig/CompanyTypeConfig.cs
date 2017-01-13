using BeeCard.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BeeCard.Infrastructure.EntityConfig
{
    class CompanyTypeConfig : BaseEntityConfig<CompanyType>
    {
        public CompanyTypeConfig()
            : base("CompanyType")
        {
            Property(p => p.Name).HasMaxLength(150).IsRequired();
        }
    }
}
