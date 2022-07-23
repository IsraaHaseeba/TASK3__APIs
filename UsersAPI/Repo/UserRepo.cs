using UserAPI.Models;

namespace UsersAPI.Repo
{
    public class UserRepo: IUserRepo
    {

        private  List<User> users { get; set; }


         public UserRepo()
        {
            users = new List<User>()
            {
                new User(){ Id = 1, Name = "Mohammad", Email = "mohammad12@gmail.com"},
                new User(){ Id = 2, Name = "Luay", Email = "Luay12@gmail.com"},
                new User(){ Id = 3, Name = "Huda", Email = "huda12@gmail.com"},
                new User(){ Id = 4, Name = "Lama", Email = "lama12@gmail.com"},
                new User(){ Id = 5, Name = "Roa", Email = "roa12@gmail.com"}




            };
        }

        public  List<User> getAll()
        {
            return users;
        }

        public User Get(int id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }

        public  void Delete(int id)
        {
            var user = Get(id);
            if (user != null)
                users.Remove(user);
        }

        public  void Add(User user)
        {
            users.Add(user);
        }

        public  void update(User user)
        {
            var index = users.FindIndex(e => e.Id == user.Id);
            if (index == -1)
                return;
            users[index] = user;
        }
    }

}
