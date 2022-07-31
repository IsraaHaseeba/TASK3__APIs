using AutoMapper;
using UserAPI.Models;
using UsersAPI.Models;

namespace UsersAPI.ViewModels
{
    public class MapConfig: Profile
    {
        public MapConfig()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Post, PostModel>().ReverseMap();

        }

    }
}
