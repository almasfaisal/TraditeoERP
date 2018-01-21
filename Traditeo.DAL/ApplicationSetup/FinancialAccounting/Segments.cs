using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ApplicationSetup.FinancialAccounting
{
    public class Segments : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicationSetup.FinancialAccounting.Segments>().ToTable("Segments");
        }

        public Segments()
        : base("ConnectionString")
        { }
        public DbSet<Models.ApplicationSetup.FinancialAccounting.Segments> SegmentList { get; set; }
    }
}
