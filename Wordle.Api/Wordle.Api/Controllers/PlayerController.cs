using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("Player")]
public class PlayerController : ControllerBase
{
    private readonly PlayerService _playerService;

    public PlayerController(PlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet]
    public async Task<ActionResult<PlayerDto>> GetAsync(Guid playerId)
    {
        Player? player = await _playerService.GetAsync(playerId);

        if (player is not null)
        {
            return new PlayerDto(player);
        }
        return BadRequest();
    }

    [HttpGet("TopPlayers")]
    public async Task<IEnumerable<PlayerDto>> GetTopPlayersAsync()
    {
        return (await _playerService.GetTopPlayersAsync()).Select(player => new PlayerDto(player));
    }

    [HttpPost("CreatePlayer")]
    public async Task<PlayerDto> CreatePlayerAsync([FromBody] string name)
    {
        return new PlayerDto(await _playerService.CreateAsync(name));
    }

    [HttpPost("RenamePlayer")]
    public async Task<ActionResult<PlayerDto>> RenamePlayerAsync([FromBody] PlayerDto player)
    {
        if (player.PlayerId is null || player.PlayerId == Guid.Empty)
        {
            return BadRequest();
        }
        if (string.IsNullOrWhiteSpace(player.Name))
        {
            return BadRequest();
        }
        var result = await _playerService.UpdateAsync(player.PlayerId.Value, player.Name.Trim());
        return new PlayerDto(result);
    }

    [HttpPost("AddGameResult")]
    public async Task<ActionResult<PlayerDto>> AddGameResultAsync(GameResultDto dto)
    {
        var playerGame = await _playerService.AddGameResultAsync(dto);
        if (playerGame is not null)
        {
            return new PlayerDto(playerGame.Player);
        }
        return BadRequest();
    }
}
