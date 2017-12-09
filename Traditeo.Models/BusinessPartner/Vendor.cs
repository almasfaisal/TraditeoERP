using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.BusinessPartner
{
    public class Vendor
    {
        [Key]
        public int VendorID { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public int PriceListID { get; set; }
        public int AccountID { get; set; }
    } 
}
