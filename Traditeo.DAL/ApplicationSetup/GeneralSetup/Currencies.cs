using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ApplicationSetup.GeneralSetup
{
    public class Currencies : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicationSetup.GeneralSetup.Currencies>().ToTable("Currencies");
        }

        public Currencies()
        : base("ConnectionString")
        { }
        public DbSet<Models.ApplicationSetup.GeneralSetup.Currencies> CurrencyList { get; set; }

    }
}