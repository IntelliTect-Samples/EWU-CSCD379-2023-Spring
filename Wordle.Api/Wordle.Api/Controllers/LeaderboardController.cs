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
        public IEnumerable<Player> GetLeaderboard()
        {
            return _leaderboardService.GetLeaderboard();
        }

        [HttpPost("AddPlayer")]
        public async Task AddPlayer(string Name, int Attempts)
        {
            await _leaderboardService.AddPlayer(Name, Attempts);
        }
    }
}