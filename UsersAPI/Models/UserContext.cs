using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UsersAPI.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options) { }
        DbSet<User> Users  { get;  set; }
    }
}
