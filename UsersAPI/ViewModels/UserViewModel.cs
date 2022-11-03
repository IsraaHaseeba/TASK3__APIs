using UsersAPI.Models;

namespace UsersAPI.ViewModels
{
    public class UserViewModel: BaseModel
    {
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }
        public ICollection<PostViewModel>? Posts { get; set; }
    }
}
