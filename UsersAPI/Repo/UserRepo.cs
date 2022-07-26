﻿using Microsoft.EntityFrameworkCore;
using UserAPI.Models;
using UsersAPI.Models;
using UsersAPI.ViewModels;

namespace UsersAPI.Repo
{
    public class UserRepo: GenRepo<User>, IUserRepo
    {
        
        public UserRepo(UserContext context) :base(context)
        {
            
        }

        public new List<User>? getAll()
        {
            return _context.Users2.Include(p => p.Posts).ToList();
        }

       
    }


    public class PostRepo : GenRepo<Post>, IPostRepo
    {
        public PostRepo(UserContext context) :base(context)
        {
             
        }
        public new List<Post>? getAll()
        {
            return _context.Post.Include(u => u.User).ToList();
        }



    }

}
