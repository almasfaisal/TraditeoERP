using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Traditeo.Models.ApplicationSetup.GeneralSetup
{
    public class Branches
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchID { get; set; }
        public string BranchCode { get; set; }
        public string Branch { get; set; }
        public string BranchAlias { get; set; }
        public string Remarks { get; set; }
        public int? PriceListID { get; set; }
        public int? SegmentationID { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate{ get; set; }
        public int? EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsActive { get; set; }
    }
}
