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
        
        public async Task<int> UpdatePlayerAsync(int id, string name, int attempts)
        {
            if (id != -1)
            {
                Player? player = _db.Players.SingleAsync( p => p.PlayerId == id ).Result;
                if (player != null)
                {
                    player.UpdateAttempts(attempts);
                    _db.SaveChanges();
                    return player.PlayerId;
                }
                throw new DbUpdateException("Player ID: " + id);
            }
            else
            {
                Player newPlayer = new Player(name, attempts);
                await _db.Players.AddAsync(newPlayer);
                _db.SaveChanges();
                return newPlayer.PlayerId;
            }
        }
    }
}
