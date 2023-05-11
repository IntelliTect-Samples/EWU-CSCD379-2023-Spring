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
        public async Task<Player> AddPlayer(string? name, double numberOfAttempts, int elapsedSeconds)
        {

            if (name is null)
            {
                throw new ArgumentNullException("Name is required.");
            }

            var player = await _db.Players.FirstOrDefaultAsync(p => p.Name == name);
            if (player != null)
            {
                player.GameCount++;
                player.AverageAttempts = CalculateAverageAttempts(player.GameCount, player.AverageAttempts, numberOfAttempts);
                player.AverageSecondsPerGame = CalculateAverageSecondsPerGame(player.GameCount, player.AverageSecondsPerGame, elapsedSeconds);
                player.WeightedScore = CalculateWeightedScore(player.GameCount, player.AverageAttempts, player.AverageSecondsPerGame);
            }
            else
            {
                player = new Player()
                {
                    Name = name,
                    GameCount = 1,
                    AverageAttempts = numberOfAttempts,
                    AverageSecondsPerGame = elapsedSeconds,
                    WeightedScore = CalculateWeightedScore(1, numberOfAttempts, elapsedSeconds)
                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }

        private double CalculateAverageAttempts(int gameCount, double oldAverage, double currentAttempts)
        {
            double totalAttempts = (oldAverage * (gameCount - 1)) + currentAttempts;
            return totalAttempts / (gameCount);
        }

        private int CalculateAverageSecondsPerGame(int gameCount, int oldAverage, int currentAttempts)
        {
            double totalAttempts = (oldAverage * (gameCount - 1)) + currentAttempts;
            return (int)(totalAttempts / gameCount);
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
