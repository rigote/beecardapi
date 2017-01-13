using System;
using System.Collections.Generic;

namespace BeeCard.Domain.Entities
{
    public class CorporateCard : BaseCardEntity
    {
        public string Occupation { get; set; }
        public string Department { get; set; }
        public Guid CompanyID { get; set; }
        public Guid UserID { get; set; }

        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Lead> Leads { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }

        public CorporateCard()
        {
            UserGroups = new List<UserGroup>();
            Leads = new List<Lead>();
        }
    }
}
