using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ApplicationSetup.GeneralSetup
{
    public class AdditionalCharges
    {
        [Key]
        public int AdditionalChargeID { get; set; }
        public string AdditionalChargeCode { get; set; }
        public string AdditionalCharge { get; set; }
        public string AdditionalChargeAlias { get; set; }
        public bool IsIncludeInventory { get; set; }
        public bool IsPayablebyVendor { get; set; }
        public bool ChargeTypeID { get; set; }
        public int? DebitAccountID { get; set; }
        public int? CreditAccountID { get; set; }
        public string Remarks { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int? EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsActive { get; set; }
    }
}
