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

        [HttpGet("GetWordOfDay")]
        public async Task<string> GetWordOfDay(int offset) {
            return await _wordService.GetWordOfDay(DateTime.Now.AddDays(offset)); 
        }

        [HttpGet("GetWordOfDayLastTenDays")]
        public async Task<string> GetWordOfDayTenDays(string userName)
        {
            return await _wordService.GetWordOfDayLastTenDays(userName);
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return await _wordService.GetRandomWord();
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

        [HttpPost("DropWord")]
        public async Task<bool> DropWord(string word) {
            return await _wordService.DropWord(word); 
        
        }

        [HttpPost("FlipIsCommon")]
        public async Task<bool> FlipIsCommon(string word)
        {
            return await _wordService.FlipIsCommon(word);

        }

        [HttpGet("GetPageOfWords")]
        public async Task<string> GetPageOfWords(int page, string filter = "") {
            return await _wordService.GetPageOfWords(page, filter); 
        }

    }
}    
