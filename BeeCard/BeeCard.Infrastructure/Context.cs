using System.Data.Entity;

namespace BeeCard.Infrastructure
{
    public class Context : DbContext
    {
        public Context()
            : base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
