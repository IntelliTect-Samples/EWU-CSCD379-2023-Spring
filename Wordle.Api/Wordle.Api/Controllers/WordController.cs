using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
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

    [HttpPost("AddWord")]
    public async Task<Word> AddWord(WordDto newWord)
    {
        return await _wordService.AddWordAsync(newWord.Text, newWord.IsCommon);
    }

    [HttpGet("WordOfTheDay")]
    public async Task<WordOfTheDayDto> GetWordOfTheDay(double offsetInHours, DateTime? date = null)
    {
        return new WordOfTheDayDto(await _wordService.GetWordOfTheDayAsync(TimeSpan.FromHours(offsetInHours), date));
    }

    [HttpGet("WordOfTheDayStats")]
    public async Task<IEnumerable<WordOfTheDayStatsDto>> GetWordOfTheDayStats(DateTime? date = null,
                                                                              int days = 10,
                                                                              Guid? playerId = null)
    {
        return (await _wordService.GetWordOfTheDayStatsAsync(date, days, playerId));
    }

    [HttpGet("ValidWordList")]
    public async Task<List<string>> GetValidWordList()
    {
        return await _wordService.GetValidWordList();
    }

    [HttpGet("WordList")]
    public async Task<List<Word>> GetWordList(int pageNumber, string? searchWord)
    {
        return await _wordService.GetWordList(pageNumber, searchWord);
    }

    [HttpPost("RemoveWord")]
    public async Task<int> RemoveWordFromList(WordDto word) 
    {
        return await _wordService.RemoveWordFromListAsync(word);
    }
}
