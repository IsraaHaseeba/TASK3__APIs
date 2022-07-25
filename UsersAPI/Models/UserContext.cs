using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UsersAPI.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions <UserContext>options) : base(options) { }
        public DbSet<User> Users2  { get;  set; }
        public DbSet<User> Post { get; set; }

    }
}
