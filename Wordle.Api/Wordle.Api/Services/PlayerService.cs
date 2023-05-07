using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayerService
    {
        private readonly AppDbContext _db;
        public PlayerService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Player>> GetTopTen()
        {
            var players = _db.Players
                .OrderByDescending(p => p.WeightedScore)
                .Take(10)
                .ToListAsync();
            return await players;
        }
        public async Task<Player> AddPlayer(string? name, int gameCount, double averageAttempts, int averageSecondsPerGame)
        {
            if (name is null)
            {
                throw new ArgumentNullException("Name is required.");
            }

            var player = await _db.Players.FirstOrDefaultAsync(p => p.Name == name);
            if (player != null)
            {
                player.GameCount = gameCount;
                player.AverageAttempts = averageAttempts;
                player.AverageSecondsPerGame = averageSecondsPerGame;
                player.WeightedScore = CalculateWeightedScore(gameCount, averageAttempts, averageSecondsPerGame);
            }
            else
            {
                player = new Player()
                {
                    Name = name,
                    GameCount = gameCount,
                    AverageAttempts = averageAttempts,
                    AverageSecondsPerGame = averageSecondsPerGame,
                    WeightedScore = CalculateWeightedScore(gameCount, averageAttempts, averageSecondsPerGame)
                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }

        private double CalculateWeightedScore(int gameCount, double averageAttempts, int averageSecondsPerGame)
        {
            int maxGameCount = 200;
            double normalizedGameCount = 100 * gameCount / maxGameCount;

            double minAverageAttempts = 1;
            double maxAverageAttempts = 6;
            double normalizedAverageAttempts = 100 * (maxAverageAttempts - averageAttempts) / (maxAverageAttempts - minAverageAttempts);

            int minAverageSecondsPerGame = 1;
            int maxAverageSecondsPerGame = 1020; // 17 minutes
            double normalizedAverageSecondsPerGame = 100 * (maxAverageSecondsPerGame - averageSecondsPerGame) / (double)(maxAverageSecondsPerGame - minAverageSecondsPerGame);

            double overallScore = (0.3 * normalizedGameCount) + (0.4 * normalizedAverageAttempts) + (0.3 * normalizedAverageSecondsPerGame);

            return overallScore;
        }

    }
}
