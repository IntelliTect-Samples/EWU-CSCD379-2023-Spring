using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly PlayerService _PlayerService;
    public PlayerController(PlayerService playerService)
    {
        _PlayerService = playerService;
    }

    [HttpGet]
    public async Task<ActionResult<PlayerDto>> Get(Guid id)
    {
        Player? player = await _PlayerService.GetPlayerAsync(id);

        if (player is not null)
        {
            return new PlayerDto(player);
        }
        return BadRequest();
    }

    [HttpGet("TopPlayers")]
    public async Task<IEnumerable<PlayerDto>> GetTopPlayers()
    {
        return (await _PlayerService.GetTopPlayersAsync()).Select(player=>new PlayerDto(player));
    }

    [HttpPost]
    public async Task<PlayerDto> Post([FromBody] string name)
    {
        return new PlayerDto(await _PlayerService.CreatePlayerAsync(name));
    }

}