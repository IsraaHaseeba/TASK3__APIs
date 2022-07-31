using Microsoft.AspNetCore.Mvc;
using UsersAPI.Models;
using UsersAPI.Repo;
using UsersAPI.ActionFilters.Filters;
using UsersAPI.ViewModels;
using AutoMapper;

namespace UsersAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [ActionFilterExample("admin")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepo _IPostRepo;
        private UserContext _context;
        private IUserRepo _IUserRepo;
        private readonly IMapper _mapper;

        public PostsController(IPostRepo repo, UserContext userContext, 
            IUserRepo iUserRepo, IMapper iMapper)
        {
            _IPostRepo = repo;
            _context = userContext;
            _IUserRepo = iUserRepo;
            _mapper = iMapper;  
        }
        [ActionFilterExample("admin")]
        [HttpGet]
       
        public  async Task<List<PostViewModel>> GetAll()
        {
            var posts = _IPostRepo.getAll();
            return _mapper.Map<List<PostViewModel>>(posts);
        }

        [HttpGet("{id}")]
        public async  Task<PostViewModel> Get(int id)
        {
            var post = _IPostRepo.Get(id);
            var postModel = _mapper.Map<PostViewModel>(post);
            return postModel;
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _IPostRepo.Delete(id);
        }

        [HttpPost]
        public async Task Create([FromBody] PostViewModel postModel)
        {
            var _post = _mapper.Map<Post>(postModel);
            var post = _IPostRepo.Get(_post.Id);
           await _IPostRepo.Add(await post);
         
        }

        [HttpPut]
        public async Task Update( PostViewModel postModel)
        {

            await _IPostRepo.update(_mapper.Map<Post>(postModel));
           
        }
    }
}
