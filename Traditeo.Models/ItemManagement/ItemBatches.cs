using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ItemManagement
{
    public class ItemBatches
    {
        [Key]
        public Int64 ItemBatchID { get; set; }
        [NotMapped]
        public Int64 id { get; set; }
        public Int64 ItemID { get; set; }
        public string BatchNumber { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string DisplayExpiryDate { get {return ExpiryDate.Value.ToString (ApplicationUtility.Utility.DateFormat); } }
        public decimal? SalePrice { get; set; }
        public decimal? RetailPrice { get; set; }
        public decimal? PurchasePrice { get; set; }

    }
}
