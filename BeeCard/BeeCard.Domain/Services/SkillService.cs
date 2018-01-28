using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Interfaces.Services;

namespace BeeCard.Domain.Services
{
    public class SkillService : BaseService<Skill>, ISkillService
    {
        private readonly ISkillRepository _repository;

        public SkillService(ISkillRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Skill Save(string skillName)
        {
            return _repository.Save(skillName);
        }
    }
}
