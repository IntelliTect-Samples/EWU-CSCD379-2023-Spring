using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("DateWord")]
    public class DateWordController : ControllerBase
    {
        private readonly DateWordService _DateWordService;
        public DateWordController(DateWordService DateWordService)
        {
            _DateWordService = DateWordService;
        }

    [HttpPost("AddDailyGameResult")]
    public async Task<ActionResult<GameResultDto>> AddDailyGameResultAsync(GameResultDto dto)
    {
        var added = await _DateWordService.AddDailyGameResultAsync(dto);
        if (added is not null)
        {
            return dto;
        }
        return BadRequest();
    }

    [HttpGet("GetLastTenWords")]
    public async Task<IEnumerable<DateWord>> GetLastTenWords()
    {
        return await _DateWordService.GetLastTenWords();
    }
    [HttpGet]
    public async Task<IList<Player>> ReturnListOfPlayersForWordOfTheDay(double offsetInHours, DateTime? date = null)
    {
        var ret = await _DateWordService.ReturnListOfPlayersForWordOfTheDay(TimeSpan.FromHours(offsetInHours), date);
        if (ret is not null)
        {
            return ret;
        }
        else
        {
            return (IList<Player>)BadRequest();
        }
    }
}

