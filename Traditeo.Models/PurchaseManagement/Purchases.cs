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
       
        [Key, Column(Order = 0)]
        public Int64 PurchaseID { get; set; }
        public string PurchaseNumber { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime DueDate { get; set; }
        public Int64 VendorID { get; set; }

        ////[Key, ForeignKey("Branches"), Column(Order = 0)]
        //[Key, Column(Order = 1)]
        //[ForeignKey("FK_Purchases2")]
        //public int BranchID { get; set; }
        public int? ProjectID { get; set; }
        public int? DivisionID { get; set; }
        public int CurrencyID { get; set; }
        public decimal ExchangeRate { get; set; }
        public int? PurchaseAuthorityID { get; set; }
        public int? PaymentTermID { get; set; }
        public int? PurchaseOrderID { get; set; }
        public decimal TotalAmount { get; set; }
        [NotMapped]
        public decimal TaxAmount { get; set; }
        [NotMapped]
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        [NotMapped]
        public decimal LineAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public string Remarks { get; set; }
        public string FilePath { get; set; }
        public bool IsPosted { get; set; }
        public int? PostingUserID { get; set; }
        [NotMapped]
        public int VouchserID { get; set; }
        [NotMapped]
        public string VouchserNumber { get; set; }
        [NotMapped]
        public string VouchserDate { get; set; }
        public int? FirstIndicatorID { get; set; }
        public int? FirstIndicatorValueID { get; set; }
        public int? SecondIndicatorID { get; set; }
        public int? SecondIndicatorValueID { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime? CancelDate { get; set; }
        public int? CancelUserID { get; set; }
        public bool IsDisputePayment { get; set; }
        public DateTime? DisputeClearDate { get; set; }
        public int? DisputeClearUserID { get; set; }
        
        public int BranchID { get; set; }
        //[ForeignKey("BranchID")]
        [Required]
        public virtual Branches Branch { get; set; }
        
    }

    public class PurchaseItems
    {
        [Key]
        public int PurchaseItemID { get; set; }
        public int PurchaseID { get; set; }
        public int ItemID { get; set; }
    }

    public class Branches
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchID { get; set; }
        public string BranchCode { get; set; }
        public string Branch { get; set; }
        public string BranchAlias { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public int PriceListID { get; set; }
        public int SalesManID { get; set; }
        public int SupervisorID { get; set; }
        public int SigmentionID { get; set; }
        public int CostCenterID { get; set; }
        public Int64 CustomerID { get; set; }
        public bool IsMainBranch { get; set; }
        public bool IsRetailBranch { get; set; }
        public virtual Purchases Purchase { get; set; }

    }
}
