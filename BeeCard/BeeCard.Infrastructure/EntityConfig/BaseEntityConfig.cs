using BeeCard.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BeeCard.Infrastructure.EntityConfig
{
    class BaseEntityConfig<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public BaseEntityConfig(string tableName = null)
        {
            if (!string.IsNullOrEmpty(tableName))
                ToTable(tableName);

            HasKey(k => k.ID);
            Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Status).IsRequired();
            Property(p => p.CreateDate).IsRequired();
            Property(p => p.ModifyDate).IsOptional();
        }
    }
}
