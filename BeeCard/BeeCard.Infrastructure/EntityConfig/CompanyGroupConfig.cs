using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class CompanyGroupConfig : BaseEntityConfig<CompanyGroup>
    {
        public CompanyGroupConfig()
            : base("CompanyGroup")
        {
            Property(p => p.CompanyID);
            Property(p => p.Name).HasMaxLength(100).IsRequired();

            HasRequired(c => c.Company)
                .WithMany(g => g.CompanyGroups)
                .HasForeignKey(k => k.CompanyID);
        }
    }
}
