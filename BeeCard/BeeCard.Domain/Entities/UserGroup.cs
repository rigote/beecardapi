using System;
using System.Collections.Generic;

namespace BeeCard.Domain.Entities
{
    public class UserGroup : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserID { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<UserGroupPersonalCard> UserGroupPersonalCards { get; set; }
        public virtual ICollection<UserGroupCorporateCard> UserGroupCorporateCards { get; set; }

        public UserGroup()
        {
            UserGroupPersonalCards = new List<UserGroupPersonalCard>();
            UserGroupCorporateCards = new List<UserGroupCorporateCard>();
        }
    }
}
