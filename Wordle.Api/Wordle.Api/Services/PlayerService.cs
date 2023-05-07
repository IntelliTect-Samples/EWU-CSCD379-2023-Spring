using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayerService
    {
        
        private readonly Players _db;

        public PlayerService(Players db)
        {
            _db = db;
        }
        
        public async Task<IEnumerable<Player>> GetTopTen()
        {
            var count ??= 10;
            var totalCount = await _db.Players.CountAsync(player => player.AverageAttempts);
            totalCount -= count.Value;
            int index = ;
            var topTen = await _db.Players
                .Where(player => player.AverageAttempts)
                .Skip(index)
                .Take(count.name, count.AverageAttempts, count.GameCount, count.AverageSecondsPerGame)
                .OrderByDescending(p => p.AverageAttempts)
                .ToListAsync();
            return topTen;
        }
        
        public async Task<Player> AddPlayer(string? newName, int? playTime)
        {
            if(newName == null) { throw new ArgumentException("Name can't be null"); }
            var player = await _db.Players.FirstOrDefaultAsync(p =>  p.Name == newName);
            if(player != null) 
            {
                player.GameCount++;
                player.TotalAttempts++;
                player.AverageAttempts = player.TotalAttempts / player.GameCount;
                player.TotalSecoundsPlayed += playTime;
                player.AverageSecondsPerGame = player.TotalSecoundsPlayed / player.GameCount;
            }
            else
            {
                player = new()
                {
                    name = newName,
                    GameCount = 1,
                    TotalAttempts = 1,
                    AverageAttempts = 1,
                    TotalSecoundsPlayed = playTime,
                    AverageSecondsPerGame = playTime
                };
                db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }

    }
}