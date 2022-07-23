using UserAPI.Models;

namespace UsersAPI.Repo
{
    public interface IUserRepo
    {
      //  public List<User> users { get; set; }
        public List<User> getAll();
        public User Get(int id);
        public void Delete(int id);
        public void Add(User user);
        public void update(User user);


    }
}