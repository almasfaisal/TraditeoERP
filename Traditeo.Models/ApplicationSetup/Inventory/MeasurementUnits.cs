using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ApplicationSetup.Inventory
{
    public class MeasurementUnits
    {
        [Key]
        public int MeasurementUnitID { get; set; }
        public string MeasurementUnitCode { get; set; }
        public string MeasurementUnit { get; set; }
        public string MeasurementUnitAlias { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int? EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsActive { get; set; }

    }
}
