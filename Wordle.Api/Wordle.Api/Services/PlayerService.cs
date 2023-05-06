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
        
        public async Task<string> UpdatePlayerAsync(string name, int attempts)
        {
            Player? player = _db.Players.SingleOrDefaultAsync( p => p.Name == name ).Result;
            if (player is not null)
            {
                player.UpdateAttempts(attempts);
                _db.SaveChanges();
                return player.Name;
            }
            else
            {
                Player newPlayer = new Player(name, attempts);
                await _db.Players.AddAsync(newPlayer);
                _db.SaveChanges();
                return newPlayer.Name;
            }
        }

        public async Task<List<Player>> GetTopTen()
        {
            return await _db.Players.OrderBy( p => p.AverageAttempts ).Take(10).ToListAsync();
        }
    }
}
