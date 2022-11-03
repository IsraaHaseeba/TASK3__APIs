using UsersAPI.Models;
using UsersAPI.ViewModels;

namespace UsersAPI.Repo
{
    public interface IPostRepo: IGenRepo<Post>
    {
        public List<PostViewModel> Search(int page, int size, string textToSearch);

    }
}