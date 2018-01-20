using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.BusinessPartner
{
    public class Vendors
    {
        [Key]
        public int VendorID { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string VendorAlias { get; set; }
        public int VendorCategoryID { get; set; }
        public int PaymentTermID { get; set; }
        public string IdentityNumber { get; set; }
        public string TaxNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailID { get; set; }
        public int? AccountID { get; set; }
        public int? AdvanceAccountID { get; set; }
        public int CurrencyID { get; set; }
        public bool HoldPayment { get; set; }
        public bool HoldPurchaseOrder { get; set; }
        public bool HoldPurchaseReturn { get; set; }
        public byte? CreditRating { get; set; }
        public byte? QualityRating { get; set; }
        public byte? DeliveryRating { get; set; }
        public byte? PriceRating { get; set; }
        public DateTime? LastPurchaseDate { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public decimal? LastPaymentAmount { get; set; }
        public string VendorNotes { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int? EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsActive { get; set; }

    }
}
