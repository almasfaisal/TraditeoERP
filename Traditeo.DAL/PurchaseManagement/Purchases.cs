using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.PurchaseManagement
{
    public class Purchases : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Models.PurchaseManagement.Purchases>().ToTable("Purchases");

            modelBuilder.Entity<Models.PurchaseManagement.Purchases>().HasKey(t => t.BranchID);
            

            modelBuilder.Entity<Models.PurchaseManagement.Purchases>().ToTable("Purchases").HasRequired(x => x.Branch).WithRequiredDependent(y => y.Purchase);
       

        }

        public Purchases() 
        : base("ConnectionString") 
            { }
        public DbSet<Models.PurchaseManagement.Purchases> PurchaseList { get; set; }
    }

    public class PurchaseItems : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.PurchaseManagement.PurchaseItems>().ToTable("PurchaseItems");
        }

        public PurchaseItems() 
        : base("ConnectionString") 
            { }
        public DbSet<Models.PurchaseManagement.PurchaseItems> PurchaseItemList { get; set; }
    }

}
