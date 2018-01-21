using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ApplicationSetup.FinancialAccounting
{
    public class Segmentations : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicationSetup.FinancialAccounting.Segmentations>().ToTable("Segmentations");
        }

        public Segmentations()
        : base("ConnectionString")
        { }
        public DbSet<Models.ApplicationSetup.FinancialAccounting.Segmentations> SegmentationList { get; set; }
    }
}
