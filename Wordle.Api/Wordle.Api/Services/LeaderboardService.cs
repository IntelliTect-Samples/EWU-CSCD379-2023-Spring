using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class LeaderboardService
    {
        private readonly AppDbContext _db;

        public LeaderboardService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<Player>> GetLeaderboard()
        {
            ICollection<Player> highScore = await _db.Players.OrderByDescending(player =>  player.AverageAttempts).Take(10).ToListAsync();
            return highScore;
        }

        public async Task<Player> AddPlayer(string Name, double AverageAttempts, int GameCount)
        {

        }
       
    }
}
