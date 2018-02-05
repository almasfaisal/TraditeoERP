using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ApplicationSetup.GeneralSetup
{
    public class AdditionalCharges : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicationSetup.GeneralSetup.AdditionalCharges>().ToTable("AdditionalCharges");
        }

        public AdditionalCharges()
        : base("ConnectionString")
        { }
        public DbSet<Models.ApplicationSetup.GeneralSetup.AdditionalCharges> AdditionalChargeList { get; set; }

    }
}
