using BeeCard.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BeeCard.Infrastructure.EntityConfig
{
    class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            ToTable("User");

            HasKey(p => p.Id);

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
            Property(p => p.Birthdate).IsRequired();
            Property(p => p.Email).HasMaxLength(100).IsRequired();
            Property(p => p.Firstname).HasMaxLength(100).IsRequired();
            Property(p => p.Lastname).HasMaxLength(150).IsRequired();
            Property(p => p.Photo).HasMaxLength(50);
            Property(p => p.AccessFailedCount);
            Property(p => p.Email);
            Property(p => p.EmailConfirmed);
            Property(p => p.LockoutEnabled);
            Property(p => p.LockoutEndDateUtc);
            Property(p => p.PasswordHash);
            Property(p => p.PhoneNumber);
            Property(p => p.PhoneNumberConfirmed);
            Property(p => p.SecurityStamp);
            Property(p => p.TwoFactorEnabled);
            Property(p => p.UserName);

            HasMany(c => c.Logins)
                .WithOptional()
                .HasForeignKey(c => c.UserId);
            HasMany(c => c.Claims)
                .WithOptional()
                .HasForeignKey(c => c.UserId);
            HasMany(c => c.Roles)
                .WithRequired()
                .HasForeignKey(c => c.UserId);
        }
    }
}
