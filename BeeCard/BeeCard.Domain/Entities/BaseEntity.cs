using System;
using BeeCard.Domain.Entities.Enum;

namespace BeeCard.Domain.Entities
{
    public class BaseEntity
    {
        public Guid ID { get; set; }
        public EntityStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }

        public BaseEntity()
        {
            ID = Guid.NewGuid();
        }
    }
}
