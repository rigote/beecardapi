using System;

namespace BeeCard.Domain.Entities
{
    public class Lead : BaseEntity
    {
        public Guid? PersonalCardID { get; set; }
        public Guid? CorporateCardID { get; set; }
        public int RequestStatus { get; set; }

        public virtual PersonalCard PersonalCard { get; set; }
        public virtual CorporateCard CorporateCard { get; set; }
    }
}
