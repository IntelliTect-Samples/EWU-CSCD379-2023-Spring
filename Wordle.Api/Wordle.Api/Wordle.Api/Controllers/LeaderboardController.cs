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
        public async Task<string[]> GetLastTenDays(string name)
        {
            return await _leaderboardService.GetLastTenDays(name);
        }

        [HttpPost]
        public async Task<Player> UpdatePlayers(string name, int attempts)
        {
            return await _leaderboardService.UpdatePlayer(name, attempts);
        }
        [HttpPost("daily")]
        public async Task<DateWord?> UpdateDateWord(string word, int attempts, int seconds) 
        {
            return await _leaderboardService.UpdateDateWord(word, attempts, seconds);
        }
        [HttpPost("completion")]
        public async Task<DailyCompletions> AddDailyCompletion(string name, string word) 
        {
            return await _leaderboardService.AddDailyCompletion(name, word);
        }
    }
}