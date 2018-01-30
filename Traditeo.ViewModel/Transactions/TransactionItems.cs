using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.ViewModel.Transactions
{
    public class TransactionItems
    {
        public int id { get; set; }
        [Key]
        public Int64 TransactionItemID { get; set; }
        public Int64 PurchaseItemID { get; set; }
        public Int64 PurchaseReturnItemID { get; set; }
        public Int64 PurchaseID { get; set; }
        public Int64 PurchaseReturnID { get; set; }
        public int WarehouseID { get; set; }
        public string WarehouseCode { get; set; }
        public string Warehouse { get; set; }
        public Int64 ItemID { get; set; }
        public int? LineID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int TrackingTypeID { get; set; }
        public int UnitID { get; set; }
        public string MeasurementUnit { get; set; }
        public decimal Factor { get; set; }
        public decimal Quantity { get; set; }
        public decimal BonusQuantity { get; set; }
        public decimal SampleQuantity { get; set; }
        public decimal ItemCost { get; set; }
        public decimal ItemDiscountPercentage { get; set; }
        public decimal ItemDiscountAmount { get; set; }
        public decimal MarginPercentage { get; set; }
        public decimal MarginAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal NetTotal { get; set; }
        public string Naration { get; set; }
        public List<TransactionLedgers> TransactionLedger { get; set; }
    }
}
