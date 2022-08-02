using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UsersAPI.Repo;
using ICSharpCode.Decompiler.CSharp.Syntax;
using Microsoft.AspNetCore.Authorization;
using UsersAPI.ActionFilters.Filters;
using UsersAPI.ViewModels;
using AutoMapper;

namespace UserAPI.Controllers
{
    //[ActionFilterExample("admin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _IUserRepo;
        private readonly IMapper _mapper;
        public UsersController(IUserRepo repo, IMapper iMapper)
        {
            _IUserRepo= repo;
            _mapper = iMapper;
        }

        [HttpGet]
        //[ActionFilterExample("admin")]
        public async Task<List<UserViewModel>> GetAll()
        {
            var users = await _IUserRepo.getAll<UserViewModel>();
            return users;

        }


        [HttpGet("{id}")]
        public  UserViewModel Get(int id)
        {
            var user =  _IUserRepo.Get<UserViewModel>(id);
            return  user;
         
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _IUserRepo.Delete(id);
        }

        [HttpPost]
        public async Task Create([FromBody] UserViewModel userModel)
        {
            var _user = _mapper.Map<UserViewModel,User>(userModel);
            await _IUserRepo.Add(_user);

        }

        [HttpPut]
        public async Task Update(UserViewModel userModel)
        {
           await  _IUserRepo.update(_mapper.Map<UserViewModel,User>(userModel));
        }
    }
}
