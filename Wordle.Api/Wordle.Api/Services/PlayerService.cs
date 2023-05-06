using Microsoft.AspNetCore.Mvc;
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

        public Player[] GetTop10() {
            return  _db.Players.OrderBy(player => player.AverageAttempts).Take(10).ToArray();  
        }



        public async Task<Player> AddPlayer(string? newPlayerName)
        {
            if (newPlayerName is null)
            {
                newPlayerName = "Guest";
            }
            var player = await _db.Players.FirstOrDefaultAsync(w => w.Name == newPlayerName);
            if (player != null)
            {
                player.GameCount = 1; 
            }
            else
            {
                player = new()
                {
                    Name = newPlayerName,
                    GameCount = 1
                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }
    }
}

