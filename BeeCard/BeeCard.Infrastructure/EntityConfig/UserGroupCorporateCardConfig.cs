using BeeCard.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BeeCard.Infrastructure.EntityConfig
{
    class UserGroupCorporateCardConfig : EntityTypeConfiguration<UserGroupCorporateCard>
    {
        public UserGroupCorporateCardConfig()
        {
            ToTable("UserGroup_CorporateCard");

            HasKey(k => new { k.CorporateCardID, k.UserGroupID });

            Property(p => p.CorporateCardID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.UserGroupID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Favorite).IsRequired();
            Property(p => p.Blacklist).IsRequired();
        }
    }
}
