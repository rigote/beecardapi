using BeeCard.Domain.Entities.Enum;
using System;

namespace BeeCard.Domain.Entities
{
    public class Lead : BaseEntity
    {
        public Guid? PersonalCardID { get; set; }
        public Guid? CorporateCardID { get; set; }
        public RequestStatus RequestStatus { get; set; }

        public virtual PersonalCard PersonalCard { get; set; }
        public virtual CorporateCard CorporateCard { get; set; }
    }
}
