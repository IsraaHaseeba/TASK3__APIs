using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UsersAPI.Repo;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _IUserRepo;
        public UsersController(IUserRepo repo)
        {
            _IUserRepo= repo;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _IUserRepo.getAll();
        }


        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _IUserRepo.Get(id);
            if (user == null) return NotFound();
            return user;
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _IUserRepo.Get(id);
            if (user == null) return NotFound();
            _IUserRepo.Delete(id);
            return Ok();
        }

        [HttpPost]
        public ActionResult Create([FromBody] User user)
        {

            var _user = _IUserRepo.Get(user.Id);
            if (_user != null) return BadRequest("User already exists!");
            _IUserRepo.Add(user);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update( User user)
        {
            _IUserRepo.update(user);
            return Ok();
        }
    }
}
