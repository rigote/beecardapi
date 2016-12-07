using BeeCard.Domain.Entities.Enum;
using System;

namespace BeeCard.Domain.Entities
{
    public class SubscriptionHistory : BaseEntity
    {
        public SubscriptionType SubscriptionType { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }
        public Guid CompanyID { get; set; }

        public virtual Company Company { get; set; }
    }
}
