using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{
     public class Player
    {
        public int playerId {  get; set; }
        public string name { get; set; }
        public int GameCount { get; set; }
        public int TotalAttempts { get; set; }
        public double AverageAttempts { get; set; }
        public int TotalSecoundsPlayed { get; set; }
        public int AverageSecondsPerGame { get; set; }

        public static void SeedPlayers(Players db)
        {
            if (!db.Players.Any())
            {
                var playerLines = System.IO.File.ReadAllLines("Content/Players.csv");
                foreach (var line in playerLines)
                {
                    var parts = line.Split(',');
                    var player = new Player()
                    {
                        name = parts[0],
                        GameCount = int.Parse(parts[1])
                        TotalAttempts = int.Parse(parts[2])
                        AverageAttempts = double.Parse(parts[3])
                        TotalSecoundsPlayed = int.Parse(parts[4])
                        AverageSecoundsPerGame = int.Parse(parts[5])
                    }
                    db.Players.Add(player);
                }
                db.SaveChanges();
            }

        }
    }
}