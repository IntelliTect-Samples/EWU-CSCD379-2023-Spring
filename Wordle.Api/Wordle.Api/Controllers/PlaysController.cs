using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlaysController : ControllerBase
    {
        private readonly PlaysService _playsService;

        public PlaysController(PlaysService playsService)
        {
            _playsService = playsService;
        }

        [HttpPost]
        public async Task<Plays> AddPlay()
        {
            return await _playsService.AddPlay();
        }

        [HttpGet]
        public async Task<IEnumerable<Plays>> GetDailyWordStatistics()
        {
            return _playsService.GetDailyWordStatistics();
        }
    }
}