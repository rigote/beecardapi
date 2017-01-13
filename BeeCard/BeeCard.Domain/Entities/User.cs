using System;
using System.Collections.Generic;

namespace BeeCard.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cellphone { get; set; }
        public DateTime Birthdate { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<PersonalCard> PersonalCards { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<CorporateCard> CorporateCards { get; set; }

        public User()
        {
            PersonalCards = new List<PersonalCard>();
            UserGroups = new List<UserGroup>();
            CorporateCards = new List<CorporateCard>();
        }
    }
}
