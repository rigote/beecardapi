using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class LeadConfig : BaseEntityConfig<Lead>
    {
        public LeadConfig()
            : base("Lead")
        {
            Property(p => p.PersonalCardID).IsOptional();
            Property(p => p.CorporateCardID).IsOptional();
            Property(p => p.RequestStatus).IsRequired();

            HasOptional(l => l.CorporateCard)
                .WithMany(l => l.Leads)
                .HasForeignKey(k => k.CorporateCardID);
            HasOptional(l => l.PersonalCard)
                .WithMany(l => l.Leads)
                .HasForeignKey(k => k.PersonalCardID);
        }
    }
}
