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
                    GameCount = 5,
                    AverageAttempts = 2,
                    AverageSecondsPerGame = 120

                };
                db.Players.Add(player1);
                var player2 = new Player()
                {
                    Name = "phil",
                    GameCount = 7,
                    AverageAttempts = 4,
                    AverageSecondsPerGame = 75

                };
                db.Players.Add(player2);

                var player3 = new Player()
                {
                    Name = "joe",
                    GameCount = 13,
                    AverageAttempts = 6,
                    AverageSecondsPerGame = 90
                };
                db.Players.Add(player3);

                var player4 = new Player()
                {
                    Name = "kevin",
                    GameCount = 9,
                    AverageAttempts = 3,
                    AverageSecondsPerGame = 600
                };
                db.Players.Add(player4);

                var player5 = new Player()
                {
                    Name = "samuel",
                    GameCount = 4,
                    AverageAttempts = 2,
                    AverageSecondsPerGame = 555.4
                };
                db.Players.Add(player5);

                var player6 = new Player()
                {
                    Name = "karen",
                    GameCount = 3212,
                    AverageAttempts = 1,
                    AverageSecondsPerGame = 69.42
                };
                db.Players.Add(player6);

                var player7 = new Player()
                {
                    Name = "elise",
                    GameCount = 8,
                    AverageAttempts = 4.4,
                    AverageSecondsPerGame = 33
                };
                db.Players.Add(player7);

                var player8 = new Player()
                {
                    Name = "Mathew Hageland",
                    GameCount = 1000,
                    AverageAttempts = 6,
                    AverageSecondsPerGame = 500000
                };
                db.Players.Add(player8);

     
                
                var player9 = new Player()
                {
                    Name = "Grant Erickson",
                    GameCount = 500,
                    AverageAttempts = 1,
                    AverageSecondsPerGame = 2
                };
                db.Players.Add(player9);

                var player10 = new Player()
                {
                    Name = "Meg",
                    GameCount = 800,
                    AverageAttempts = 1,
                    AverageSecondsPerGame = 0.5
                };
                db.Players.Add(player10);

                db.SaveChanges();
            }
        }

    }
}
