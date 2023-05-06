using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost("UpdatePlayer")]
        public async Task<string> Update(string name, int attempts)
        {
            return await _playerService.UpdatePlayerAsync(name, attempts);
        }

        [HttpGet("GetPlayer")]
        public async Task<List<Player>> Get()
        {
            return await _playerService.GetTopTen();
        }
    }
}

