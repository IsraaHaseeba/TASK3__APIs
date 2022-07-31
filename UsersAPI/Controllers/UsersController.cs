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
    [ActionFilterExample("admin")]
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
        [ActionFilterExample("admin")]
        public List<UserModel> GetAll()
        {
            List<User> users = _IUserRepo.getAll();
            return _mapper.Map<List<UserModel>>(users);

        }


        [HttpGet("{id}")]
        public UserModel Get(int id)
        {
            var user = _IUserRepo.Get(id);
            var userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           _IUserRepo.Delete(id);
        }

        [HttpPost]
        public async Task Create([FromBody] UserModel userModel)
        {
            var _user = _mapper.Map<User>(userModel);
            var user = _IUserRepo.Get(_user.Id);
           await  _IUserRepo.Add(user);

        }

        [HttpPut]
        public async Task Update(UserModel userModel)
        {
           await  _IUserRepo.update(_mapper.Map<User>(userModel));
        }
    }
}
