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

        public async Task<IEnumerable<Player>> GetTopTenScores()
        {
            int count = 10;
            var totalCount = await _db.Players.CountAsync(player => player.GameCount > 6);
            if (count > totalCount)
            {
                count = totalCount;
            }
            var players = await _db.Players
                .Where(player => player.GameCount > 6)
                .ToListAsync();

            var topPlayers = players
                .OrderBy(player => player.AverageAttempts)
                .Take(count);

            return topPlayers;
        }

        public async Task<Player> AddPlayer(string newPlayerName, int attempts, int? SecondsInGame)
        {
            if (newPlayerName is null || newPlayerName.Length < 3)
            {
                newPlayerName = "Guest";
            }
            var player = await _db.Players.FirstOrDefaultAsync(p => p.Name == newPlayerName);
            if (player != null)
            {
                player.TotalAttempts += attempts;
                player.GameCount += 1;
                player.TotalSeconds += SecondsInGame;
            }
            else
            {
                player = new()
                {
                    Name = newPlayerName,
                    TotalAttempts = attempts,
                    GameCount = 1,
                    TotalSeconds = SecondsInGame

                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }
    }
}