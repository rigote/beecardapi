using BeeCard.Domain.Entities;

namespace BeeCard.Domain.Interfaces.Services
{
    public interface ISkillService : IBaseService<Skill>
    {
        Skill Save(string skillName);
    }
}
