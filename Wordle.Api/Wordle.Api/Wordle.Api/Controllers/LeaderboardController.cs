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

        [HttpGet("daily")]
        public async Task<string[]> GetLastTenDays()
        {
            return await _leaderboardService.GetLastTenDays();
        }

        [HttpPost]
        public async Task<Player> UpdatePlayers(string name, int attempts)
        {
            return await _leaderboardService.UpdatePlayer(name, attempts);
        }
        [HttpPost("daily")]
        public async Task<DateWord?> UpdateDateWord(string word, int attempts) 
        {
            return await _leaderboardService.UpdateDateWord(word, attempts);
        }
    }
}