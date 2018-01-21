using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ApplicationSetup.Inventory
{
    public class InventoryTypes
    {
        [Key]
        public int InventoryTypeID { get; set; }
        public string InventoryType { get; set; }
        public bool IsActive { get; set; }
    }
}
