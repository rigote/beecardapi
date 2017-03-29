using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class UserGroupConfig : BaseEntityConfig<UserGroup>
    {
        public UserGroupConfig()
            : base("UserGroup")
        {
            Property(p => p.UserID).IsRequired();
            Property(p => p.Name).HasMaxLength(100).IsRequired();

            HasMany(c => c.UserGroupCorporateCards)
                .WithRequired(c => c.UserGroup)
                .HasForeignKey(k => k.UserGroupID);

            HasMany(c => c.UserGroupPersonalCards)
                .WithRequired(c => c.UserGroup)
                .HasForeignKey(k => k.UserGroupID);
        }
    }
}
