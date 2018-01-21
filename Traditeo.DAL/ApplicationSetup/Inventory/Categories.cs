using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ApplicationSetup.Inventory
{
    public class Categories : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicationSetup.Inventory.Categories>().ToTable("Categories");
        }

        public Categories()
        : base("ConnectionString")
        { }
        public DbSet<Models.ApplicationSetup.Inventory.Categories> CategoryList { get; set; }

    }
}
