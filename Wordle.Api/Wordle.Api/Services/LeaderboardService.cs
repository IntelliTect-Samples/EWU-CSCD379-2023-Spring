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
            return  _db.Players.OrderByDescending(player => player.AverageAttempts).Take(10).ToList();
        }

        public async Task AddPlayer(string Name, double Attempts)
        {
            if (Name.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(Name));
            }

            if (Attempts <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Attempts));
            }

            Player player = _db.Players.Single(player => player.Name == Name);

            if (player == null)
            {
                InsertPlayer(Name, Attempts);
            }
            else
            {
                UpdatePlayer(player, Attempts);
            }

            await _db.SaveChangesAsync();
        }

        public void InsertPlayer(string Name, double Attempts)
        {
            var player = new Player(Name, 1, Attempts);
            _db.Players.Add(player);
        }

        public void UpdatePlayer(Player player, double Attempts)
        {
            player.GameCount += 1;
            int gameCount = player.GameCount;
            double averageAttempts = player.AverageAttempts;
            player.AverageAttempts = averageAttempts + (Attempts - averageAttempts) / gameCount;
        }
    }
}
