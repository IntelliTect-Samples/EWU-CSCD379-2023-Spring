﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
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
            return (await _wordService.GetRandomWordAsync()).Text;
        }

        [HttpGet("GetManyWords")]
        public async Task<IEnumerable<Word>> GetManyWords(int? count)
        {
            return await _wordService.GetSeveralWordsAsync(count);
        }

        [HttpPost]
        public async Task<Word> AddWord(string newWord, bool isCommon)
        {
            return await _wordService.AddWordAsync(newWord, isCommon);
        }

        [HttpPost("AddWordFromBody")]
        public async Task<Word> AddWordFromBody([FromBody] WordDto word)
        {
            return await _wordService.AddWordAsync(word.Text, word.IsCommon);
        }

        [HttpGet("WordOfTheDay")]
        public async Task<WordOfTheDayDto> GetWordOfTheDay(double offsetInHours, DateTime? date = null)
        {
            return new WordOfTheDayDto(await _wordService.GetWordOfTheDayAsync(TimeSpan.FromHours(offsetInHours), date));
        }

        [HttpGet("WordOfTheDayStats")]
        public async Task<IEnumerable<WordOfTheDayStatsDto>> GetWordOfTheDayStats(DateTime? date = null, int days = 10, Guid? playerId = null)
        {
            return (await _wordService.GetWordOfTheDayStatsAsync(date, days, playerId ));
        }

        [HttpGet("GetWordlList")]
        public async Task<IEnumerable<Word>> GetWordList(int pageNumber = 1, int pageSize = 10, string? search = null)
        {
            return await _wordService.GetWords(pageNumber, pageSize, search);
        }

        [HttpDelete]
        public async Task<bool> DeleteWord(int wordId)
        {
            return await _wordService.DeleteWord(wordId);
        }

        [Authorize]
        [HttpPost("UpdateWord")]
        public async Task<Word?> UpdateWord([FromBody] Word word)
        {
            return await _wordService.UpdateWord(word.WordId, word.Text, word.IsCommon, word.IsUsed);
        }
    }
}    
