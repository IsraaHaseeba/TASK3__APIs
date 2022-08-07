
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UserAPI.Controllers;
using UserAPI.Models;
using UsersAPI.Models;
using UsersAPI.ViewModels;

namespace UsersAPI.Repo
{

    public class UserRepo: GenRepo<User>, IUserRepo
    {

        public UserRepo(UserContext context, IMapper iMapper) :base(context, iMapper)
        {
            
        }
        
        /*public new async  Task<List<UserViewModel>>? getAll()
        {
            return _context.Users2.ProjectTo<UserViewModel>(_imapper.ConfigurationProvider).ToList();
        }
        */
       
    }


    public class PostRepo : GenRepo<Post>, IPostRepo
    {
       

        public PostRepo(UserContext context, IMapper imapper) :base(context, imapper)
        {
            
        }
     
         public List<PostViewModel> Search(int page, int size, string textToSearch)
         {
            if (string.IsNullOrWhiteSpace(textToSearch)) return null;
             return  _context.Post.ProjectTo<PostViewModel>(_imapper.ConfigurationProvider).Where(x => x.Title.ToLower().Contains(textToSearch.ToLower().Trim())).Skip(page*size).Take(size).ToList();
         }

        
    }

}
