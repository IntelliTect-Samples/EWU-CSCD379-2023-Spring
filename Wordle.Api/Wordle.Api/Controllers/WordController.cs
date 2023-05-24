using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class WordController : ControllerBase
{
    private readonly WordService _wordService;

    public WordController(WordService wordService)
    {
        _wordService = wordService;
    }

    [HttpGet]
    public async Task<string> Get()
    {
        return (await _wordService.GetRandomWordAsync()).Text;
    }

    [HttpGet("WordOfTheDay")]
    public async Task<WordOfTheDayDto> GetWordOfTheDay(double offsetInHours, DateTime? date = null)
    {
        return new WordOfTheDayDto(
            await _wordService.GetWordOfTheDayAsync(TimeSpan.FromHours(offsetInHours), date));
    }

    [HttpGet("WordOfTheDayStats")]
    public async Task<IEnumerable<WordOfTheDayStatsDto>> GetWordOfTheDayStats(DateTime? date = null,
                                                                              int days = 10,
                                                                              Guid? playerId = null)
    {
        return (await _wordService.GetWordOfTheDayStatsAsync(date, days, playerId));
    }

    [HttpGet("WordList")]
    public async Task<List<string>> GetWordList()
    {
        return await _wordService.GetWordList();
    }
}
