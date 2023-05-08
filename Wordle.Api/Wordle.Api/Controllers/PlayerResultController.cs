using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Threading.Tasks;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("api/PlayerResult")]
    public class PlayerResultController : ControllerBase
    {
        private readonly PlayerResultService _playerResultService;

        public PlayerResultController(PlayerResultService playerResultService)
        {
            _playerResultService = playerResultService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerResultDto>>> GetAll()
        {
            var results = await _playerResultService.GetAllGameResults();
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<PlayerResultDto>> Save([FromBody] PlayerResultDto playerResultDto)
        {
            var savedResult = await _playerResultService.SaveGameResult(playerResultDto);
            return Ok(savedResult);
        }

        [HttpGet("topscores")]
        public async Task<ActionResult<IEnumerable<PlayerResultDto>>> GetTopScores(int count = 10)
        {
            var topScores = await _playerResultService.GetTopScores(count);
            return Ok(topScores);
        }
    }
}
