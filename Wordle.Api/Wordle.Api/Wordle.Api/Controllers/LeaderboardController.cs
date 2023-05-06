using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly LeaderboardService _leaderboardService;
        public LeaderboardController(LeaderboardService leaderboardService) {

            _leaderboardService = leaderboardService;
        }
        [HttpGet]
        public async Task<string[]> Get() 
        {
            return await _leaderboardService.GetTopScores();
        }

        [HttpPost]
        public async Task<Player> UpdatePlayers(string name, int attempts)
        {
            return await _leaderboardService.UpdatePlayer(name, attempts);
        }
    }
}