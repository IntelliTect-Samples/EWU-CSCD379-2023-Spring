using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Wordle.Api.Dtos;

namespace Wordle.Api.Data
{
    public class Player
    {
        public int PlayerId { get; set; }
        public required string Name { get; set; }
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }
        public int AverageSecondsPerGame { get; set; }
        public ICollection<PlayerResult> PlayerResults { get; set; } = new List<PlayerResult>();
        public static void SeedPlayers(AppDbContext db)
        {
            if (!db.Players.Any())
            {
                Player player = new() { Name = "Winner" };
                db.Players.Add(player);
                db.SaveChanges();
            }
            else { throw new Exception(); }
        }
    }
}
