using CommonLibrary.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_tchat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _repo;

        public UserController(IRepository<User> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _repo.Get());
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            return CreatedAtAction("Post", await _repo.Post(user));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, User user)
        {
            return Ok(await _repo.Put(id, user));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            return Ok(await _repo.Delete(id));
        }
    }
}
