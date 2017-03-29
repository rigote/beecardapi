using BeeCard.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BeeCard.Infrastructure.EntityConfig
{
    class UserClaimConfig : EntityTypeConfiguration<UserClaim>
    {
        public UserClaimConfig()
        {
            ToTable("UserClaim");

            HasKey(p => p.Id);

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed).HasColumnName("ID");
            Property(p => p.ClaimType);
            Property(p => p.ClaimValue);
            Property(p => p.UserId).HasColumnName("UserID");
        }
    }
}
