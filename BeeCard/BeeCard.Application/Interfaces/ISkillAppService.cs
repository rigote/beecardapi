using BeeCard.Domain.Entities;

namespace BeeCard.Application.Interfaces
{
    public interface ISkillAppService
    {
        Skill Save(string skillName);
    }
}
