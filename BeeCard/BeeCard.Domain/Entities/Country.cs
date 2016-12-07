using System.Collections.Generic;

namespace BeeCard.Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public Country()
        {
            Companies = new List<Company>();
        }
    }
}
