using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class PlanConfig : BaseEntityConfig<Plan>
    {
        public PlanConfig()
            : base("Plan")
        {
            Property(p => p.Name).HasMaxLength(100).IsRequired();
            Property(p => p.Description).HasMaxLength(500);
        }
    }
}
