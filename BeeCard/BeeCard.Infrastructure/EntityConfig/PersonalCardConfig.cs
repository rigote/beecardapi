using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class PersonalCardConfig : BaseCardEntityConfig<PersonalCard>
    {
        public PersonalCardConfig()
            : base("PersonalCard")
        {
            Property(p => p.UserID).IsRequired();
            Property(p => p.Address).HasMaxLength(300);
            Property(p => p.SocialNetwork).HasMaxLength(1000);
            Property(p => p.Website).HasMaxLength(200);

            HasRequired(p => p.User)
                .WithMany(p => p.PersonalCards)
                .HasForeignKey(k => k.UserID);
        }
    }
}
