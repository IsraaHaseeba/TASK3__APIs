using UsersAPI.Models;

namespace UsersAPI.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? Email { get; set; }

        public ICollection<PostModel>? Posts { get; set; }
    }
}
