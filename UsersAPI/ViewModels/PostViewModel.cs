using UsersAPI.Models;

namespace UsersAPI.ViewModels
{
    public class PostViewModel: BaseModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int UserID { get; set; }
        public DateTime creationDate { get; set; }

        public DateTime updateDate { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
    }
}
