﻿using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.EntityConfig
{
    class UserGroupConfig : BaseEntityConfig<UserGroup>
    {
        public UserGroupConfig()
            : base("UserGroup")
        {
            Property(p => p.UserID).IsRequired();
            Property(p => p.Name).HasMaxLength(100).IsRequired();

            HasMany(p => p.PersonalCards)
                .WithMany(u => u.UserGroups)
                .Map(m =>
                {
                    m.MapLeftKey("PersonalCardID");
                    m.MapLeftKey("UserGroupID");
                    m.ToTable("UserGroup_PersonalCard");
                });

            HasMany(c => c.CorporateCards)
                .WithMany(u => u.UserGroups)
                .Map(m =>
                {
                    m.MapLeftKey("CorporateCardID");
                    m.MapLeftKey("UserGroupID");
                    m.ToTable("UserGroup_CorporateCard");
                });
        }
    }
}