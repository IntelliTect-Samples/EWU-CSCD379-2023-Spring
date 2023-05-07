using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty; // Initialize Name with an empty string

        public int Score { get; set; }
        public int GameCount { get; set; }

        public double AverageAttempts { get; set; }

        // Constructor that takes Name as an argument
        public Player(string name)
        {
            Name = name;
        }

        // Parameterless constructor for Entity Framework
        public Player() { }

        public static void SeedPlayers(AppDbContext db)
        {
            if (!db.Players.Any())
            {
                Player defaultPlayer = new Player("Jake")
                {
                    GameCount = 0,
                    AverageAttempts = 0
                };

                db.Players.Add(defaultPlayer);
                db.SaveChanges();
            }
        }
    }
}
