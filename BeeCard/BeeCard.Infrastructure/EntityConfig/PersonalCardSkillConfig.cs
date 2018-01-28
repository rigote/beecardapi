using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class PersonalCardSkillConfig : BaseEntityConfig<PersonalCardSkill>
    {
        public PersonalCardSkillConfig()
            : base("PersonalCardSkill")
        {
            Property(p => p.PersonalCardID).IsRequired();
            Property(p => p.SkillID).IsRequired();

            HasRequired(p => p.Skill)
                .WithMany()
                .HasForeignKey(k => k.SkillID);
            HasRequired(p => p.Card)
                .WithMany(p => p.Skills)
                .HasForeignKey(k => k.PersonalCardID);
        }
    }
}
