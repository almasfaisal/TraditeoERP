using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ApplicationSetup.Inventory
{
    public class SubCategories : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicationSetup.Inventory.SubCategories>().ToTable("SubCategories");
        }

        public SubCategories()
        : base("ConnectionString")
        { }
        public DbSet<Models.ApplicationSetup.Inventory.SubCategories> SubCategoryList { get; set; }

    }
}
