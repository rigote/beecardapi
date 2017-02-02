using BeeCard.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BeeCard.Infrastructure.EntityConfig
{
    class UserLoginConfig : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginConfig()
        {
            ToTable("UserLogin");

            HasKey(p => new { p.LoginProvider, p.ProviderKey, p.UserId });

            Property(p => p.LoginProvider).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.ProviderKey).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasColumnName("UserID");
        }
    }
}
