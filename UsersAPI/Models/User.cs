using Microsoft.AspNetCore.Identity;
using UsersAPI.Models;

namespace UserAPI.Models
{
    public class User: IdentityUser<int>, IBaseModel
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? Email { get; set; }

        public ICollection<Post>? Posts { get; set; }
    }
}
