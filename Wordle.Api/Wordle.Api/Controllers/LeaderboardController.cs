using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaderboardController : ControllerBase
    {
        private readonly LeaderboardService _leaderboardService;

        public LeaderboardController(LeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        [HttpPost("AddNewScore")]
        public async Task<Player> AddNewScore(string name, int attempts)
        {
            //Add the players score to the database
            return await _leaderboardService.AddNewScore(name, attempts);

        }

        [HttpGet("GetTopTenScores")]
        public async Task<IEnumerable<Player>> GetTopTenScores()
        {
            return await _leaderboardService.GetTopTenScores();
        }
    }
}
