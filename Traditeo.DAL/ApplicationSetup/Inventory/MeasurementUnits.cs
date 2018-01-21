using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.ApplicationSetup.Inventory
{
    public class MeasurementUnits : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicationSetup.Inventory.MeasurementUnits>().ToTable("Warehouses");
        }

        public MeasurementUnits()
        : base("ConnectionString")
        { }
        public DbSet<Models.ApplicationSetup.Inventory.MeasurementUnits> UnitList { get; set; }

    }
}