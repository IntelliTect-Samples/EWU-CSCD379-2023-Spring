using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;
using Wordle.Api.Dtos;
namespace Wordle.Api.Controllers;


[Route("[controller]")]
[ApiController]
public class LeaderboardController : ControllerBase
{
    private readonly LeaderboardService _leaderBoardService;

    public LeaderboardController(LeaderboardService leaderboardService)
    {
        _leaderBoardService = leaderboardService;
    }

    [HttpGet("LeaderBoard")]
    public IEnumerable<Player> GetLeaderBoard()
    {
        return _leaderBoardService.GetLeaderboard();
    }
    [HttpPost("AddPlayer")]
    public async Task<Player> AddPlayer(PlayerDto player)
    {
        return await _leaderBoardService.AddPlayer(player.Name, player.Attempts, player.SecondsPerGame);
    }
}
