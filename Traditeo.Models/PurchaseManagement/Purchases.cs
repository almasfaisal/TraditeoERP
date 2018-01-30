using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.PurchaseManagement
{
    public class Purchases
    {
        [Key]
        public Int64 PurchaseID { get; set; }
        public string PurchaseNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        public string ReferenceNumber { get; set; }
        public int VendorID { get; set; }
        public int PaymentTermID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public int BranchID { get; set; }
        public int BusinessPeriodID { get; set; }
        public Int64 PurchaseSuggestionID { get; set; }
        public Int64 PurchaseRequestID { get; set; }
        public Int64 PurchaseOrderID { get; set; }
        public int PurchaseAuthorityID { get; set; }
        public int CurrencyID { get; set; }
        public decimal ExchangeRate { get; set; }
        public int ProjectID { get; set; }
        public int DivisionID { get; set; }
        public bool IsPosted { get; set; }
        public DateTime PostingDate { get; set; }
        public int VoucherID { get; set; }
        public int PostingUserID { get; set; }
        public decimal LineTotal { get; set; }
        public decimal LCYLineTotal { get; set; }
        public decimal LineItemDiscount { get; set; }
        public decimal LCYLineItemDiscount { get; set; }
        public decimal LineMargin { get; set; }
        public decimal LCYLineMargin { get; set; }
        public decimal LineDiscount { get; set; }
        public decimal LCYLineDiscount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal LCYNetAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal LCYDiscountAmount { get; set; }
        public decimal AditionalCharge { get; set; }
        public decimal LCYAditionalCharge { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal LCYGrandTotal { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime CancelDate { get; set; }
        public int CancelUserID { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public DateTime ApprovalDate { get; set; }
        public int ApprovalUserID { get; set; }
        public String FilePath { get; set; }
        public String Remarks { get; set; }
        public bool IsDisputePayment { get; set; }
        public DateTime DisputeDate { get; set; }
        public int DisputeUserID { get; set; }
        public DateTime DisputeClearDate { get; set; }
        public int DisputeClearUserID { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int EditUserID { get; set; }
        public DateTime EditDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class PurchaseItems
    {
        [Key]
        public Int64 PurchaseItemID { get; set; }
        public Int64 PurchaseID { get; set; }
        public Int64 ItemID { get; set; }
        public int LineID { get; set; }
        public int UnitID { get; set; }
        public decimal Factor { get; set; }
        public int CurrencyID { get; set; }
        public decimal ExchangeRate { get; set; }
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
        public decimal TotalDiscount { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal LandedCost { get; set; }
        public decimal AverageCost { get; set; }
        public decimal CostCorrection { get; set; }
        public decimal ItemOverhead { get; set; }
        public decimal InventoryOverhead { get; set; }
        public decimal ExpenseOverhead { get; set; }
        public string Naration { get; set; }
    }
}
