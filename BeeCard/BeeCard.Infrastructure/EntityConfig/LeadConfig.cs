using BeeCard.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BeeCard.Infrastructure.EntityConfig
{
    class LeadConfig : EntityTypeConfiguration<Lead>
    {
        public LeadConfig()
        {

        }
    }
}
