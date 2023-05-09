using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaderboardController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public LeaderboardController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Player>>> GetTop10Players()
        {
            var top10Players = await _playerService.GetTop10PlayersAsync();
            return Ok(top10Players);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> AddOrUpdatePlayer([FromBody] Player player)
        {
            var updatedPlayer = await _playerService.AddOrUpdatePlayerAsync(player);
            return Ok(updatedPlayer);
        }
    }
}

