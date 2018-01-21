using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ApplicationSetup.Inventory
{
    public class Manufacturers : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicationSetup.Inventory.Manufacturers>().ToTable("Manufacturers");
        }

        public Manufacturers()
        : base("ConnectionString")
        { }
        public DbSet<Models.ApplicationSetup.Inventory.Manufacturers> ManufacturerList { get; set; }

    }
}
