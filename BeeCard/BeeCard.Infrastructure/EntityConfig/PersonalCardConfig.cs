using BeeCard.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BeeCard.Infrastructure.EntityConfig
{
    class PersonalCardConfig : EntityTypeConfiguration<PersonalCard>
    {
        public PersonalCardConfig()
        {

        }
    }
}
