using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.PurchaseManagement
{
    public class Purchases : DbContext
    {
        private SqlParameter[] _parms;
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.PurchaseManagement.Purchases>().ToTable("Purchases");
        }

        public Purchases()
        : base("ConnectionString")
        { }
        public DbSet<Models.PurchaseManagement.Purchases> PurchaseList { get; set; }

        public List<ViewModel.PurchaseManagement.Purchases> ShowPurchases()
        {
            _parms = new SqlParameter[3];

            _parms[0] = new SqlParameter("@CurrentPage", SqlDbType.Int);
            _parms[0].Value = 1;
            _parms[1] = new SqlParameter("@PageSize", SqlDbType.Int);
            _parms[1].Value = 0;
            _parms[2] = new SqlParameter("@HelpView", SqlDbType.Bit);
            _parms[2].Value = false;

            var result = this.Database.SqlQuery<ViewModel.PurchaseManagement.Purchases>("ShowPurchases", _parms).ToList();
            return result;
        }
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
