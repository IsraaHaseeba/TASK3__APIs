using UsersAPI.Models;

namespace UsersAPI.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? Email { get; set; }

        public ICollection<PostViewModel>? Posts { get; set; }
    }
}
