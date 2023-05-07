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
                player.WeightedScore = await CalculateWeightedScore(gameCount, averageAttempts, averageSecondsPerGame);
            }
            else
            {
                player = new Player()
                {
                    Name = name,
                    GameCount = gameCount,
                    AverageAttempts = averageAttempts,
                    AverageSecondsPerGame = averageSecondsPerGame,
                    WeightedScore = await CalculateWeightedScore(gameCount, averageAttempts, averageSecondsPerGame)
                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }

        private async Task<double> CalculateWeightedScore(int gameCount, double averageAttempts, int averageSecondsPerGame)
        {
            // Not working correctly yet
            if (!_db.Players.Any()) return 1;

            // Finding the minimum and maximum values for GameCount
            int minGameCount = await _db.Players.MinAsync(p => p.GameCount);
            int maxGameCount = await _db.Players.MaxAsync(p => p.GameCount);

            double normalizedGameCount = (maxGameCount - minGameCount) != 0 ? (gameCount - minGameCount) /
                (maxGameCount - minGameCount) : 0.0;

            // Finding the minimum and maximum values for AverageAttempts
            double minAverageAttempts = await _db.Players.MinAsync(p => p.AverageAttempts);
            double maxAverageAttempts = await _db.Players.MaxAsync(p => p.AverageAttempts);

            double normalizedAverageAttempts = (maxAverageAttempts - minAverageAttempts) != 0
    ? (averageAttempts - minAverageAttempts) / (maxAverageAttempts - minAverageAttempts)
    : 0.0;

            // Finding the minimum and maximum values for AverageSecondsPerGame
            double minAverageSecondsPerGame = await _db.Players.MinAsync(p => p.AverageSecondsPerGame);
            double maxAverageSecondsPerGame = await _db.Players.MaxAsync(p => p.AverageSecondsPerGame);

            double normalizedAverageSecondsPerGame = (maxAverageSecondsPerGame - minAverageSecondsPerGame) != 0 ?(averageSecondsPerGame - minAverageSecondsPerGame) /
                (maxAverageSecondsPerGame - minAverageSecondsPerGame) : 0.0;

            double overallScore = (0.3 * normalizedGameCount) + (0.4 * normalizedAverageAttempts) + (0.3 * normalizedAverageSecondsPerGame);

            return overallScore;
        }

    }
}
