using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;
using Player = Wordle.Api.Data.Player;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }


        [HttpGet("{id}")] // ✅
        public async Task<ActionResult<Player>> GetPlayerById(int id)
        {
            var player = await _playerService.GetPlayerById(id);
            if (player == null) return NotFound();
            return Ok(player);
        }


        [HttpDelete("{id}")] // ✅
        public async Task<ActionResult> RemovePlayer(int id)
        {
            var removed = await _playerService.RemovePlayer(id);
            if (!removed) return NotFound();
            return NoContent();
        }


        [HttpPost("AddOrUpdatePlayerScore")]// ✅
        public async Task<ActionResult<Player>> AddOrUpdatePlayerScore([FromBody] PlayerDto playerDto)
        {
            Player updatedPlayer = await _playerService.AddOrUpdatePlayerScore(playerDto);
            return updatedPlayer;
        }


        [HttpPost("CreateNewPlayer")]
        public async Task<ActionResult<Player>> CreateNewPlayer(string name)
        {
            Player player = await _playerService.CreateNewPlayer(name);
            return player;
        }


        [HttpPut("UpdatePlayerName")] // ✅
        public async Task<ActionResult<Player>> UpdatePlayerName([FromBody] UpdateNameDto updateNameDto)
        {
            Player updatedPlayer = await _playerService.UpdatePlayerName(updateNameDto);
            return updatedPlayer;
        }
    }
}
