using BeeCard.Domain.Entities.Enum;
using System;
using System.Collections.Generic;

namespace BeeCard.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Password { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }
        public string Logo { get; set; }
        public string Website { get; set; }
        public string SocialNetwork { get; set; }
        public Guid PlanID { get; set; }
        public Guid CountryID { get; set; }
        public Guid CompanyTypeID { get; set; }

        public virtual ICollection<SubscriptionHistory> SubscriptionsHistory { get; set; }
        public virtual ICollection<CorporateCard> CorporateCards { get; set; }
        public virtual ICollection<CompanyGroup> CompanyGroups { get; set; }

        public Company()
        {
            SubscriptionsHistory = new List<SubscriptionHistory>();
            CorporateCards = new List<CorporateCard>();
        }
    }
}
