using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ApplicationSetup.FinancialAccounting
{
    public class Segmentations
    {
        [Key]
        public int SegmentationID { get; set; }
        public string SegmentationCode { get; set; }
        public string Segmentation { get; set; }
        public string SegmentationAlias { get; set; }
        public int SegmentID { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int? EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsActive { get; set; }

    }
}
