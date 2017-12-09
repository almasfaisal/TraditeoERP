using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ApplicationSetup.GeneralSetup
{
    public class Branches : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Models.ApplicationSetup.GeneralSetup.Branches>().ToTable("Branches");
            modelBuilder.Entity<Models.PurchaseManagement.Branches>().ToTable("Branches");
            
        }

        public Branches() 
        : base("ConnectionString") 
            { }
        //public DbSet<Models.ApplicationSetup.GeneralSetup.Branches> BranchList { get; set; }

        public DbSet<Models.PurchaseManagement.Branches> BranchList { get; set; }

    }
}
