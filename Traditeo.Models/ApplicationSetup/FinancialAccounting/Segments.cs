using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ApplicationSetup.FinancialAccounting
{
    public class Segments
    {
        public int SegmentID { get; set; }
        public string SegmentCode { get; set; }
        public string Segment { get; set; }
        public string SegmentAlias { get; set; }
        public int IsBranch { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int? EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsActive { get; set; }

    }
}
