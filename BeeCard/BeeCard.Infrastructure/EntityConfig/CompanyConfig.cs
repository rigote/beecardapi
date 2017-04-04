using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class CompanyConfig : BaseEntityConfig<Company>
    {
        public CompanyConfig()
            : base("Company")
        {
            Property(p => p.Address).HasMaxLength(150).IsRequired();
            Property(p => p.Address2).HasMaxLength(150).IsOptional();
            Property(p => p.Number).HasMaxLength(10).IsRequired();
            Property(p => p.City).HasMaxLength(100).IsRequired();
            Property(p => p.CompanyTypeID).IsRequired();
            Property(p => p.ContactEmail).HasMaxLength(100).IsRequired();
            Property(p => p.ContactName).HasMaxLength(200).IsRequired();
            Property(p => p.ContactPhone).HasMaxLength(50).IsRequired();
            Property(p => p.CountryID).IsRequired();
            Property(p => p.Logo).HasMaxLength(50);
            Property(p => p.Name).HasMaxLength(200).IsRequired();
            Property(p => p.Neighborhood).HasMaxLength(100).IsRequired();
            Property(p => p.Password).HasMaxLength(500).IsRequired();
            Property(p => p.PlanID).IsRequired();
            Property(p => p.PostalCode).HasMaxLength(20).IsRequired();
            Property(p => p.SocialNetwork).HasMaxLength(1000);
            Property(p => p.CardIdentityConfig);
            Property(p => p.State).HasMaxLength(100).IsRequired();
            Property(p => p.SubscriptionDate);
            Property(p => p.SubscriptionPrice);
            Property(p => p.SubscriptionStatus);
            Property(p => p.SubscriptionType);
            Property(p => p.Website).HasMaxLength(200);

            HasRequired(c => c.Plan)
                .WithMany(c => c.Companies)
                .HasForeignKey(k => k.PlanID);
            HasRequired(c => c.CompanyType)
                .WithMany(c => c.Companies)
                .HasForeignKey(k => k.CompanyTypeID);
            HasRequired(c => c.Country)
                .WithMany(c => c.Companies)
                .HasForeignKey(k => k.CountryID);         
        }
    }
}
