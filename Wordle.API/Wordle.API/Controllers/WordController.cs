using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.API.Data;
using Wordle.API.Services;

namespace Wordle.API.Controllers
    {
    [Route("[controller]")]
    [ApiController]
    public class WordController : ControllerBase
        {
        private readonly WordService : ControllerBase;
        public WordController(WordService wordService)
        {
            _wordService = wordService;
        }

        [HttpGet]
         public string Get()
            {
                return _wordService.GetRandomWord();
            
            }
        public async Task<string> Get()
            {
                return await _wordService.GetRandomWordAsync();
            }
        }
    }
