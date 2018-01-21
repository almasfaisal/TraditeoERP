using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.ApplicationSetup.FinancialAccounting
{
    public class AccountTypes
    {
        public int AccountTypeID { get; set; }
        public string AccountType { get; set; }
        public bool IsActive { get; set; }
    }
}
