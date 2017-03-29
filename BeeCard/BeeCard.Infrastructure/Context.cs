using BeeCard.Domain.Entities;
using BeeCard.Infrastructure.EntityConfig;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace BeeCard.Infrastructure
{
    public class Context : IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim>    
    {
        public Context()
            : base("BeeCard")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<Context>(null);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyGroup> CompanyGroups { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<CorporateCard> CorporateCards { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<PersonalCard> PersonalCards { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<SubscriptionHistory> SubscritpionHistory { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Configurations.Add(new CompanyConfig());
            modelBuilder.Configurations.Add(new CompanyGroupConfig());
            modelBuilder.Configurations.Add(new CompanyTypeConfig());
            modelBuilder.Configurations.Add(new CorporateCardConfig());
            modelBuilder.Configurations.Add(new CountryConfig());
            modelBuilder.Configurations.Add(new LeadConfig());
            modelBuilder.Configurations.Add(new PersonalCardConfig());
            modelBuilder.Configurations.Add(new PlanConfig());
            modelBuilder.Configurations.Add(new SubscriptionHistoryConfig());
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new UserGroupConfig());
            modelBuilder.Configurations.Add(new UserGroupPersonalCardConfig());
            modelBuilder.Configurations.Add(new UserGroupCorporateCardConfig());
            modelBuilder.Configurations.Add(new RoleConfig());
            modelBuilder.Configurations.Add(new UserRoleConfig());
            modelBuilder.Configurations.Add(new UserClaimConfig());
            modelBuilder.Configurations.Add(new UserLoginConfig());
        }
    }
}
