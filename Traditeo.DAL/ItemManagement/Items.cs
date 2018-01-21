using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ItemManagement
{
    public class Items : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ItemManagement.Items>().ToTable("Items");
        }

        public Items()
        : base("ConnectionString")
        { }
        public DbSet<Models.ItemManagement.Items> ItemList { get; set; }
    }
}
