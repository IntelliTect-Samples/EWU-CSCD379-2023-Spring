using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("Dailystats")]
    public class DailyStatsController : ControllerBase
    {
        private readonly DailyStatsService _DailyStatsService;
        public DailyStatsController(DailyStatsService dailyStatsService)
        {
            _DailyStatsService = dailyStatsService;
        }

    [HttpPost("AddDailyGameResult")]
    public async Task<ActionResult<DateWordStatsDto>> AddDailyGameResultAsync(DateWordDto dto)
    {
        var added = await _DailyStatsService.AddDailyGameResultAsync(dto);
        if (added is not null)
        {
            return new DateWordStatsDto(added);
        }
        return BadRequest();
    }

    [HttpGet("GetLastTenWords")]
    public async Task<IEnumerable<DateWordStats>> GetLastTenWords()
    {
        return await _DailyStatsService.GetLastTenWords();
    }
}

