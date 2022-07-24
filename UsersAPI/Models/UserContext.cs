using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UsersAPI.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions <UserContext>options) : base(options) { }
        DbSet<User> Users2  { get;  set; }
        DbSet<User> Post { get; set; }

    }
}
