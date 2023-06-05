namespace Wordle.Api.Data
{
    public static class Seeder
    {
        public static void Seed(AppDbContext context)
        {
            SeedPlayers(context);
            SeedWords(context);
        }
 
        public static void SeedWords(AppDbContext db)
        {
            if (!db.Words.Any())
            {
                var wordLines = System.IO.File.ReadAllLines("Content/Words.csv");
                foreach (var line in wordLines)
                {
                    var parts = line.Split(',');
                    var word = new Word()
                    {
                        Text = parts[0],
                        IsCommon = bool.Parse(parts[1])
                    };
                    db.Words.Add(word);
                }
                db.SaveChanges();
            }
        }

        public static void SeedPlayers (AppDbContext db)
        {
            if (!db.Players.Any())
            {
                db.Players.Add(new Player { Name = "Sam", AverageAttempts = 4.5, AverageSecondsPerGame = 62, GameCount = 25, PlayerId = Guid.NewGuid() });
                db.Players.Add(new Player { Name = "James", AverageAttempts = 4.8, AverageSecondsPerGame = 195, GameCount = 42, PlayerId = Guid.NewGuid() });
                db.Players.Add(new Player { Name = "Kelly", AverageAttempts = 3.5, AverageSecondsPerGame = 30, GameCount = 55, PlayerId = Guid.NewGuid() });
                db.Players.Add(new Player { Name = "Susan", AverageAttempts = 2.7, AverageSecondsPerGame = 70, GameCount = 23, PlayerId = Guid.NewGuid() });
                db.SaveChanges();
            }
        }

   }
}
