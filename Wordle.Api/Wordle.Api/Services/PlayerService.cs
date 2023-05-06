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
        internal Player AddPlayer(string? name, int gameCount, double averageAttempts, int aveargeSecondsPerGame)
        {
            if(name is null)
            {
                throw new ArgumentNullException("Name is required.");
            }

            var player = _db.Players.FirstOrDefault(p => p.Name == name);
            if (player != null)
            {
                player.GameCount = gameCount;
                player.AverageAttempts = averageAttempts;
                player.AveargeSecondsPerGame = aveargeSecondsPerGame;
            }else
            {
                player = new Player()
                {
                    Name = name,
                    GameCount = gameCount,
                    AverageAttempts = averageAttempts,
                    AveargeSecondsPerGame = aveargeSecondsPerGame
                };
                _db.Players.Add(player);
            }
            _db.SaveChanges();
            return player;
        }
    }
}
