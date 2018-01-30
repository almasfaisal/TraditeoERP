using System;
using System.ComponentModel.DataAnnotations;

namespace Traditeo.ViewModel.Transactions
{
    public class TransactionLedgers
    {
        public Int64 id { get; set; }
        [Key]
        public Int64 TransactionLedgerID { get; set; }
        public int InventoryTypeID { get; set; }
        public Int64 ReferenceID { get; set; }
        public Int64 DocumentID { get; set; }
        public int BranchID { get; set; }
        public int WarehouseID { get; set; }
        public Int64 ItemID { get; set; }
        public int? LineID { get; set; }
        public Int64 ItemBatchID { get; set; }
        public string BatchNumber { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ? ManufactureDate{ get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string DisplayExpiryDate { get { return ExpiryDate.Value.ToString("dd MMM yyyy"); } }
        public int? ItemSerialID { get; set; }
        public int? DimensionItemID { get; set; }
        public decimal Quantity { get; set; }
        public decimal BonusQuantity { get; set; }
        public decimal SampleQuantity { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public DateTime? TransactionDate { get; set; }

    }
}

