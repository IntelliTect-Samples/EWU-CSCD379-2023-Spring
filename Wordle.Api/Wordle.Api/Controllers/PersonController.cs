﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("Player")]
public class PlayerController : ControllerBase
{
    private readonly PlayerService _PlayerService;
    public PlayerController(PlayerService playerService)
    {
        _PlayerService = playerService;
    }

    [HttpGet]
    public async Task<ActionResult<PlayerDto>> Get(Guid playerId)
    {
        Player? player = await _PlayerService.GetAsync(playerId);

        if (player is not null)
        {
            return new PlayerDto(player);
        }
        return BadRequest();
    }

    [HttpGet("TopPlayers")]
    public async Task<IEnumerable<PlayerDto>> GetTopPlayers()
    {
        return (await _PlayerService.GetTopPlayersAsync()).Select(player => new PlayerDto(player));
    }

    [HttpPost("CreatePlayer")]
    public async Task<PlayerDto> CreatePlayer([FromBody] string name)
    {
        return new PlayerDto(await _PlayerService.CreateAsync(name));
    }

    [HttpPost("RenamePlayer")]
    public async Task<ActionResult<PlayerDto>> RenamePlayer([FromBody] PlayerDto player)
    {
        if (player.PlayerId is null || player.PlayerId == Guid.Empty)
        {
            return BadRequest();
        }
        if (string.IsNullOrWhiteSpace(player.Name))
        {
            return BadRequest();
        }
        var result = await _PlayerService.UpdateAsync(player.PlayerId.Value, player.Name.Trim());
        return new PlayerDto(result);
    }

    [HttpPost("AddGameResult")]
    public async Task<ActionResult<PlayerDto>> AddGameResultAsync(GameResultDto dto)
    {
        var player = await _PlayerService.AddGameResultAsync(dto);
        if (player is not null)
        {
            return new PlayerDto(player);
        }
        return BadRequest();

    }
}