using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    public class PlayController : Controller
    {
        private readonly PlayService _playService;

        [HttpGet("GetTopTenPlayers")]
        public async Task<string> GetTopTenPlayers()
        {
            return await _playService.GetTopTenPlayers();
        }
        private readonly PlayService _playService;

        [HttpGet("GetLastTenDays")]
        public async Task<string> GetLast10Days()
        {
            return await _playService.GetLastTenDays();
        }

        [HttpGet("InsertPlay_AndIfPlayerDoesNotExist_InsertPlayer")]
        public async Task<string> InsertPlay_AndIfPlayerDoesNotExist_InsertPlayer()
        {
            return await _playService.InsertPlay_AndIfPlayerDoesNotExist_InsertPlayer();
        }

    }
}
