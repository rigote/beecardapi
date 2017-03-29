using BeeCard.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BeeCard.Infrastructure.EntityConfig
{
    class UserGroupPersonalCardConfig : EntityTypeConfiguration<UserGroupPersonalCard>
    {
        public UserGroupPersonalCardConfig()
        {
            ToTable("UserGroup_PersonalCard");

            HasKey(k => new { k.PersonalCardID, k.UserGroupID });

            Property(p => p.PersonalCardID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.UserGroupID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Favorite).IsRequired();
            Property(p => p.Blacklist).IsRequired();
        }
    }
}
