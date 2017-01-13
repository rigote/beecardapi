using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class BaseCardEntityConfig<TEntity> : BaseEntityConfig<TEntity> where TEntity : BaseCardEntity
    {
        public BaseCardEntityConfig(string tableName = null)
            : base(tableName)
        {
            Property(p => p.Name).HasMaxLength(200);
            Property(p => p.Email).HasMaxLength(100);
            Property(p => p.Phone).HasMaxLength(100);
            Property(p => p.Cellphone).HasMaxLength(100);            
        }
    }
}
