using System.Data.Entity;
using System.Linq;

namespace Traditeo.DAL.Utility
{
    public class Menus : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Utility.Menus>().ToTable("Menus");
        }

        public Menus() 
        : base("ConnectionString") 
            { }
        public DbSet<Models.Utility.Menus> MenuList { get; set; }

    }
}
