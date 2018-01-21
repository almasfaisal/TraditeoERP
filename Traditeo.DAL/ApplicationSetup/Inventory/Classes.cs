using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ApplicationSetup.Inventory
{
    public class Classes : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicationSetup.Inventory.Classes>().ToTable("Classes");
        }

        public Classes()
        : base("ConnectionString")
        { }
        public DbSet<Models.ApplicationSetup.Inventory.Classes> ClassList { get; set; }

    }
}

//namespace Traditeo.Models.ApplicationSetup.Inventory
//{
//    class Classes
//    {
//    }
//}
