using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<IEnumerable<Player>> GetTopTenScores()
        {
            return await _db.Players.OrderBy(player => player.AverageAttempts).Take(10).ToListAsync();
        }

        public async Task<Player> AddNewScore(string? name, double attempts)
        {
            // Used null forgiveness because compiler is not recognizing
            // that null is impossible with the condition
            string playerName = name.IsNullOrEmpty() ? "Guest" : name!;
            if(_db.Players.Any(p => p.Name == playerName))
            {
                Player player = await UpdateScore(playerName, attempts);
                await _db.SaveChangesAsync();
                return player;
            }
            else
            {
                Player player = new()
                {
                    Name = playerName,
                    GameCount = 1,
                    AverageAttempts = attempts
                };
                _db.Players.Add(player);
                await _db.SaveChangesAsync();
                return player;
            }
        }

        public async Task<Player> UpdateScore(string name, double attempts)
        {
            var player = await _db.Players.FirstOrDefaultAsync(p => p.Name == name);
            player!.GameCount++;
            player.AverageAttempts = ((player.AverageAttempts * (player.GameCount - 1)) + attempts) / player.GameCount;
            return player;
        }
    }
}