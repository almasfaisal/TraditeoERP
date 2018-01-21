using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ApplicationSetup.GeneralSetup
{
    public class PaymentTerms : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicationSetup.GeneralSetup.PaymentTerms>().ToTable("PaymentTerms");
        }

        public PaymentTerms()
        : base("ConnectionString")
        { }
        public DbSet<Models.ApplicationSetup.GeneralSetup.PaymentTerms> PaymentTermList { get; set; }

    }
}