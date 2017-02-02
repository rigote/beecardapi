using BeeCard.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BeeCard.Infrastructure.EntityConfig
{
    class UserRoleConfig : EntityTypeConfiguration<UserRole>
    {
        public UserRoleConfig()
        {
            ToTable("UserRole");

            HasKey(p => new { p.RoleId, p.UserId });

            Property(p => p.RoleId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasColumnName("RoleID");
            Property(p => p.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasColumnName("UserID");
        }
    }
}
