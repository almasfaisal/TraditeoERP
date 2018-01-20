using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ApplicationSetup.Inventory
{
    public class Warehouses : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicationSetup.Inventory.Warehouses>().ToTable("Warehouses");
        }

        public Warehouses()
        : base("ConnectionString")
        { }
        public DbSet<Models.ApplicationSetup.Inventory.Warehouses> WarehouseList { get; set; }

    }
}
