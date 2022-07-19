using UserAPI.Models;

namespace UsersAPI.Repo
{
    public class UserRepo
    {
        static List<User> users { get; set; }

        static UserRepo()
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

        public static List<User> getAll()
        {
            return users;
        }

        public static User Get(int id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }

        public static void Delete(int id)
        {
            var user = Get(id);
            if (user != null)
                users.Remove(user);
        }

        public static void Add(User user)
        {
            users.Add(user);
        }

        public static void update(User user)
        {
            var index = users.FindIndex(e => e.Id == user.Id);
            if (index == -1)
                return;
            users[index] = user;
        }
    }

}
