﻿using BeeCard.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BeeCard.Infrastructure.EntityConfig
{
    class UserGroupConfig : EntityTypeConfiguration<UserGroup>
    {
        public UserGroupConfig()
        {

        }
    }
}
