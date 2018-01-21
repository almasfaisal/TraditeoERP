using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ApplicationSetup.Inventory
{
    public class ItemSubGroups
    {
        [Key]
        public int ItemSubGroupID { get; set; }
        public string ItemSubGroupCode { get; set; }
        public string ItemSubGroup { get; set; }
        public string ItemSubGroupAlias { get; set; }
        public int? ItemGroupID { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int? EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsActive { get; set; }

    }
}
