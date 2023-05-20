using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    public class PlayController : Controller
    {
        private readonly PlayService _playService;

        public PlayController(PlayService playService)
        {
            _playService = playService;
        }

        [HttpGet("GetTopTenPlayers")]
        public async Task<string> GetTopTenPlayers()
        {
            return await _playService.GetTopTenPlayers();
        }

        [HttpPost("InsertPlay_AndIfPlayerDoesNotExist_InsertPlayer")]
        public async Task<string> InsertPlay_AndIfPlayerDoesNotExist_InsertPlayer([FromBody] PlayDto play)
        {
            return await _playService.InsertPlay_AndIfPlayerDoesNotExist_InsertPlayer(play);
        }

    }
}
