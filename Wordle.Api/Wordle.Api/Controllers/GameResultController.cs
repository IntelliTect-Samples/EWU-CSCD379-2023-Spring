using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameResultController : ControllerBase
    {
        private GameResultService _grs;

        public GameResultController(GameResultService grs) 
        { 
            _grs = grs;
        }

        [HttpGet]
        public IEnumerable<GameResult> Get()
        {
            return new List<GameResult>();
        }
        [HttpPost]
        public async Task<ActionResult<GameResultDto>> Post(GameResult result)
        {
            GameResultDto? dto = await _grs.SaveGameResult(result);
            if (dto is not null)
            {
                return dto;
            }
            return BadRequest();
        }

        [HttpGet("topscores")]
        public async Task<IEnumerable<GameResultDto>> GetTopScores(int count = 10)
        {
            return await _grs.GetTopScores(count);
        }
    }
}
