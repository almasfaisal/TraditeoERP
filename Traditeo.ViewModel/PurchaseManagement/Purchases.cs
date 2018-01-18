using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.ViewModel.PurchaseManagement
{
    public class Purchases
    {
        public int id { get; set; }
        [Key]
        public int UniqueID { get; set; }
        public string PurchaseNumber { get; set; }
        public string DueDate { get; set; }
        public string PurchaseDate { get; set; }
        public int BranchID { get; set; }
        public string BranchCode { get; set; }
        public string Branch { get; set; }
        public int VendorID { get; set; }
        public string VendorCode { get; set; }
        public string Vendor { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public string VoucherNumber { get; set; }
        public int BusinessPeriodID { get; set; }
        public int PurchaseAuthorityID { get; set; }
        public string PurchaseAuthority { get; set; }
        public decimal LineTotal { get; set; }
        public decimal LineMargin { get; set; }
        public decimal LineDiscount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal AditionalCharge { get; set; }
        public decimal GrandTotal { get; set; }
        public bool IsPosted { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public bool IsDisputePayment { get; set; }
        public string AddUser { get; set; }
        public string AddDate { get; set; }
        public string EditUser { get; set; }
        public string EditDate { get; set; }

    }
}
