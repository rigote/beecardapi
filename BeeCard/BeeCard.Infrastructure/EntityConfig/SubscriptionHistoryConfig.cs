using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class SubscriptionHistoryConfig : BaseEntityConfig<SubscriptionHistory>
    {
        public SubscriptionHistoryConfig()
            : base("SubscriptionHistory")
        {
            Property(p => p.SubscriptionDate);
            Property(p => p.SubscriptionPrice);
            Property(p => p.SubscriptionStatus);
            Property(p => p.SubscriptionType);

            HasRequired(s => s.Company)
                .WithMany(s => s.SubscriptionsHistory)
                .HasForeignKey(s => s.CompanyID);
        }
    }
}
