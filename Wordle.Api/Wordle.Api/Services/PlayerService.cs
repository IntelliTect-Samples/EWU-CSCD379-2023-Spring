using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
    public class PlayerService
    {
        private readonly AppDbContext _db;

        public PlayerService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PlayerDto>> GetTopTenScores()
    {
        int count = 10;
        var totalCount = await _db.Players.CountAsync(player => player.GameCount > 3);
        if (count > totalCount)
        {
            count = totalCount;
        }
        var players = await _db.Players
            .Where(player => player.GameCount > 3)
            .ToListAsync();

        var topPlayers = players
            .OrderByDescending(player => (player.GameCount / ((player.AverageAttempts * 10) + (player.AverageSecondsPerGame / 2))))
            .Take(count)
            .Select(player => new PlayerDto
            {
                Name = player.Name,
                GameCount = player.GameCount,
                AverageAttempts = player.AverageAttempts,
                AverageSecondsPerGame = player.AverageSecondsPerGame
            });
        return topPlayers;
    }

        public async Task<Player> AddPlayer(string newPlayerName, int attempts, int SecondsInGame, int gameCount)
        {
            if (newPlayerName is null || newPlayerName.Length < 3)
            {
                newPlayerName = "Guest";
            }
            var player = await _db.Players.FirstOrDefaultAsync(p => p.Name == newPlayerName);
            if (player != null)
            {
                player.TotalAttempts += attempts;
                player.GameCount += gameCount;
                if (player.TotalSeconds == null) {
                    player.TotalSeconds = 0;
                }
                player.TotalSeconds += SecondsInGame;
            }
            else
            {
                player = new()
                {
                    Name = newPlayerName,
                    TotalAttempts = attempts,
                    GameCount = gameCount,
                    TotalSeconds = SecondsInGame

                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }
    }
}