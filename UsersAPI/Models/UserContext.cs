using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserAPI.Models;
using UsersAPI.Auth;

namespace UsersAPI.Models
{
    public class UserContext : IdentityDbContext<User, UserRole, int>
    {
        public UserContext(DbContextOptions <UserContext>options) : base(options) { }
        public DbSet<User> Users2  { get;  set; }
        public DbSet<Post> Post { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
