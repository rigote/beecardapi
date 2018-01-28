using System;
using System.Collections.Generic;

namespace BeeCard.Domain.Entities
{
    public class PersonalCard : BaseCardEntity
    {        
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string Occupation { get; set; }
        public string Photo { get; set; }
        public string Website { get; set; }        
        public string SocialNetwork { get; set; }
        public string Bio { get; set; }
        public Guid UserID { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<Lead> Leads { get; set; }
        public virtual ICollection<PersonalCardSkill> Skills { get; set; }


        public PersonalCard()
        {
            ID = Guid.NewGuid();
            UserGroups = new List<UserGroup>();
            Leads = new List<Lead>();
            Skills = new List<PersonalCardSkill>();
        }
    }
}
