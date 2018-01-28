using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class SkillConfig : BaseEntityConfig<Skill>
    {
        public SkillConfig()
            : base("Skill")
        {
            Property(p => p.Name).HasMaxLength(255).IsRequired();
        }
    }
}
