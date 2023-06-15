using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {

            _userService = userService;
        }
        [HttpGet]
        public async Task<string> Get(string username, string password)
        {
            User? user = await _userService.GetUser(username, password);
            return user == null ? "Invalid Username or Password" : $"{user.Username},{user.Wins},{user.Loses}";
        }
        [HttpGet("TopUsers")]
        public async Task<string[]> GetTopUsers()
        {
            return await _userService.getTopUsers();
        }
        [HttpGet("CheckUsername")]
        public async Task<bool> checkUsername(string username) 
        {
            return await _userService.checkUsername(username);
        }

        [HttpPost]
        public async Task<User?> AddUser(string username, string password)
        {
            return await _userService.AddUser(username, password);
        }
        [HttpPost("UpdateUser")]
        public async Task<User?> UpdateWord(string username, bool win)
        {
            return await _userService.UpdateUserScore(username, win);
        }
    }
}