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
        
        public async Task<Player> AddPlayer(string newName, int playTime, int guesses)
        {
            if(newName == null) { throw new ArgumentException("Name can't be null"); }
            var player = await _db.Players.FirstOrDefaultAsync(p =>  p.Name == newName);
            if(player != null) 
            {
                player.GameCount++;
                player.TotalAttempts += guesses;
                player.AverageAttempts = player.TotalAttempts / player.GameCount;
                player.TotalSecondsPlayed += playTime;
                player.AverageSecondsPerGame = player.TotalSecondsPlayed / player.GameCount;
            }
            else
            {
                player = new()
                {
                    Name = newName,
                    GameCount = 1,
                    TotalAttempts = guesses,
                    AverageAttempts = 1,
                    TotalSecondsPlayed = playTime,
                    AverageSecondsPerGame = playTime
                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }

    }
}