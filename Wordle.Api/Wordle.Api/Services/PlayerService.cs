using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayerService
    {
        
        private readonly PlayersDbContext _db;

        public PlayerService(PlayersDbContext db)
        {
            _db = db;
        }
        /*In Progress
        public async Task<IEnumerable<Player>> GetTopTen()
        {
            var count = 10;
            var totalCount = await _db.Players.CountAsync(player => player.AverageAttempts);
            totalCount -= count.Value;
            int index = totalCount.playerId;
            var topTen = await _db.Players
                .Where(player => player.AverageAttempts)
                .Skip(index)
                .Take(totalCount.name, totalCount.AverageAttempts, totalCount.GameCount, totalCount.AverageSecondsPerGame)
                .OrderByDescending(p => p.AverageAttempts)
                .ToListAsync();
            return topTen;

        }
        */
        public async Task<Player> AddPlayer(string newName, int playTime, int guesses)
        {
            if(newName == null) { throw new ArgumentException("Name can't be null"); }
            var player = await _db.Players.FirstOrDefaultAsync(p =>  p.name == newName);
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
                    name = newName,
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