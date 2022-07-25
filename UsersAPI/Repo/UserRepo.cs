using UserAPI.Models;
using UsersAPI.Models;
using UsersAPI.ViewModels;

namespace UsersAPI.Repo
{
    public class UserRepo: IUserRepo
    {


        private UserContext _context;
        
        public UserRepo(UserContext context)
        {
            _context = context;
           
        }

        public  List<User> getAll()
        {
            List<User> usersList;
            usersList = _context.Set<User>().ToList();
            
            return usersList;
        }

        public User Get(int id)
        {
            User user;
            
                user = _context.Find<User>(id);
            
            return user;
        }

        public ResponseModel Delete(int id)
        {
            ResponseModel model = new ResponseModel();
            
                User _temp = Get(id);
                if (_temp != null)
                {
                    _context.Remove<User>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "User Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "User Not Found";
                }
            _context.SaveChanges();

            return model;
        }

        public ResponseModel update(User userModel)
        {
            ResponseModel model = new ResponseModel();
            
                User _temp = Get(userModel.Id);
                if (_temp != null)
                {
                    _temp.Id = userModel.Id;
                    _temp.Name = userModel.Name;
                    _temp.Email = userModel.Email;
                    if(userModel.Posts!=null)
                    _temp.Posts = userModel.Posts;

                    _context.Update<User>(_temp);
                    model.Messsage = "User Update Successfully";
                }
            _context.SaveChanges();

            return model;
        }
        public ResponseModel Add(User user)
        {
            ResponseModel model = new ResponseModel();
            User _temp = Get(user.Id);
            if (_temp == null)
            {
                _context.Add<User>(user);
                model.Messsage = "User Inserted Successfully";

            }
            _context.SaveChanges();
            return model;
        }

        
    }


    public class PostRepo : IPostRepo
    {


        private UserContext _context;

        public PostRepo(UserContext context)
        {
            _context = context;

        }

        public List<Post> getAll()
        {
            List<Post> postsList;
            postsList = _context.Set<Post>().ToList();

            return postsList;
        }

        public Post Get(int id)
        {
            Post post= _context.Find<Post>(id);
            
            return post;
        }

        public ResponseModel Delete(int id)
        {
            ResponseModel model = new ResponseModel();

            Post _temp = Get(id);
            if (_temp != null)
            {
                _context.Remove<Post>(_temp);
                _context.SaveChanges();
                model.IsSuccess = true;
                model.Messsage = "Post Deleted Successfully";
            }
            else
            {
                model.IsSuccess = false;
                model.Messsage = "Post Not Found";
            }
            _context.SaveChanges();

            return model;
        }

        public ResponseModel update(Post post)
        {
            ResponseModel model = new ResponseModel();

            Post _temp = Get(post.Id);
            if (_temp != null)
            {
                _temp.Id = post.Id;
                _temp.Title = post.Title;
                _temp.Description = post.Description;
                _temp.User = post.User;
                _temp.UserID = post.UserID;

                _context.Update<Post>(_temp);
                model.Messsage = "post Update Successfully";
            }
            _context.SaveChanges();

            return model;
        }
        public ResponseModel Add(Post post)
        {
            ResponseModel model = new ResponseModel();
            Post _temp = Get(post.Id);
            if (_temp == null)
            {
                _context.Add<Post>(post);
                model.Messsage = "Post Inserted Successfully";

            }
            _context.SaveChanges();
            return model;
        }


    }

}
