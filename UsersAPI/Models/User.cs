using System.ComponentModel.DataAnnotations;
using UsersAPI.Models;

namespace UserAPI.Models
{
    public class User
    {
        [Key]
        public int Id{ get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public ICollection<Post>? Posts { get; set; }
    }
}
