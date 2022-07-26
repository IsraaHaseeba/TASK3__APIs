using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UsersAPI.Models;
using UsersAPI.Repo;

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepo _IPostRepo;
        private UserContext _context;
        private IUserRepo _IUserRepo;

        public PostsController(IPostRepo repo, UserContext userContext, IUserRepo iUserRepo)
        {
            _IPostRepo = repo;
            _context = userContext;
            _IUserRepo = iUserRepo;
        }
        [HttpGet]
        public ActionResult<List<Post>> GetAll()
        {
            return _IPostRepo.getAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Post> Get(int id)
        {
            var post = _IPostRepo.Get(id);
            if (post == null) return NotFound();
            return post;
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var post= _IPostRepo.Get(id);
            if (post == null) return NotFound();
            _IPostRepo.Delete(id);
            return Ok();
        }

        [HttpPost]
        public ActionResult Create([FromBody] Post post)
        {

            var _post = _IPostRepo.Get(post.Id);
            if (_post != null) return BadRequest("Post already exists!");
            
            _IPostRepo.Add(post);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update( Post post)
        {
            _IPostRepo.update(post);
            return Ok();
        }
    }
}
