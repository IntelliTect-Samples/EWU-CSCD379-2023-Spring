using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
        public async Task<string[]> GetTopScores() 
        {
            var players = await _db.Players.OrderBy(player => player.AverageAttempts).ThenBy(player => player.GameCount).Take(10).ToArrayAsync();
            string[] scores = new string[players.Length];
            int count = 0;
            foreach (var player in players) 
            {
                scores[count] = $"{player.Name},{player.AverageAttempts},{player.GameCount}";
                count++;
            }
            return scores;
        }
    }
}