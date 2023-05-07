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
        /*
        public async Task<IEnumerable<Player>> GetPlayer()
        {
            
        }
        */
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