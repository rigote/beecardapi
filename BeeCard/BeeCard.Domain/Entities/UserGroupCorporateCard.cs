using System;

namespace BeeCard.Domain.Entities
{
    public class UserGroupCorporateCard : BaseUserGroupCard
    {
        public Guid CorporateCardID { get; set; }
        public Guid UserGroupID { get; set; }

        public virtual UserGroup UserGroup { get; set; }
        public virtual CorporateCard CorporateCard { get; set; }        
    }
}
