using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ApplicationSetup.GeneralSetup
{
    public class PaymentTerms
    {
        [Key]
        public int PaymentTermID { get; set; }
        public string PaymentTermCode { get; set; }
        public string PaymentTerm { get; set; }
        public string PaymentTermAlias { get; set; }
        public int? CreditDays { get; set; }
        public bool AdvanceOnly { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int? EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsActive { get; set; }

    }
}
