using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        //[HttpGet("GetTop10")]
        //public Player GetManyWords([FromBody] PlayerDto player)
        //{
        //    return _playerService.AddPlayer(player.Name, player.GameCount, player.AverageAttempts, player.AveargeSecondsPerGame);
        //}

        [HttpPost("AddPlayerFromBody")]
        public async Task<Player> AddPlayerFromBody([FromBody] PlayerDto player)
        {
            return await _playerService.AddPlayer(player.Name, player.GameCount, player.AverageAttempts, player.AveargeSecondsPerGame);
        } 
    }
}
