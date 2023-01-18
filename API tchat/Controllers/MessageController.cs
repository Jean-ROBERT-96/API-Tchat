using CommonLibrary.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_tchat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IRepository<Message> _repo;

        public MessageController(IRepository<Message> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Message>>> Get()
        {
            return Ok(await _repo.Get());
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Post(Message message)
        {
            return CreatedAtAction("Post", await _repo.Post(message));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Message>> Put(int id, Message message)
        {
            return Ok(await _repo.Put(id, message));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Message>> Delete(int id)
        {
            return Ok(await _repo.Delete(id));
        }
    }
}
