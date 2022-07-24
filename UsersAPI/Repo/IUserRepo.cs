using UserAPI.Models;
using UsersAPI.ViewModels;

namespace UsersAPI.Repo
{
    public interface IUserRepo
    {
        public List<User> getAll();
        public User Get(int id);
        public ResponseModel Delete(int id);
        public ResponseModel Add(User user);
        public ResponseModel update(User user);


    }
}