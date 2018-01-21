using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ApplicationSetup.Inventory
{
    public class ItemGroups : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicationSetup.Inventory.ItemGroups>().ToTable("ItemGroups");
        }

        public ItemGroups()
        : base("ConnectionString")
        { }
        public DbSet<Models.ApplicationSetup.Inventory.ItemGroups> ItemGroupList { get; set; }

    }
}
