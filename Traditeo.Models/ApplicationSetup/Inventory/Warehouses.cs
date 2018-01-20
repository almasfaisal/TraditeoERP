using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Traditeo.Models.ApplicationSetup.Inventory
{
    public class Warehouses
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseID { get; set; }
        public string WarehouseCode { get; set; }
        public string Warehouse { get; set; }
        public string WarehouseAlias { get; set; }
        public int BranchID { get; set; }
        public bool CanSales { get; set; }
        public bool CanPurchase { get; set; }
        public bool CanTransfer { get; set; }
        public string Remarks { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int? EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsActive { get; set; }

    }
}
