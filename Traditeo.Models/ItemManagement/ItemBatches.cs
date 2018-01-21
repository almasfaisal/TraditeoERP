using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ItemManagement
{
    public class ItemBatches
    {
        [Key]
        public Int64 ItemBatchID { get; set; }
        public Int64 ItemID { get; set; }
        public string BatchNumber { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? RetailPrice { get; set; }
        public decimal? PurchasePrice { get; set; }

    }
}
