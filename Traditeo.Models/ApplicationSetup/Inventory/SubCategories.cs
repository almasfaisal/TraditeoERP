﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ApplicationSetup.Inventory
{
    public class SubCategories
    {
        [Key]
        public int SubCategoryID { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategory { get; set; }
        public string SubCategoryAlias { get; set; }
        public int? CategoryID { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int? EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsActive { get; set; }

    }
}
