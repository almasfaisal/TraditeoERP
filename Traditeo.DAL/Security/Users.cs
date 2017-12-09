using System.Data.Entity;
using System.Linq;

namespace Traditeo.DAL.Security
{
    public class Users : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Security.Users>().ToTable("Users");
        }

        public Users() 
        : base("ConnectionString") 
            { }
        public DbSet<Models.Security.Users> UserList { get; set; }

        public Models.Security.Users GetUsers(string usernName)
        {
            return UserList.FirstOrDefault<Models.Security.Users>(a => a.UserName ==  usernName );

            //return JsonConvert.SerializeObject(user));
            //using (var user = new Users())
            //{
            //    var ur = user.UserList.FirstOrDefault<Models.Security.Users>(a => a.UserName == " + usernName + ");
            //}
            //UserList.Where<Models.Security.Users>()
            //var user = UserList.SqlQuery("SELECT * FROM Users WHERE UserName='" + usernName + "'").FirstOrDefault<Models.Security.Users>();

            //return user;
        }
    }
}
