namespace Wordle.Api.Data
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string? Name { get; set; }
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }

        //public static void SeedPlayers(AppDbContext db)
        //{
        //    if (!db.Players.Any())
        //    {
        //        var players = new List<Player>()
        //        {
        //            new Player() { Name = "JohnTest", GameCount = 5, AverageAttempts = 3.2 },
        //            new Player() { Name = "MaryTest", GameCount = 7, AverageAttempts = 2.8 },
        //            new Player() { Name = "BobTest", GameCount = 10, AverageAttempts = 4.1 }
        //        };
        //        db.Players.AddRange(players);
        //        db.SaveChanges();
        //    }
        //}
    }
}