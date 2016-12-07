using System.Collections.Generic;

namespace BeeCard.Domain.Entities
{
    public class Plan : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public Plan()
        {
            Companies = new List<Company>();
        }
    }
}
