namespace Wordle.Api.Data
{

    public class Player
    {
        public int PlayerId { get; set; }
        public required string Name { get; set; }
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }
        public double AverageSecondsPerGame { get; set; }

        public static void SeedPlayers(AppDbContext db)
        {
            if (!db.Players.Any())
            {
                var player1 = new Player()
                {
                    Name = "bob",

                };
                db.Players.Add(player1);
                var player2 = new Player()
                {
                    Name = "phil",

                };
                db.Players.Add(player2);
                var player3 = new Player()
                {
                    Name = "joe",

                };
                db.Players.Add(player3);

                db.SaveChanges();
            }
        }

    }
}
