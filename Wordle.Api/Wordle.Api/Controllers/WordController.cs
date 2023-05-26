﻿using Microsoft.AspNetCore.Http;
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
            return (await _wordService.GetRandomWord()).Text;
        }

        [HttpGet("GetManyWords")]
        public async Task<IEnumerable<Word>> GetManyWords(int? count)
        {
            return await _wordService.GetSeveralWords(count);
        }

        [HttpPost]
        public async Task<Word> AddWord(string newWord, bool isCommon)
        {
            return await _wordService.AddWord(newWord, isCommon);
        }

        [HttpPost("AddWordFromBody")]
        public async Task<Word> AddWordFromBody([FromBody] WordDto word)
        {
            return await _wordService.AddWord(word.Text, word.IsCommon);
        }

        [HttpGet("WordOfTheDay")]
        public async Task<string> GetWordOfTheDay(double offsetInHours, DateTime? date = null)
        {
            return await _wordService.GetWordOfTheDay(TimeSpan.FromHours(offsetInHours), date);
        }

        //[HttpGet("WordOfTheDayStats")]
        //public async Task<IEnumerable<WordOfTheDayStatsDto>> GetWordOfTheDayStats(Guid playerId)
        //{
        //    return (await _wordService.GetWordOfTheDayStatsAsync(playerId));
        //}
    }
}
