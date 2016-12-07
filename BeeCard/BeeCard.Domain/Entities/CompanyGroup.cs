using System;

namespace BeeCard.Domain.Entities
{
    public class CompanyGroup : BaseEntity
    {
        public string Name { get; set; }
        public Guid CompanyID { get; set; }

        public virtual Company Company { get; set; }
    }
}
