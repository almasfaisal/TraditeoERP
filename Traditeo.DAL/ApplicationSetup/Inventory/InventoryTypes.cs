using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ApplicationSetup.Inventory
{
    public class InventoryTypes : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicationSetup.Inventory.InventoryTypes>().ToTable("InventoryTypes");
        }

        public InventoryTypes()
        : base("ConnectionString")
        { }
        public DbSet<Models.ApplicationSetup.Inventory.InventoryTypes> InventoryTypeList { get; set; }

    }
}

//namespace Traditeo.Models.ApplicationSetup.Inventory
//{
//    class InventoryTypes
//    {
//    }
//}
