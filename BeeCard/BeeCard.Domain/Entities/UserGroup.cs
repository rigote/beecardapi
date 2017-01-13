using System;
using System.Collections.Generic;

namespace BeeCard.Domain.Entities
{
    public class UserGroup : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserID { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PersonalCard> PersonalCards { get; set; }
        public virtual ICollection<CorporateCard> CorporateCards { get; set; }

        public UserGroup()
        {
            PersonalCards = new List<PersonalCard>();
            CorporateCards = new List<CorporateCard>();
        }
    }
}
