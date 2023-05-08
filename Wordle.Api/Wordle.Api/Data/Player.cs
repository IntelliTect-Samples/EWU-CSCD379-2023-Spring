using Wordle.Api.Dtos;

namespace Wordle.Api.Data;

public class Player
{
    public int PlayerId { get; set; }
    public required string Name { get; set; }
    public int GameCount { get; set; }
    public double AverageAttempts { get; set; }
    public int AverageSecondsPerGame { get; set; }
    public ICollection<GameResult> GameResults { get; set; } = new List<GameResult>();

    public static void SeedPlayers(AppDbContext db)
    {
        if (!db.Players.Any())
        {
            Player player = new() { Name = "Victor" };
            db.Players.Add(player);
            db.SaveChanges();
        }
    }
}