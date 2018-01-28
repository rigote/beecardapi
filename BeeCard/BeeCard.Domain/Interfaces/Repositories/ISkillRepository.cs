using BeeCard.Domain.Entities;

namespace BeeCard.Domain.Interfaces.Repositories
{
    public interface ISkillRepository : IBaseRepository<Skill>
    {
        Skill Save(string skillName);
    }
}
