using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.ViewModel.Transactions
{
    public class TransactionCharges
    {
        public Int64 id { get; set; }
        [Key]
        public int AdditionalChargeID { get; set; }
        public string AdditionalChargeCode { get; set; }
        public string AdditionalCharge { get; set; }
        public bool IsIncludeInventory { get; set; }
        public bool IsVendorPayable { get; set; }
        public Int64? PurchaseID { get; set; }
        public int? CurrencyID { get; set; }
        public string Currency { get; set; }
        public decimal? ExchangeRate { get; set; }
        public decimal? ChargePercentage { get; set; }
        public decimal? ChargeAmount { get; set; }
        public int? VendorID { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string VendorDescription { get { return string.Concat(string.Concat(VendorCode, "-"), VendorName); } }
    }
}
