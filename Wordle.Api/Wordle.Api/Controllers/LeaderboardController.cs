using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class LeaderboardController : ControllerBase
{
    private readonly LeaderboardService _leaderboardService;

    public LeaderboardController(LeaderboardService leaderboardService)
    {
        _leaderboardService = leaderboardService;
    }

    [HttpGet("GetTopTenScores")]
    public async Task<IEnumerable<Player>> GetTopTenScores()
    {
        return await _leaderboardService.GetTopTenScores();
    }

    [HttpGet("GetPlayerStats")]
    public async Task<IEnumerable<Player>> GetPlayerStats(string playerName)
    {
        return await _leaderboardService.GetPlayerStats(playerName);
    }

    [HttpPost("AddNewPlayer")]
    public async Task<Player> AddNewPlayer([FromBody] PlayerDto player)
    {
        return await _leaderboardService.AddNewPlayer(player.Name, player.TimeInSeconds,
                                                      player.Attempts);
    }
}
