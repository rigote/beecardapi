using BeeCard.Domain.Entities;
using BeeCard.Infrastructure.EntityConfig;
using System.Data.Entity;

namespace BeeCard.Infrastructure
{
    public class Context : DbContext
    {
        public Context()
            : base()
        {

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
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
