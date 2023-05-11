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
        public async Task<IEnumerable<PlayerDto>> Get()
        {
            return await _playerService.GetTopTenScores();
        }

        [HttpPost]
        public async Task<Player> AddPlayer([FromBody] GameResultDto game)
        {
            return await _playerService.AddPlayer(game.Name, game.Attempts, game.SecondsInGame, game.GameCount);
        }
    }
}
