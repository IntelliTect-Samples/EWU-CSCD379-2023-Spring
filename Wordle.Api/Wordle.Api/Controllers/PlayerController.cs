using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly PlayerService _playerService;

    public PlayerController(PlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlayerDto>> Get(int id)
    {
        var player = await _playerService.GetPlayerAsync(id);
        if (player == null)
        {
            return NotFound();
        }
        return player.MapToDto();
    }

    [HttpGet]
    public async Task<IEnumerable<PlayerDto>> Get()
    {
        var players = await _playerService.GetPlayersAsync();
        return players.Select(p => p.MapToDto());
    }

    [HttpPost]
    public async Task<ActionResult<PlayerDto>> Create()
    {
        var player = await _playerService.CreatePlayerAsync();
        return CreatedAtAction(nameof(Get), new { id = player.PlayerId }, player.MapToDto());
    }

    [HttpPut]
    public async Task<ActionResult<PlayerDto?>> Put([FromBody] PlayerDto dto)
    {
        PlayerDto? player = await _playerService.Update(dto);
        if (player is not null)
        {
            return player;
        }
        return BadRequest();
    }
}
