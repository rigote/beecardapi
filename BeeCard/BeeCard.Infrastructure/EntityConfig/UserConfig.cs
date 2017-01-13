using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class UserConfig : BaseEntityConfig<User>
    {
        public UserConfig()
            : base("User")
        {
            Property(p => p.Birthdate).IsRequired();
            Property(p => p.Email).HasMaxLength(100).IsRequired();
            Property(p => p.Password).HasMaxLength(500).IsRequired();
            Property(p => p.Firstname).HasMaxLength(100).IsRequired();
            Property(p => p.Lastname).HasMaxLength(150).IsRequired();
            Property(p => p.Cellphone).HasMaxLength(50);
            Property(p => p.Photo).HasMaxLength(50);
        }
    }
}
