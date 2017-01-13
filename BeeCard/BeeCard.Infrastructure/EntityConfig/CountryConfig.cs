using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class CountryConfig : BaseEntityConfig<Country>
    {
        public CountryConfig()
            : base("Country")
        {
            Property(p => p.Name).HasMaxLength(200);
        }
    }
}
