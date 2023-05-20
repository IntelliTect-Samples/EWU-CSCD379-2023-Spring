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
        public async Task<string> GetWordOfTheDay(double offsetInHours) 
        {
            return await _wordService.GetWordOfTheDay(TimeSpan.FromHours(offsetInHours));
        }

    }
}