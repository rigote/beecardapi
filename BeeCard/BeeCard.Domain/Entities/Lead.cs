using System;

namespace BeeCard.Domain.Entities
{
    public class Lead : BaseEntity
    {
        public Guid? PersonalCardID { get; set; }
        public Guid? CorporateCardID { get; set; }
        public int RequestStatus { get; set; }
    }
}
