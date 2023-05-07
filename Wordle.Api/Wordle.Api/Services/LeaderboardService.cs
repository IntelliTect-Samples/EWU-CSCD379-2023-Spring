using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
    public class LeaderboardService
    {
        private readonly AppDbContext _db;

        public LeaderboardService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Player>> GetTopPlayers(int count)
        {
            return await _db.Players.OrderByDescending(p => p.AverageAttempts).Take(count).ToListAsync();
        }

        public async Task<Player> AddPlayerToLeaderboard(PlayerDto playerDto)
        {
            var player = new Player
            {
                Name = playerDto.Name,
                GameCount = playerDto.GameCount,
                AverageAttempts = playerDto.AverageAttempts
            };

            _db.Players.Add(player);
            await _db.SaveChangesAsync();
            return player;
        }

        public async Task<bool> UpdatePlayerOnLeaderboard(PlayerDto playerDto)
        {
            var player = await _db.Players.FirstOrDefaultAsync(p => p.Name == playerDto.Name);
            if (player == null) return false;

            player.GameCount = playerDto.GameCount;
            player.AverageAttempts = playerDto.AverageAttempts;

            await _db.SaveChangesAsync();
            return true;
        }
    }
}
