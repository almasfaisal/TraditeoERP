using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ApplicationSetup.Inventory
{
    public class Manufacturers
    {
        [Key]
        public int ManufacturerID { get; set; }
        public string ManufacturerCode { get; set; }
        public string Manufacturer { get; set; }
        public string ManufacturerAlias { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int? EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsActive { get; set; }

    }
}
