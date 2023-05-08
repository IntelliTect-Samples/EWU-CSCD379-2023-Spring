using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class LeaderboardController : ControllerBase
    {
        // hi
        private readonly LeaderboardService _leaderboardService;

        public LeaderboardController(LeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        [HttpGet("Leaderboard")]
        public IEnumerable<Player> GetLeaderboard()
        {
            return _leaderboardService.GetLeaderboard();
        }

        [HttpPost("AddPlayer")]
        public async Task<Player> AddPlayer(PlayerDto player)
        {
            return await _leaderboardService.AddPlayer(player.Name, player.Attempts, player.secondsPerGame);
        }
    }
}