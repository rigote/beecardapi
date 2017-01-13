using System;
using System.Collections.Generic;

namespace BeeCard.Domain.Entities
{
    public class PersonalCard : BaseCardEntity
    {        
        public string Address { get; set; }
        public string Website { get; set; }        
        public string SocialNetwork { get; set; }
        public Guid UserID { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<Lead> Leads { get; set; }

        public PersonalCard()
        {
            UserGroups = new List<UserGroup>();
            Leads = new List<Lead>();
        }
    }
}
