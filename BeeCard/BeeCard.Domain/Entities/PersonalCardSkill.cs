using System;

namespace BeeCard.Domain.Entities
{
    public class PersonalCardSkill : BaseEntity
    {
        public Guid PersonalCardID { get; set; }
        public Guid SkillID { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual PersonalCard Card { get; set; }
    }
}
