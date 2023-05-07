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
                string directoryPath = Directory.GetCurrentDirectory();
                string modelPath = Path.Combine(directoryPath, "Content/Players.csv");
                var playerLine = System.IO.File.ReadAllLines(modelPath);
                foreach (var line in playerLine)
                {
                    var parts = line.Split(',');
                    var player = new Player()
                    {
                        Name = parts[0],
                        GameCount = int.Parse(parts[1]),
                        AverageAttempts = double.Parse(parts[2]),
                        AverageSecondsPerGame = int.Parse(parts[3])
                    };
                    db.Players.Add(player);
                }
                
                db.SaveChanges();
            }
        }
    }
}