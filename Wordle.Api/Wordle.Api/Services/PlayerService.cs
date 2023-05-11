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

        public async Task<IEnumerable<Player>> GetTopTen()
        {

            var topTen = await _db.Players
                .OrderBy(p => p.AverageAttempts)
                .ThenByDescending(p => p.GameCount)
                .Take(10)
                .ToListAsync();
            return topTen;

        }
        
        public async Task<Player> AddPlayer(string Name, int TotalSecondsPlayed, int TotalAttempts)
        {
            if(Name == null) { throw new ArgumentException("Name can't be null"); }
            var player = await _db.Players.FirstOrDefaultAsync(p =>  p.Name == Name);
            if(player != null) 
            {   
                player.GameCount++;
                player.TotalAttempts += TotalAttempts;
                player.AverageAttempts = player.TotalAttempts / player.GameCount;
                player.TotalSecondsPlayed += TotalSecondsPlayed;
                player.AverageSecondsPerGame = player.TotalSecondsPlayed / player.GameCount;
            }
            else
            {
                player = new()
                {
                    Name = Name,
                    GameCount = 1,
                    TotalAttempts = TotalAttempts,
                    AverageAttempts = TotalAttempts,
                    TotalSecondsPlayed = TotalSecondsPlayed,
                    AverageSecondsPerGame = TotalSecondsPlayed,
                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }

    }
}