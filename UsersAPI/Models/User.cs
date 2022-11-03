using Microsoft.AspNetCore.Identity;
using UsersAPI.Models;

namespace UserAPI.Models
{
    public class User: IdentityUser<int>, IBaseModel
    {
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ICollection<Post>? Posts { get; set; }

    }
}
