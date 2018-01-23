using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ItemManagement
{
    public class Items
    {
        [Key]
        public Int64 ItemID { get; set; }
        [NotMapped]
        public Int64 id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemAlias { get; set; }
        public string ItemShortName { get; set; }
        public string InternationalCode { get; set; }
        public string BarCode { get; set; }
        public string StoreTemperature { get; set; }
        public int? CategoryID { get; set; }
        public int? SubCategoryID { get; set; }
        public int? ItemGroupID { get; set; }
        public int? ItemSubGroupID { get; set; }
        public int? ClassID { get; set; }
        public int? SubClassID { get; set; }
        public int? ManufacturerID { get; set; }
        public int TrackingTypeID { get; set; }
        public int ItemTypeID { get; set; }
        public int ItemValuationID { get; set; }
        public int BaseUnitID { get; set; }
        public int PurchaseUnitID { get; set; }
        public int SaleUnitID { get; set; }
        public decimal? AverageCost { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? MinimumMargin { get; set; }
        public bool CanBackOrder { get; set; }
        public bool CanPriceOverride { get; set; }
        public bool CanMarginOverride { get; set; }
        public bool PromotionAllowed { get; set; }
        public bool DiscountAllowed { get; set; }
        public bool IsOpenPriceItem { get; set; }
        public bool IsNarcotics { get; set; }
        public int? PrimeVendorID { get; set; }
        public string ItemDimension { get; set; }
        public decimal? ItemVolume { get; set; }
        public decimal? ItemWeight { get; set; }
        public string ItemNote { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int? EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsActive { get; set; }

    }
}
