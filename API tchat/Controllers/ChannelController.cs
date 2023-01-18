using CommonLibrary.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_tchat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private readonly IRepository<Channel> _repo;

        public ChannelController(IRepository<Channel> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Channel>>> Get()
        {
            return Ok(await _repo.Get());
        }

        [HttpPost]
        public async Task<ActionResult<Channel>> Post(Channel channel)
        {
            return CreatedAtAction("Post", await _repo.Post(channel));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Channel>> Put(int id, Channel channel)
        {
            return Ok(await _repo.Put(id, channel));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Channel>> Delete(int id)
        {
            return Ok(await _repo.Delete(id));
        }
    }
}
