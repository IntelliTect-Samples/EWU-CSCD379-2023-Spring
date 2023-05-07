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
            var updatedPlayer = await _playerService.AddOrUpdatePlayerScore(playerDto.Name, playerDto.Score);
            return Ok(updatedPlayer);
        }

        [HttpPost("UpdatePlayerName")]
        public async Task<IActionResult> UpdatePlayerName([FromBody] UpdateNameDto updateNameDto)
        {
            bool isUpdated = await _playerService.UpdatePlayerName(updateNameDto.CurrentName, updateNameDto.NewName);
            if (!isUpdated)
            {
                return NotFound($"Player with name '{updateNameDto.CurrentName}' not found.");
            }
            return Ok($"Player name successfully updated from '{updateNameDto.CurrentName}' to '{updateNameDto.NewName}'.");
        }

    }
}
