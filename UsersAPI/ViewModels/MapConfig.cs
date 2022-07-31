using AutoMapper;
using UserAPI.Models;
using UsersAPI.Models;

namespace UsersAPI.ViewModels
{
    public class MapConfig: Profile
    {
        public MapConfig()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Post, PostViewModel>().ReverseMap();

        }

    }
}
