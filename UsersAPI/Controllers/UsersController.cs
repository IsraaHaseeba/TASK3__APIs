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
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return UserRepo.getAll();
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = UserRepo.Get(id);
            if (user == null) return NotFound();
            return user;
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = UserRepo.Get(id);
            if (user == null) return NotFound();
            UserRepo.Delete(id);
            return Ok();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {

            var _user = UserRepo.Get(user.Id);
            if (_user != null) return BadRequest("User already exists!!!");
            UserRepo.Add(user);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(int id, User user)
        {
            var _user = UserRepo.Get(id);
            if (_user == null)
                return NotFound();
            if(user.Id != id) return BadRequest("Id cannot be updated!");
            UserRepo.update(user);
            return Ok();
        }
    }
}
