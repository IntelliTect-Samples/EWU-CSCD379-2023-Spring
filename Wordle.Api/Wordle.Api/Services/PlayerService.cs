using System;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Player?> GetPlayerById(int id) // ✅
        {
            return await _db.Players.FindAsync(id);
        }

        public async Task<bool> RemovePlayer(int id) // ✅
        {
            var player = await _db.Players.FindAsync(id);
            if (player == null) return false;

            _db.Players.Remove(player);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Player> AddOrUpdatePlayerScore(string name, int score)
        {
            var player = await _db.Players.FirstOrDefaultAsync(p => p.Name == name);

            if (player != null)
            {
                player.Score += score;
                player.GameCount += 1;
                player.AverageAttempts = (int)Math.Round((double)player.Score / player.GameCount);
            }
            else
            {
                player = new Player
                {
                    Name = name,
                    Score = score,
                    GameCount = 1,
                    AverageAttempts = score // Since it's the first game
                };
                _db.Players.Add(player);
            }

            await _db.SaveChangesAsync();
            return player;
        }

        public async Task<bool> UpdatePlayerName(string currentName, string newName)
        {
            var player = await _db.Players.FirstOrDefaultAsync(p => p.Name == currentName);
            if (player == null)
            {
                return false;
            }

            player.Name = newName;
            await _db.SaveChangesAsync();
            return true;
        }

    }
}