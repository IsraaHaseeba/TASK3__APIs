
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
     
        /* public new async Task<List<PostViewModel>>? getAll()
         {
             return _context.Users2.ProjectTo<PostViewModel>(_imapper.ConfigurationProvider).ToList();
         }*/



    }

}
