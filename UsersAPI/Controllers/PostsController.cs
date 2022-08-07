using Microsoft.AspNetCore.Mvc;
using UsersAPI.Models;
using UsersAPI.Repo;
using UsersAPI.ActionFilters.Filters;
using UsersAPI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace UsersAPI.Controllers
{
    [Authorize(Roles = "Admin")]

    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[ActionFilterExample("admin")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepo _IPostRepo;
        private UserContext _context;
        private IUserRepo _IUserRepo;
        private IMapper _mapper;

        
        public PostsController(IPostRepo repo, UserContext userContext, 
            IUserRepo iUserRepo, IMapper imapper)
        {
            _IPostRepo = repo;
            _context = userContext;
            _IUserRepo = iUserRepo;
            _mapper = imapper;  
        }
        //[ActionFilterExample("admin")]
        [HttpGet]
       
        public  async Task<List<PostViewModel>> GetAll()
        {
            var posts =await _IPostRepo.getAll<PostViewModel>();
            return posts;
        }
        
        [HttpGet("{id}")]
        public   PostViewModel Get(int id)
        {
            return  _IPostRepo.Get<PostViewModel>(id);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
             await _IPostRepo.Delete(id);
        }

        [HttpPost]
        public async Task Create([FromBody] PostViewModel postModel)
        {
            var _post = _mapper.Map<Post>(postModel);
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("UserID")?.Value;
            
            _post.UserID = Convert.ToInt32(userId);
            await _IPostRepo.Add(_post, Convert.ToInt32(userId));
         
        }

        [HttpPut]
        public async Task Update( PostViewModel postModel)
        {
            var _post = _mapper.Map<Post>(postModel);
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("UserID").Value;


            await _IPostRepo.update(_mapper.Map<PostViewModel,Post>(postModel), Convert.ToInt32(userId));
           
        }
        [HttpGet("{page},{size},{textToSearch}")]
        public  List<PostViewModel> Search(int page, int size, string textToSearch)
        {
            return  _IPostRepo.Search(page, size, textToSearch);
            
        }
    }
}
