using CommonLibrary.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_tchat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectController : ControllerBase
    {
        private readonly IConnectRepository _repo;

        public ConnectController(IConnectRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<User>> Get(string mail, string password)
        {
            return Ok(await _repo.Get(mail, password));
        }
    }
}
