using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserAPI.Models;

namespace UsersAPI.Models
{
        public class Post
        {
            [Key]
            public int Id { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }

            [ForeignKey("User")]
            public int UserID { get; set; }

            public User? User { get; set; }

    }
    

}
