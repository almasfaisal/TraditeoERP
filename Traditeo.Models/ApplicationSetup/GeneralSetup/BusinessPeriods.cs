using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ApplicationSetup.GeneralSetup
{
    public class BusinessPeriods
    {
        [Key]
        public int BusinessPeriodID { get; set; }
        public string BusinessPeriodCode { get; set; }
        public string BusinessPeriod { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsLock { get; set; }
        public bool IsClosed { get; set; }

    }
}
