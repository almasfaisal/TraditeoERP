using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.DAO.Security
{
    public interface IUsers
    {
        [Key]
        string UserID { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }
}
