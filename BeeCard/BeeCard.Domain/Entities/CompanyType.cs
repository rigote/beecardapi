using System.Collections.Generic;

namespace BeeCard.Domain.Entities
{
    public class CompanyType : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public CompanyType()
        {
            Companies = new List<Company>();
        }
    }
}
