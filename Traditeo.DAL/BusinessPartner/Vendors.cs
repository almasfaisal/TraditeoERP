using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.BusinessPartner
{
    public class Vendors : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.BusinessPartner.Vendors>().ToTable("Vendors");
        }

        public Vendors() 
        : base("ConnectionString") 
            { }
        public DbSet<Models.BusinessPartner.Vendors> VendorList { get; set; }
 
    }
}
