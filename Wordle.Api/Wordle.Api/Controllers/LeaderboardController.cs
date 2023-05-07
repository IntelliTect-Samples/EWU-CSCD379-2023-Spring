using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        [HttpGet("{count}")] // ✅
        public async Task<ActionResult<List<Player>>> GetTopPlayers(int count)
        {
            // Set count to 50 if it's less than 1
            if (count < 1)
            {
                count = 50;
            }

            var topPlayers = await _leaderboardService.GetTopPlayers(count);
            return Ok(topPlayers);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> AddPlayerToLeaderboard([FromBody] PlayerDto player)
        {
            var addedPlayer = await _leaderboardService.AddPlayerToLeaderboard(player);
            return CreatedAtAction(nameof(GetTopPlayers), new { count = 10 }, addedPlayer);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePlayerOnLeaderboard([FromBody] PlayerDto player)
        {
            var updated = await _leaderboardService.UpdatePlayerOnLeaderboard(player);
            if (!updated) return NotFound();
            return NoContent();
        }
    }
}
