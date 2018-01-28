using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;

namespace BeeCard.Infrastructure.Repositories
{
    public class SkillRepository : BaseEntityRepository<Skill>, ISkillRepository
    {
        private readonly Context _context;

        public SkillRepository(Context context)
            : base(context)
        {
            _context = context;
        }

        public Skill Save(string skillName)
        {
            var entity = Get(s => s.Name == skillName);

            if (entity == null)
            {
                entity = new Skill
                {
                    Name = skillName
                };

                Add(entity);
            }

            return entity;
        }
    }
}
