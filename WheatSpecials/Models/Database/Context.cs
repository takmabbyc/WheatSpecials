using System.Data.Entity;

namespace WheatSpecials.Models.Database
{
    public class Context : DbContext
    {
        public Context() : base("DbData") { }

        public virtual DbSet<WheatBeer> WheatBeers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WheatBeer>();
        }
    }
}
