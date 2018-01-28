using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Services;

namespace BeeCard.Application.Services
{
    public class SkillAppService : ISkillAppService
    {
        private ISkillService _service;

        public SkillAppService(ISkillService service)
        {
            _service = service;
        }

        public Skill Save(string skillName)
        {
            return _service.Save(skillName);
        }
    }
}
