using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAL.PurchaseManagement
{
    public class Purchases : DbContext
    {
        private SqlParameter[] _parms;
        private DbDataReader _reader;
        private ViewModel.PurchaseManagement.Purchases _purchases;
        
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

        public ViewModel.PurchaseManagement.Purchases GetPurchaseInformation(int purchaseID)
        {
            _purchases = new ViewModel.PurchaseManagement.Purchases();
            _parms = new SqlParameter[2];

            _parms[0] = new SqlParameter("@PurchaseID", SqlDbType.Int);
            _parms[0].Value = purchaseID;
            _parms[1] = new SqlParameter("@LanguageID", SqlDbType.Int);
            _parms[1].Value = 1;
            
            using (DbCommand command = this.Database.Connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetPurchaseInformation";
                command.Parameters.AddRange(_parms);

                if (this.Database.Connection.State == ConnectionState.Closed)
                    this.Database.Connection.Open();

                _reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                _purchases = ((IObjectContextAdapter)this).ObjectContext.Translate<ViewModel.PurchaseManagement.Purchases>(_reader).ToList()[0];
                _reader.NextResult();
                _purchases.TransactionItem = ((IObjectContextAdapter)this).ObjectContext.Translate<ViewModel.Transactions.TransactionItems>(_reader).ToList();
                _purchases.TransactionItemJson= JsonConvert.SerializeObject(_purchases.TransactionItem);
                _reader.NextResult();
                _purchases.TransactionLedger = ((IObjectContextAdapter)this).ObjectContext.Translate<ViewModel.Transactions.TransactionLedgers>(_reader).ToList();
                _purchases.TransactionLedgerJson = JsonConvert.SerializeObject(_purchases.TransactionLedger);
            }
            return _purchases;
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
