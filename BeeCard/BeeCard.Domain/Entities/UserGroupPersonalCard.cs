using System;

namespace BeeCard.Domain.Entities
{
    public class UserGroupPersonalCard : BaseUserGroupCard
    {
        public Guid PersonalCardID { get; set; }
        public Guid UserGroupID { get; set; }

        public virtual UserGroup UserGroup { get; set; }
        public virtual PersonalCard PersonalCard { get; set; }
    }
}
