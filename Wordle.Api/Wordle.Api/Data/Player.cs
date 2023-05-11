using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{
    public class Player
    {
        public int PlayerId { get; set; }
        public required string Name { get; set; }
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }
        public int AverageSecondsPerGame { get; set; }


        public static void SeedPlayers(AppDbContext db)
        {
            if (!db.Players.Any())
            {
                
                var player = new Player()
                {
                    Name = "Theoretical Best",
                    GameCount = 99999,
                    AverageAttempts = 1,
                    AverageSecondsPerGame = 1
                };
                db.Players.Add(player);
                player = new Player()
                {
                    Name = "James",
                    GameCount = 360,
                    AverageAttempts = 3.6,
                    AverageSecondsPerGame = 432
                };
                db.Players.Add(player);
                player = new Player()
                {
                    Name = "William",
                    GameCount = 53,
                    AverageAttempts = 4.4,
                    AverageSecondsPerGame = 537
                };
                db.Players.Add(player);

                db.SaveChanges();
            }
        }
    }
}