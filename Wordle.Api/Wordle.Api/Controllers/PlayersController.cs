using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Players>> Get()
        {
            return await Task.FromResult(Enumerable.Range(1, 10).Select(index => new Players
            {
                PlayerId = index,
                Name = $"Player {index}",
                GameCount = Random.Shared.Next(1, 100),
                AverageAttempts = Random.Shared.Next(1, 100)
            })
                           .ToArray());
        }
    }
}
