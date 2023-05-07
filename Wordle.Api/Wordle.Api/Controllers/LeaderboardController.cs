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

    [HttpPost("AddNewPlayer")]
    public async Task<Player> AddNewPlayer(string? playerName, int timeInSeconds, double attempts) 
    {
        return await _leaderboardService.AddNewPlayer(playerName, timeInSeconds, attempts);
    }
}
