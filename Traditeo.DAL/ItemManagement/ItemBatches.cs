using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ItemManagement
{
    public class ItemBatches : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ItemManagement.ItemBatches>().ToTable("ItemBatches");
        }

        public ItemBatches()
        : base("ConnectionString")
        { }
        public DbSet<Models.ItemManagement.ItemBatches> ItemBatchList { get; set; }
    }
}
