using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ApplicationSetup.GeneralSetup
{
    public class Currencies
    {
        [Key]
        public int CurrencyID { get; set; }
        public string CurrencyCode { get; set; }
        public string Currency { get; set; }
        public bool IsBaseCurrency { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int? EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsActive { get; set; }

    }
}
