using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly LeaderboardService _leaderboardService;

        public LeaderboardController(LeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        [HttpGet("GetTopPlayers")]
        public async Task<IEnumerable<Player>> Get(int? count)
        {
            return await _leaderboardService.GetTopPlayers(count);
        }

        [HttpPost("InsertScore")]
        public async Task<Player> AddScore([FromBody] PlayerDto player)
        {
            return await _leaderboardService.AddScore(player.Name, player.AverageAttempts, player.AverageSecondsPerGame);
        }

    }
}