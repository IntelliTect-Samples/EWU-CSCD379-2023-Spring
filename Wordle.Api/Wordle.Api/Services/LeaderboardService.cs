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

        public List<Player> GetLeaderboard()
        {
            return  _db.Players.OrderBy(player => player.AverageAttempts).Take(10).ToList();
        }

        public async Task<Player> AddPlayer(string? name, double Attempts)
        {

            if (name is null)
            {
                throw new ArgumentNullException("Name is required.");
            }

            var player = await _db.Players.FirstOrDefaultAsync(p => p.Name == name);
            if (player != null)
            {
                player.GameCount += 1;
                player.AverageAttempts = player.AverageAttempts + (Attempts - player.AverageAttempts) / player.GameCount;
            }
            else
            {
                player = new Player()
                {
                    Name = name,
                    AverageAttempts = Attempts,
                    GameCount = 1
                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }
    }
}
