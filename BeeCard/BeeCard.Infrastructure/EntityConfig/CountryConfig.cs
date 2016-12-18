using BeeCard.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BeeCard.Infrastructure.EntityConfig
{
    class CountryConfig : EntityTypeConfiguration<Country>
    {
        public CountryConfig()
        {

        }
    }
}
