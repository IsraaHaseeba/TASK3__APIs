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
        public async Task<List<UserViewModel>> GetAll()
        {
            List<User> users = await _IUserRepo.getAll();
            return _mapper.Map<List<UserViewModel>>(users);

        }


        [HttpGet("{id}")]
        public async Task<UserViewModel> Get(int id)
        {
            var user = _IUserRepo.Get(id);
            return  _mapper.Map<UserViewModel>(user);
         
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           _IUserRepo.Delete(id);
        }

        [HttpPost]
        public async Task Create([FromBody] UserViewModel userModel)
        {
            var _user = _mapper.Map<User>(userModel);
            var user = _IUserRepo.Get(_user.Id);
            await _IUserRepo.Add(await user);

        }

        [HttpPut]
        public async Task Update(UserViewModel userModel)
        {
           await  _IUserRepo.update(_mapper.Map<User>(userModel));
        }
    }
}
