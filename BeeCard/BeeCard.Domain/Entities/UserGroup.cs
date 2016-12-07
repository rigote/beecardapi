using System;

namespace BeeCard.Domain.Entities
{
    public class UserGroup : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserID { get; set; }

        public virtual User User { get; set; }
    }
}
