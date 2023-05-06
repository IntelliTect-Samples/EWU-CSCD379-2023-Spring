using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaderBoardController : ControllerBase
    {
        private readonly LeaderBoardService _leaderBoardService;

        public LeaderBoardController(LeaderBoardService leaderBoardService)
        {
            _leaderBoardService = leaderBoardService;
        }
    }
}