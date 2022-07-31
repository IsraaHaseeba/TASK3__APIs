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
       
        public  List<PostModel> GetAll()
        {
            var posts = _IPostRepo.getAll();
            return _mapper.Map<List<PostModel>>(posts);
        }

        [HttpGet("{id}")]
        public  PostModel Get(int id)
        {
            var post = _IPostRepo.Get(id);
            var postModel = _mapper.Map<PostModel>(post);
            return postModel;
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _IPostRepo.Delete(id);
        }

        [HttpPost]
        public async Task Create([FromBody] PostModel postModel)
        {
            var _post = _mapper.Map<Post>(postModel);
            var post = _IPostRepo.Get(_post.Id);
           await _IPostRepo.Add(post);
         
        }

        [HttpPut]
        public async Task Update( PostModel postModel)
        {

            await _IPostRepo.update(_mapper.Map<Post>(postModel));
           
        }
    }
}
