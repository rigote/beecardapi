using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using System;
using System.Data.Entity;

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

        public override void Remove(T entity)
        {
            entity.ModifyDate = DateTime.Now;
            entity.Status = EntityStatus.Deleted;

            _context.Entry<T>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
