using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class PersonalCardConfig : BaseCardEntityConfig<PersonalCard>
    {
        public PersonalCardConfig()
            : base("PersonalCard")
        {
            Property(p => p.UserID).IsRequired();
            Property(p => p.Address).HasMaxLength(150).IsOptional();
            Property(p => p.Address2).HasMaxLength(150).IsOptional();
            Property(p => p.Number).HasMaxLength(10).IsOptional();
            Property(p => p.City).HasMaxLength(100).IsOptional();
            Property(p => p.PostalCode).HasMaxLength(20).IsOptional();
            Property(p => p.Neighborhood).HasMaxLength(100).IsOptional();
            Property(p => p.Occupation).HasMaxLength(150).IsOptional();
            Property(p => p.Photo);
            Property(p => p.SocialNetwork).HasMaxLength(1000);
            Property(p => p.Website).HasMaxLength(200);
            Property(p => p.State).HasMaxLength(30).IsOptional();
            Property(p => p.Bio).HasMaxLength(500).IsOptional();

            HasRequired(p => p.User)
                .WithMany(p => p.PersonalCards)
                .HasForeignKey(k => k.UserID);
        }
    }
}
