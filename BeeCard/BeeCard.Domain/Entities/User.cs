using BeeCard.Domain.Entities.Enum;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace BeeCard.Domain.Entities
{
    public class User : IdentityUser<Guid, UserLogin, UserRole, UserClaim>, IUser<Guid>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Photo { get; set; }
        public EntityStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }

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
