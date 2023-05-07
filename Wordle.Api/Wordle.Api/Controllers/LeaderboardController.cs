using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaderboardController : ControllerBase
    {
        private readonly LeaderboardService _leaderboardService;

        public LeaderboardController(LeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        [HttpGet("Leaderboard")]
        public async Task<IEnumerable<Player>> GetLeaderboard() 
        {
            return _leaderboardService.GetLeaderboard();
        }

        [HttpPost("AddPlayer")]
        public async Task<Player> AddPlayer(string Name, double AverageAttempts, int GameCount)
        {
            return await _leaderboardService.AddPlayer(Name, AverageAttempts, GameCount);
        }
    }
}