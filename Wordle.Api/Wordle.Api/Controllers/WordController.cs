using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Wordle.Api.Identity;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly WordService _wordService;
        public UserManager<AppUser> _userManager;
        public JwtConfiguration _jwtConfiguration;

        public WordController(WordService wordService, UserManager<AppUser> userManager, JwtConfiguration jwtConfiguration)
        {
            _wordService = wordService;
            _userManager = userManager;
            _jwtConfiguration = jwtConfiguration;
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

        [HttpPost("AddWordFromText")]
        [Authorize(Policy = Policies.MasterOfTheUniverse)]
        public async Task<Word> AddWord(string newWord, bool isCommon)
        {
            return await _wordService.AddWordAsync(newWord, isCommon);
        }
        [HttpPost("DeleteWordFromText")]
        [Authorize(Policy = Policies.MasterOfTheUniverse)]
        public async Task<Word> DeleteWord(string targetWord)
        {
            return await _wordService.DeleteWordAsync(targetWord);
        }

        [HttpPost("AddWordFromBody")]
        [Authorize(Policy = Policies.MasterOfTheUniverse)]
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

        [HttpGet("paginatedWords")]
        public async Task<IEnumerable<Word>> GetPaginatedWords(int page = 1, int count = 10, string start = "")
        {
            return (await _wordService.GetPaginatedWordsAsync(page, count, start));
        }
    }
}    
