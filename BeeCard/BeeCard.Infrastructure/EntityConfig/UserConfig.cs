using BeeCard.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BeeCard.Infrastructure.EntityConfig
{
    class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {

        }
    }
}
