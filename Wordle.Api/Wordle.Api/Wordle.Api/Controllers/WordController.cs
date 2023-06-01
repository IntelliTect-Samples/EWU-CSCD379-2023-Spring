using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly WordService _wordService;
        public WordController(WordService wordService) {

            _wordService = wordService; 
        }
        [HttpGet]
        public async Task<string> Get() 
        {
            return (await _wordService.GetRandomWord()).Text;
        }

        [HttpGet("WordOfTheDay")]
        public async Task<string> GetWordOfTheDay(double offsetInHours, DateTime? date =null) 
        {
            return await _wordService.GetWordOfTheDay(TimeSpan.FromHours(offsetInHours), date);
        }

        [HttpGet("AllWords")]
        public async Task<string[]> GetAllWords() 
        {
            return await _wordService.GetAllWords();
        }

        [HttpGet("AllIsCommon")]
        public async Task<string[]> GetAllIsCommon()
        {
            return await _wordService.GetAllIsCommon();
        }

        [HttpPost("AddWord")]
        public async Task<Word> AddWord(string word, bool isCommon) 
        {
            return await _wordService.AddWord(word, isCommon);   
        }
        [HttpPost("UpdateWord")]
        public async Task<Word?> UpdateWord(string word, bool isCommon)
        {
            return await _wordService.UpdateWord(word, isCommon);
        }

        [HttpPost("DeleteWord")]
        public async Task<Word?> DeleteWord(string word)
        {
            return await _wordService.DeleteWord(word);
        }
    }
}