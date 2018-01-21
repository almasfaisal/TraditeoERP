using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ApplicationSetup.Inventory
{
    public class SubClasses
    {
        [Key]
        public int SubClassID { get; set; }
        public string SubClassCode { get; set; }
        public string SubClass { get; set; }
        public string SubClassAlias { get; set; }
        public int? ClassID { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int? EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsActive { get; set; }

    }
}
