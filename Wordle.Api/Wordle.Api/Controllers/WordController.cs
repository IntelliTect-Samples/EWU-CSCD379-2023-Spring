using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Identity;
using Wordle.Api.Models;
using Wordle.Api.Services;


namespace Wordle.Api.Controllers
{
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
            Word word = await _wordService.GetRandomWord();
            return word.Text;
        }

        [HttpGet("GetManyWords")]
        public async Task<IEnumerable<Word>> GetManyWords(int? count)
        {
            return await _wordService.GetSeveralWords(count);
        }

        [HttpPost("AddWord")]
        public async Task<Word> AddWord(string newWord, bool isCommon)
        {
            return await _wordService.AddWord(newWord, isCommon);
        }

        [Authorize(Policy = Policies.EditWord)]
        [HttpPost("AddWordFromBody")]
        public async Task<Word> AddWordFromBody([FromBody] WordDto word)
        {
            return await _wordService.AddWord(word.Text, word.IsCommon);
        }

        [HttpGet("WordOfTheDay")]
        public async Task<WordOfTheDayDto> GetWordOfTheDay(double offsetInHours, DateTime? date = null)
        {
            return new WordOfTheDayDto(await _wordService.GetWordOfTheDay(TimeSpan.FromHours(offsetInHours), date));
        }

        [HttpGet("GetDailyWordStatistics")]
        public async Task<List<WordOfTheDayStatsDto>> GetDailyWordStatistics(string? name = null)
        {
            DateTime? date = null;
            int daysBack = 10;
            return await _wordService.GetDailyWordStatistics(date, daysBack, name);
        }

        [Authorize(Policy = Policies.EditWord)]
        [HttpPost("RemoveWord")]
        public async Task<Word> RemoveWord(string? removeWord)
        {
            return await _wordService.RemoveWord(removeWord);
        }

        [HttpGet("WordList")]
        public async Task<IEnumerable<Word>> WordList()
        {
            return await _wordService.WordList();
        }

    }
}    
