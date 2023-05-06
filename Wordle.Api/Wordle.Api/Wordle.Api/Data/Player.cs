
namespace Wordle.Api.Data
{
    public class Player
    {
        public int PlayerId { get; set; }
        public required string Name { get; set; }
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }
        //Optoinsal, might implement later
        //public int AverageSecondsPerGame { get; set; }

        public static void SeedPlayers(AppDbContext db) 
        {
            if (!db.Players.Any()) 
            {
                var wordLines = System.IO.File.ReadAllLines("Content/Players.csv");
                foreach (var line in wordLines) 
                {
                    string[] parts = line.Split(',');
                    Player player = new Player()
                    {
                        Name = parts[0],
                        GameCount = int.Parse(parts[1]),
                        AverageAttempts = double.Parse(parts[2])
                    };
                    db.Players.Add(player);
                }
                db.SaveChanges();
            }
        }
    }
}