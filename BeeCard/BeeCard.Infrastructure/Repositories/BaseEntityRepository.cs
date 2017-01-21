using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using System;

namespace BeeCard.Infrastructure.Repositories
{
    public class BaseEntityRepository<T> : BaseRepository<T> where T : BaseEntity
    {
        private readonly Context _context;

        public BaseEntityRepository(Context context)
            : base(context)
        {
            _context = context;
        }

        public override void Add(T entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = EntityStatus.Active;

            base.Add(entity);
        }

        public override void Update(T entity)
        {
            entity.ModifyDate = DateTime.Now;

            base.Update(entity);
        }
    }
}
