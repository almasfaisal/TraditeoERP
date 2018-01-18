using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Traditeo.Models.Security
{
    public class Users
    {
        private Models.Security.Users _users;

        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int RoleID { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public string DisplayName { get; set; }
        [NotMapped]
        public bool IsValidated { get; set; }

        public Models.Security.Users GetUsers(Models.Security.Users user, string password)
        {
            _users = user;
            if (Models.Utility.Encryption.Encrypt (password) == user.Password)
            {
                _users.IsValidated = true;
            }
            else
            {
                _users = null;
            }
            return _users;
        }
    }
}
