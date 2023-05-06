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
            var players = _db.Players.Take(10).ToListAsync();
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

            // Finding the minimum and maximum values for GameCount
            int minGameCount = _db.Players.Min(p => p.GameCount);
            int maxGameCount = _db.Players.Max(p => p.GameCount);

            double normalizedGameCount = (gameCount - minGameCount) /
                (maxGameCount - minGameCount);

            // Finding the minimum and maximum values for AverageAttempts
            double minAverageAttempts = _db.Players.Min(p => p.AverageAttempts);
            double maxAverageAttempts = _db.Players.Max(p => p.AverageAttempts);

            double normalizedAverageAttempts = (averageAttempts - minAverageAttempts) /
                (maxAverageAttempts - minAverageAttempts);

            // Finding the minimum and maximum values for AverageSecondsPerGame
            double minAverageSecondsPerGame = _db.Players.Min(p => p.AverageSecondsPerGame);
            double maxAverageSecondsPerGame = _db.Players.Max(p => p.AverageSecondsPerGame);

            double normalizedAverageSecondsPerGame = (averageSecondsPerGame - minAverageSecondsPerGame) /
                (maxAverageSecondsPerGame - minAverageSecondsPerGame);

            double overallScore = (0.3 * normalizedGameCount) + (0.4 * normalizedAverageAttempts) + (0.3 * normalizedAverageSecondsPerGame);

            return overallScore;
        }

    }
}
