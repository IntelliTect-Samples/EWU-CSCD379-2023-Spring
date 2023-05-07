using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        [HttpPost]
        public async Task<Player> AddNewPlayer(int playerID, string name, int gameCount, int averageAttempts)
        {
            //Add the players score to the database
            return await Task.FromResult(new Player
            {
                PlayerId = playerID,
                Name = name,
                GameCount = gameCount,
                AverageAttempts = averageAttempts
            }) ;

        }
    }
}
