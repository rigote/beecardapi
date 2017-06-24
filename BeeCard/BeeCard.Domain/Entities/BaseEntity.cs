using BeeCard.Domain.Entities.Enum;
using System;

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
            CreateDate = DateTime.Now;
            ModifyDate = DateTime.Now;
            Status = EntityStatus.Pending;
        }
    }
}
