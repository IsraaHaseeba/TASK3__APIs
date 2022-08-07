using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserAPI.Models;

namespace UsersAPI.Models
{
    public class Post : BaseModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public User? User { get; set; }

        public int createdBy{get; set;}
        public int updatedBy { get; set; }

        public DateTime creationDate { get; set; }

        public DateTime updateDate { get; set; }

    }
    

}
