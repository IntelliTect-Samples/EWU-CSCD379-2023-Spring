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


        public async Task<IEnumerable<Player>> GetTopPlayers(int? count)
        {
            count ??= 10;
            
            var players = await _db.Players
                .Where(player => player.GameCount > 10)
                .OrderBy(p => p.AverageAttempts)//Lowest average attempts
                .ThenByDescending(p => p.GameCount)//Then by highest number of games played
                .Take(count.Value)
                .ToListAsync();
            return players;
        }

        public async Task<Player> AddScore(string? name, int numAttempts, int seconds)
        {
            if (name is null)
            {
                throw new ArgumentException("Passed name is null");
            }
            var player = await _db.Players.FirstOrDefaultAsync(p => p.Name == name);
            if (player != null)
            {
                // update player data
                //word.IsCommon = isCommon;
                var newGameCount = player.GameCount + 1;
                var oldGameCount = player.GameCount;
                player.AverageAttempts = ((player.AverageAttempts * oldGameCount) + numAttempts) / newGameCount;
                player.AverageSecondsPerGame = ((player.AverageSecondsPerGame * oldGameCount) + seconds) / newGameCount;
                player.GameCount = newGameCount;
            }
            else
            {
                player = new()
                {
                    Name = name,
                    GameCount = 1,
                    AverageAttempts = numAttempts,
                    AverageSecondsPerGame = seconds
                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }
    }
}