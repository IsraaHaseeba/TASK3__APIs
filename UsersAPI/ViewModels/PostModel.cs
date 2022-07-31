namespace UsersAPI.ViewModels
{
    public class PostModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int UserID { get; set; }
    }
}
