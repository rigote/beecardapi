using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class CorporateCardConfig : BaseCardEntityConfig<CorporateCard>
    {
        public CorporateCardConfig()
            : base("CorporateCard")
        {
            Property(p => p.CompanyID).IsRequired();
            Property(p => p.UserID).IsRequired();
            Property(p => p.Department).HasMaxLength(100);
            Property(p => p.Occupation).HasMaxLength(100);

            HasRequired(c => c.User)
                .WithMany(c => c.CorporateCards)
                .HasForeignKey(k => k.UserID);
            HasRequired(c => c.Company)
                .WithMany(c => c.CorporateCards)
                .HasForeignKey(k => k.CompanyID);
        }
    }
}
