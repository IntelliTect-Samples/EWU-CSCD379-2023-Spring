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
    public async Task<DateWord?> AddDailyGameResultAsync(string PlayerId, int DateWordId, int Seconds, int Attempts )
    {
        var added = await _DateWordService.AddDailyGameResultAsync( PlayerId, DateWordId, Seconds, Attempts);
        if (added is not null)
        {
            return added;
        }
        return null;
    }

    [HttpGet("GetLastTenWords")]
    public async Task<IEnumerable<DateWord>> GetLastTenWords()
    {
        return await _DateWordService.GetLastTenWords();
    }
    [HttpGet]
    public async Task<DateWord?> GetDateWord(double offsetInHours, DateTime? date = null)
    {
        var ret = await _DateWordService.GetDateWordAsync(TimeSpan.FromHours(offsetInHours), date);
        if (ret is not null)
        {
            return ret;
        }
        else
        {
            return null;
        }
    }
}

