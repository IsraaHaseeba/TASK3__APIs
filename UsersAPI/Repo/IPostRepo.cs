using UsersAPI.Models;
using UsersAPI.ViewModels;

namespace UsersAPI.Repo
{
    public interface IPostRepo
    {
        public List<Post> getAll();
        public Post Get(int id);
        public ResponseModel Delete(int id);
        public ResponseModel Add(Post post);
        public ResponseModel update(Post post);

    }
}