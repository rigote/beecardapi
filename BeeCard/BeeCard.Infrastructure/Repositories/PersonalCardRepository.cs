using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;
using System;

namespace BeeCard.Infrastructure.Repositories
{
    public class PersonalCardRepository : BaseEntityRepository<PersonalCard>, IPersonalCardRepository
    {
        private readonly Context _context;

        public PersonalCardRepository(Context context)
            : base(context)
        {
            _context = context;
        }

        public override void Add(PersonalCard entity)
        {
            foreach(var skill in entity.Skills)
                skill.CreateDate = skill.ModifyDate = DateTime.Now;

            foreach (var userGroup in entity.UserGroups)
                userGroup.CreateDate = userGroup.ModifyDate = DateTime.Now;

            foreach (var lead in entity.Leads)
                lead.CreateDate = lead.ModifyDate = DateTime.Now;

            base.Add(entity);
        }

        public override void Update(PersonalCard entity)
        {
            foreach (var skill in entity.Skills)
                skill.ModifyDate = DateTime.Now;

            foreach (var userGroup in entity.UserGroups)
                userGroup.ModifyDate = DateTime.Now;

            foreach (var lead in entity.Leads)
                lead.ModifyDate = DateTime.Now;

            base.Update(entity);
        }
    }
}
