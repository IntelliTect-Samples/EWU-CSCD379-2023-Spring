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


        [HttpPost("AddPlayer")]
        public async Task<Player> AddPlayer([FromBody] PlayerDto player)
        {
            return await _playerService.AddPlayer(player.Name, player.NumAttempts, player.AverageSecondsPerGame); 
        }

        [HttpPost("InsertScore")]
        public async Task<Player> InsertScore([FromBody] PlayerDto player) {
            return await _playerService.InsertScore(player.Name, player.NumAttempts, player.AverageSecondsPerGame); 
        }

        [HttpGet("GetTopTenPlayers")]
        public async Task<string> GetTopTenPlayers()
        {
            return await _playerService.GetTopTenPlayers();
        }
    }

}

