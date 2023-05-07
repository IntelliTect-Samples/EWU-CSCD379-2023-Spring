using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
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

        [HttpGet]
        public async Task<IEnumerable<Player>> Get()
        {
            return await _playerService.GetTopTenScores();
        }

        [HttpPost]
        public async Task<Player> AddPlayer(string newName, int attempts, int? secondsInGame)
        {
            return await _playerService.AddPlayer(newName, attempts, secondsInGame);
        }
    }
}
