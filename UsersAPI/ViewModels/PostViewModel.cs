using UsersAPI.Models;

namespace UsersAPI.ViewModels
{
    public class PostViewModel: BaseModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int UserID { get; set; }
    }
}
